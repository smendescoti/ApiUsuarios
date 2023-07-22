using ApiUsuarios.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUsuarios.Domain.Interfaces
{
    /// <summary>
    /// Interface para abstração dos métodos do repositório de usuários.
    /// </summary>
    public interface IUsuarioRepository
    {
        void Add(Usuario usuario);
        void Update(Usuario usuario);
        Usuario Get(string email);
        Usuario Get(string email, string senha);
    }
}
