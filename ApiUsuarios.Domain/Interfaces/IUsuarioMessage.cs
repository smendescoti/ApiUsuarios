using ApiUsuarios.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUsuarios.Domain.Interfaces
{
    public interface IUsuarioMessage
    {
        //método para enviar conteúdo para fila
        void Send(UsuarioMessageDto dto);
    }
}
