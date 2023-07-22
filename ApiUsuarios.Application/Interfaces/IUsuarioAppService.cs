using ApiUsuarios.Application.Models.Requests;
using ApiUsuarios.Application.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUsuarios.Application.Interfaces
{
    /// <summary>
    /// Interface para abstração dos fluxos da camada de aplicação
    /// </summary>
    public interface IUsuarioAppService
    {
        /// <summary>
        /// Método de ação para criar a conta do usuário
        /// </summary>
        /// <param name="model">Dados da requisição</param>
        /// <returns>Dados da resposta</returns>
        CriarContaResponseModel CriarConta(CriarContaRequestModel model);

        /// <summary>
        /// Método de ação para autenticar o usuário
        /// </summary>
        /// <param name="model">Dados da requisição</param>
        /// <returns>Dados da resposta</returns>
        AutenticarResponseModel Autenticar(AutenticarRequestModel model);
        
        /// <summary>
        /// Método de ação para atualizar os dados do usuário
        /// </summary>
        /// <param name="model">Dados da requisição</param>
        /// <returns>Dados da resposta</returns>
        AtualizarDadosResponseModel AtualizarDados(AtualizarDadosRequestModel model, string emailUsuario);

        /// <summary>
        /// Método de ação para recuperação da senha do usuário
        /// </summary>
        /// <param name="model">Dados da requisição</param>
        /// <returns>Dados da resposta</returns>
        RecuperarSenhaResponseModel RecuperarSenha(RecuperarSenhaRequestModel model);
    }
}
