using Microsoft.OpenApi.Models;
using System.Reflection;

namespace ApiUsuarios.Services.Extensions
{
    /// <summary>
    /// Classe de extensão para adicionarmos no projeto as configurações
    /// de geraçao da documentação do Swagger (OpenAPI)
    /// </summary>
    public static class SwaggerDocExtension
    {
        /// <summary>
        /// Personalizando o conteudo da documentação gerada pelo Swagger
        /// </summary>
        public static IServiceCollection AddSwaggerDoc(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API de controle de usuários - COTI Informática",
                    Description = "API REST desenvolvida em AspNet 7 com EntityFramework",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "COTI Informática",
                        Email = "contato@cotiinformatica.com.br",
                        Url = new Uri("http://www.cotiinformatica.com.br")
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });

            return services;
        }

        /// <summary>
        /// Configurando a execução da página de documentação
        /// </summary>
        public static IApplicationBuilder UseSwaggerDoc(this IApplicationBuilder app)
        {
            app.UseSwagger(); //abrindo a página da documentação
            //gerando o link utilizado para importar a documentação api no POSTMAN (api-docs)
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiUsuarios.Services");
            });

            return app;
        }
    }
}
