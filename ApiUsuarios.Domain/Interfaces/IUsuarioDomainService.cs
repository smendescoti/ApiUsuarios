using ApiUsuarios.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUsuarios.Domain.Interfaces
{
    /// <summary>
    /// Interface para abstração das operações de regras de negócio de Usuario
    /// </summary>
    public interface IUsuarioDomainService
    {
        Usuario Autenticar(string email, string senha);
        void CriarConta(Usuario usuario);
        Usuario RecuperarSenha(string email);
        Usuario AtualizarDados(string email, string nome, string senha);
    }
}
