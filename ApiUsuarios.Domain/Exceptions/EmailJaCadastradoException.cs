﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUsuarios.Domain.Exceptions
{
    /// <summary>
    /// Exceção customizada para email de usuário já cadastrado
    /// </summary>
    public class EmailJaCadastradoException : Exception
    {
        public override string Message 
            => "O email informado já está cadastrado, tente outro.";
    }
}
