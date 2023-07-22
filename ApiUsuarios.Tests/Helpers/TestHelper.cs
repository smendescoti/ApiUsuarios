using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUsuarios.Tests.Helpers
{
    public static class TestHelper
    {
        /// <summary>
        /// Criando um Client HTTP para acessar os serviços da API
        /// </summary>
        public static HttpClient CreateClient
            => new WebApplicationFactory<Program>().CreateClient();

        /// <summary>
        /// Método para serializar os dados que serão enviados para um serviço
        /// </summary>
        public static StringContent CreateContent<T>(T request)
            => new StringContent(JsonConvert.SerializeObject(request),
                Encoding.UTF8, "application/json");
    }
}
