﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUsuarios.Application.Models.Requests
{
    /// <summary>
    /// Modelo de dados para a requisição de criação de conta do usuário
    /// </summary>
    public class CriarContaRequestModel
    {
        [MinLength(8, ErrorMessage = "Informe no mínimo {1} caracteres.")]
        [MaxLength(100, ErrorMessage = "Informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome do usuário.")]
        public string? Nome { get; set; }

        [EmailAddress(ErrorMessage = "Por favor, informe um endereço de email válido.")]
        [Required(ErrorMessage = "Por favor, informe o email do usuário.")]
        public string? Email { get; set; }

        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@#$%^&+=!*()\-_{}[\]:;""',.<>?|]).{8,}$",
            ErrorMessage = "A senha deve atender aos seguintes critérios:\n" +
                      "- Pelo menos 8 caracteres\n" +
                      "- Pelo menos uma letra minúscula\n" +
                      "- Pelo menos uma letra maiúscula\n" +
                      "- Pelo menos um dígito\n" +
                      "- Pelo menos um caractere especial\n" +
                      "- Não pode conter espaços em branco")]
        [Required(ErrorMessage = "Por favor, informe a senha do usuário.")]
        public string? Senha { get; set; }
    }
}
