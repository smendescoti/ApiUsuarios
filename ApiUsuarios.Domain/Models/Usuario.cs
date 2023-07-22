using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUsuarios.Domain.Models
{
    /// <summary>
    /// Modelo de domínio para a entidade: Usuario
    /// </summary>
    public class Usuario
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public DateTime? DataHoraCriacao { get; set; }
        public string? AccessToken { get; set; }
    }
}
