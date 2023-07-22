using ApiUsuarios.Application.Models.Requests;
using ApiUsuarios.Tests.Helpers;
using Bogus;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ApiUsuarios.Tests.Tests
{
    public class UsuariosTest
    {
        [Fact(Skip = "Não implementado.")]
        public void Test_Autenticar_Returns_Ok()
        {
            //TODO
        }

        [Fact(Skip = "Não implementado.")]
        public void Test_Autenticar_Returns_Unauthorized()
        {
            //TODO
        }

        [Fact]
        public async Task<CriarContaRequestModel> Test_CriarConta_Returns_Created()
        {
            var faker = new Faker("pt_BR");
            var request = new CriarContaRequestModel
            {
                Nome = faker.Person.FullName,
                Email = faker.Person.Email,
                Senha = "@Teste1234"
            };

            var content = TestHelper.CreateContent(request);
            var result = await TestHelper.CreateClient.PostAsync("/api/usuarios/criarconta", content);

            result.StatusCode
                .Should()
                .Be(HttpStatusCode.Created);

            return request;
        }

        [Fact]
        public async Task Test_CriarConta_Returns_BadRequest()
        {
            var request = await Test_CriarConta_Returns_Created();

            var content = TestHelper.CreateContent(request);
            var result = await TestHelper.CreateClient.PostAsync("/api/usuarios/criarconta", content);

            result.StatusCode
               .Should()
               .Be(HttpStatusCode.BadRequest);
        }

        [Fact(Skip = "Não implementado.")]
        public void Test_RecuperarSenha_Returns_Ok()
        {
            //TODO
        }

        [Fact(Skip = "Não implementado.")]
        public void Test_RecuperarSenha_Returns_BadRequest()
        {
            //TODO
        }
    }
}
