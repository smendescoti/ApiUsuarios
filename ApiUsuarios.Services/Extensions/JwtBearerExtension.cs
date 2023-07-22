﻿using ApiUsuarios.Domain.Interfaces;
using ApiUsuarios.Infra.Authentication.Services;
using ApiUsuarios.Infra.Authentication.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace ApiUsuarios.Services.Extensions
{
    /// <summary>
    /// Classe de extensão para configurarmos o tipo de autenticação do projeto
    /// </summary>
    public static class JwtBearerExtension
    {
        public static IServiceCollection AddJwtBearer(this IServiceCollection services)
        {
            services.AddAuthentication(
                auth =>
                {
                    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }).AddJwtBearer(
                bearer =>
                {
                    bearer.RequireHttpsMetadata = false;
                    bearer.SaveToken = true;
                    bearer.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey
                            (Encoding.ASCII.GetBytes(JwtSettings.SecretKey)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                }
                );

            services.AddTransient<IUsuarioAuthentication, UsuarioAuthentication>();
            return services;
        }
    }
}
