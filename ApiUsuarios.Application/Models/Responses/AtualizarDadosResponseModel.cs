using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUsuarios.Application.Models.Responses
{
    public class AtualizarDadosResponseModel
    {
        public string? Mensagem { get; set; }
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public DateTime? DataHoraAtualizacao { get; set; }
    }
}
