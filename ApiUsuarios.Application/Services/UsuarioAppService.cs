using ApiUsuarios.Application.Interfaces;
using ApiUsuarios.Application.Models.Requests;
using ApiUsuarios.Application.Models.Responses;
using ApiUsuarios.Domain.Interfaces;
using ApiUsuarios.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUsuarios.Application.Services
{
    /// <summary>
    /// Classe para implementar os serviços de aplicação
    /// </summary>
    public class UsuarioAppService : IUsuarioAppService
    {
        //atributo
        private readonly IUsuarioDomainService? _usuarioDomainService;

        //construtor para injeção de dependência (inicialização)
        public UsuarioAppService(IUsuarioDomainService? usuarioDomainService)
        {
            _usuarioDomainService = usuarioDomainService;
        }

        /// <summary>
        /// Serviço da aplicação para criação da conta do usuário.
        /// </summary>
        public CriarContaResponseModel CriarConta(CriarContaRequestModel model)
        {
            //capturando os dados do usuário enviado pelo request
            var usuario = new Usuario
            {
                Nome = model.Nome,
                Email = model.Email,
                Senha = model.Senha
            };

            //criando a conta do usuário
            _usuarioDomainService?.CriarConta(usuario);

            //retornando a resposta com os dados do usuário cadastrado
            return new CriarContaResponseModel
            {
                Mensagem = "Parabéns! Sua conta de usuário foi criada com sucesso.",
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                DataHoraCriacao = usuario.DataHoraCriacao
            };
        }

        /// <summary>
        /// Serviço da aplicação para autenticação do usuário.
        /// </summary>
        public AutenticarResponseModel Autenticar(AutenticarRequestModel model)
        {
            var usuario = _usuarioDomainService?.Autenticar(model.Email, model.Senha);

            //retornando a resposta com os dados do usuário cadastrado
            return new AutenticarResponseModel
            {
                Mensagem = "Autenticação realizada com sucesso.",
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                AccessToken = usuario.AccessToken
            };
        }

        /// <summary>
        /// Serviço da aplicação para atualização dos dados do usuário.
        /// </summary>
        public AtualizarDadosResponseModel AtualizarDados(AtualizarDadosRequestModel model, string emailUsuario)
        {
            var usuario = _usuarioDomainService?.AtualizarDados(emailUsuario, model.Nome, model.Senha);

            //retornando a resposta com os dados do usuário atualizado
            return new AtualizarDadosResponseModel
            {
                Mensagem = "Atualização de dados realizada com sucesso",
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                DataHoraAtualizacao = DateTime.Now
            };
        }

        /// <summary>
        /// Serviço da aplicação para recuperação da senha do usuário.
        /// </summary>
        public RecuperarSenhaResponseModel RecuperarSenha(RecuperarSenhaRequestModel model)
        {
            var usuario = _usuarioDomainService.RecuperarSenha(model.Email);

            //retornando a resposta com os dados do usuário atualizado
            return new RecuperarSenhaResponseModel
            {
                Mensagem = "Recuperação de senha realizado com sucesso.",
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                DataHoraRecuperacaoDeSenha = DateTime.Now
            };
        }
    }
}
