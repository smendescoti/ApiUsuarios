using ApiUsuarios.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUsuarios.Domain.Interfaces
{
    /// <summary>
    /// Interface para abstração das operações de autenticação de Usuario
    /// </summary>
    public interface IUsuarioAuthentication
    {
        /// <summary>
        /// Método para gerar o token de acesso do usuário
        /// </summary>
        string CreateToken(Usuario usuario);
    }
}
