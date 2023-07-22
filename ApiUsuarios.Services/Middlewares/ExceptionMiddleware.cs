using ApiUsuarios.Domain.Exceptions;
using Newtonsoft.Json;
using System.Net;
using System.Text.Json.Serialization;

namespace ApiUsuarios.Services.Middlewares
{
    /// <summary>
    /// Classe para tratamento das exceções geradas no projeto
    /// </summary>
    public class ExceptionMiddleware
    {
        //atributo
        private readonly RequestDelegate? _requestDelegate;

        //construtor para injeção de dependência
        public ExceptionMiddleware(RequestDelegate? requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        /// <summary>
        /// Método para capturar as exceções que poderão ser geradas pelo projeto
        /// </summary>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _requestDelegate(context);
            }
            catch (EmailJaCadastradoException e)
            {
                await HandleException(context, e);
            }
            catch (UsuarioNaoEncontradoException e)
            {
                await HandleException(context, e);
            }
            catch (AcessoNegadoException e)
            {
                await HandleException(context, e);
            }
            catch (Exception e)
            {
                await HandleException(context, e);
            }
        }

        //Método para fazer o tratamento das exceções
        private async Task HandleException(HttpContext context, Exception e)
        {
            switch (e)
            {
                case EmailJaCadastradoException:
                    //HTTP 400 BAD REQUEST
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;

                case UsuarioNaoEncontradoException:
                    //HTTP 404 NOT FOUND
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;

                case AcessoNegadoException:
                    //HTTP 401 UNAUTHORIZED
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    break;

                case Exception:
                    //HTTP 500 INTERNAL SERVER ERROR
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            //retornando o conteúdo do erro..
            context.Response.ContentType = "application/json";

            var result = new ErrorResult
            {
                StatusCode = context.Response.StatusCode,
                Message = e.Message,
            };

            await context.Response.WriteAsync(JsonConvert.SerializeObject(result));
        }
    }

    /// <summary>
    /// Modelo de dados para retornar o conteudo dos erros
    /// </summary>
    public class ErrorResult
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }
    }
}
