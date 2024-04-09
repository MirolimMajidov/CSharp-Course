using BankManagementSystem.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace MyUser.Models.Helpers;

/// <summary>
/// See here to get more information: https://metanit.com/sharp/aspnet6/13.2.php
/// </summary>
public static class ServiceCollectionExtensions
{
    public static void AddMyAuth(this IServiceCollection service)
    {
        service.AddAuthorization(options =>
        {
            options.AddPolicy("AdminOnly", 
                policy =>
                {
                    policy.RequireRole("admin");
                    policy.RequireRole("editor");
                });
            options.AddPolicy("UserOnly", policy => policy.RequireRole("User"));
        });
        service.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    // указывает, будет ли валидироваться издатель при валидации токена
                    ValidateIssuer = true,
                    // строка, представляющая издателя
                    ValidIssuer = AuthOptions.ISSUER,

                    // будет ли валидироваться потребитель токена
                    ValidateAudience = true,
                    // установка потребителя токена
                    ValidAudience = AuthOptions.AUDIENCE,

                    // будет ли валидироваться время существования
                    ValidateLifetime = true,

                    // валидация ключа безопасности
                    ValidateIssuerSigningKey = true,
                    // установка ключа безопасности
                    IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                };
            });
    }
}
