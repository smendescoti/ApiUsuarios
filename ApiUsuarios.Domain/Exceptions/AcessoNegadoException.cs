using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUsuarios.Domain.Exceptions
{
    /// <summary>
    /// Exceção customizada para acesso negado de usuário
    /// </summary>
    public class AcessoNegadoException : Exception
    {
        public override string Message 
            => "Acesso negado. Usuário inválido.";
    }
}
