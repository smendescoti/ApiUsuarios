using ApiUsuarios.Application.Interfaces;
using ApiUsuarios.Application.Models.Requests;
using ApiUsuarios.Application.Models.Responses;
using ApiUsuarios.Services.Middlewares;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiUsuarios.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        //atributo
        private readonly IUsuarioAppService? _usuarioAppService;

        //construtor para injeção de dependência
        public UsuariosController(IUsuarioAppService? usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }

        /// <summary>
        /// Serviço para autenticação de usuários.
        /// </summary>
        [HttpPost]
        [Route("Autenticar")]
        [ProducesResponseType(typeof(AutenticarResponseModel), 200)]
        [ProducesResponseType(typeof(ErrorResult), 401)]
        public IActionResult Autenticar(AutenticarRequestModel request)
        {
            var response = _usuarioAppService?.Autenticar(request);
            return StatusCode(200, response);
        }

        /// <summary>
        /// Serviço para criação de conta de novos usuários.
        /// </summary>
        [HttpPost]
        [Route("CriarConta")]
        [ProducesResponseType(typeof(CriarContaResponseModel), 201)]
        [ProducesResponseType(typeof(ErrorResult), 400)]
        public IActionResult CriarConta(CriarContaRequestModel request)
        {
            var response = _usuarioAppService?.CriarConta(request);
            return StatusCode(201, response);
        }

        /// <summary>
        /// Serviço para atualização de dados do usuário.
        /// </summary>
        [Authorize]
        [HttpPut]
        [Route("AtualizarDados")]
        [ProducesResponseType(typeof(AtualizarDadosResponseModel), 200)]
        [ProducesResponseType(typeof(ErrorResult), 404)]
        public IActionResult AtualizarDados(AtualizarDadosRequestModel request)
        {
            //capturar o email do usuário autenticado contido no TOKEN
            var emailUsuario = User.Identity.Name;

            var response = _usuarioAppService?.AtualizarDados(request, emailUsuario);
            return StatusCode(200, response);
        }

        /// <summary>
        /// Serviço para recuperação da senha do usuário.
        /// </summary>
        [HttpPost]
        [Route("RecuperarSenha")]
        [ProducesResponseType(typeof(RecuperarSenhaResponseModel), 200)]
        [ProducesResponseType(typeof(ErrorResult), 404)]
        public IActionResult RecuperarSenha(RecuperarSenhaRequestModel request)
        {
            var response = _usuarioAppService?.RecuperarSenha(request);
            return StatusCode(200, response);
        }
    }
}
