using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUsuarios.Domain.Exceptions
{
    /// <summary>
    /// Exceção customizada para usuário não encontrado
    /// </summary>
    public class UsuarioNaoEncontradoException : Exception
    {
        public override string Message 
            => @"Usuário não encontrado.";
    }
}
