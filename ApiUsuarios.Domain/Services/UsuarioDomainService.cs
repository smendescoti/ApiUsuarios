using ApiUsuarios.Domain.Dtos;
using ApiUsuarios.Domain.Exceptions;
using ApiUsuarios.Domain.Helpers;
using ApiUsuarios.Domain.Interfaces;
using ApiUsuarios.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ApiUsuarios.Domain.Services
{
    /// <summary>
    /// Implementação das regras de negócio para a entidade: Usuario
    /// </summary>
    public class UsuarioDomainService : IUsuarioDomainService
    {
        //atributos
        private readonly IUsuarioRepository? _usuarioRepository;
        private readonly IUsuarioAuthentication? _usuarioAuthentication;
        private readonly IUsuarioMessage? _usuarioMessage;

        //construtor para injeção de dependência (inicialização dos atributos)
        public UsuarioDomainService(IUsuarioRepository? usuarioRepository, IUsuarioAuthentication? usuarioAuthentication, IUsuarioMessage? usuarioMessage)
        {
            _usuarioRepository = usuarioRepository;
            _usuarioAuthentication = usuarioAuthentication;
            _usuarioMessage = usuarioMessage;
        }

        public Usuario Autenticar(string email, string senha)
        {
            var usuario = _usuarioRepository?.Get(email, Sha1Helper.Encrypt(senha));
            if (usuario == null)
                throw new AcessoNegadoException();

            usuario.AccessToken = _usuarioAuthentication?.CreateToken(usuario);
            return usuario;
        }

        public void CriarConta(Usuario usuario)
        {
            //Não permitir o cadastro de usuários com o mesmo email
            if (_usuarioRepository?.Get(usuario.Email) != null)
                throw new EmailJaCadastradoException();

            //gerando os dados adicionais do usuário
            usuario.Id = Guid.NewGuid();
            usuario.Senha = Sha1Helper.Encrypt(usuario.Senha);
            usuario.DataHoraCriacao = DateTime.Now;

            //gravando no banco de dados
            _usuarioRepository?.Add(usuario);

            //enviando para a mensageria
            _usuarioMessage?.Send(new UsuarioMessageDto
            {
                DataHora = DateTime.Now,
                TipoMensagem = TipoMensagem.BoasVindas,
                Usuario = new UsuarioDto
                {
                    Id = usuario.Id,
                    Nome = usuario.Nome,
                    Email = usuario.Email
                }
            });
        }

        public Usuario RecuperarSenha(string email)
        {
            var usuario = _usuarioRepository?.Get(email);
            if (usuario == null)
                throw new UsuarioNaoEncontradoException();

            //enviando para a mensageria
            _usuarioMessage?.Send(new UsuarioMessageDto
            {
                DataHora = DateTime.Now,
                TipoMensagem = TipoMensagem.RecuperarSenha,
                Usuario = new UsuarioDto
                {
                    Id = usuario.Id,
                    Nome = usuario.Nome,
                    Email = usuario.Email
                }
            });

            return usuario;
        }

        public Usuario AtualizarDados(string email, string nome, string senha)
        {
            //pesquisar o usuário no banco de dados através do email
            var usuario = _usuarioRepository?.Get(email);

            //verificar se o usuário não foi encontrado
            if (usuario == null)
                throw new UsuarioNaoEncontradoException();

            var isUpdate = false;

            //verificar se o nome do usuário foi preenchido
            if (!string.IsNullOrEmpty(nome))
            {
                usuario.Nome = nome;
                isUpdate = true;
            }

            //verificar se a senha do usuário foi preenchida
            if (!string.IsNullOrEmpty(senha))
            {
                usuario.Senha = Sha1Helper.Encrypt(senha);
                isUpdate = true;
            }

            if(isUpdate)
                _usuarioRepository?.Update(usuario);

            return usuario;
        }
    }
}
