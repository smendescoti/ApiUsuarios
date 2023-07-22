using ApiUsuarios.Application.Interfaces;
using ApiUsuarios.Application.Services;
using ApiUsuarios.Domain.Interfaces;
using ApiUsuarios.Domain.Services;
using ApiUsuarios.Infra.Data.Repositories;
using ApiUsuarios.Infra.Messages.Producers;

namespace ApiUsuarios.Services.Extensions
{
    /// <summary>
    /// Classe de extensão para configurarmos as injeções
    /// de dependência feitas no projeto
    /// </summary>
    public static class DependencyInjectionExtension
    {
        /// <summary>
        /// Método para configurarmos as injeções de dependência
        /// que serão adicionadas no projeto AspNet
        /// </summary>
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddTransient<IUsuarioAppService, UsuarioAppService>();
            services.AddTransient<IUsuarioDomainService, UsuarioDomainService>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IUsuarioMessage, UsuarioMessageProducer>();

            return services;
        }
    }
}
