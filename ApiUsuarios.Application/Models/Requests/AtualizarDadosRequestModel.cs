using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUsuarios.Application.Models.Requests
{
    public class AtualizarDadosRequestModel
    {
        [MinLength(8, ErrorMessage = "Informe no mínimo {1} caracteres.")]
        [MaxLength(100, ErrorMessage = "Informe no máximo {1} caracteres.")]
        public string? Nome { get; set; }

        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@#$%^&+=!*()\-_{}[\]:;""',.<>?|]).{8,}$",
            ErrorMessage = "A senha deve atender aos seguintes critérios:\n" +
                      "- Pelo menos 8 caracteres\n" +
                      "- Pelo menos uma letra minúscula\n" +
                      "- Pelo menos uma letra maiúscula\n" +
                      "- Pelo menos um dígito\n" +
                      "- Pelo menos um caractere especial\n" +
                      "- Não pode conter espaços em branco")]
        public string? Senha { get; set; }
    }
}
