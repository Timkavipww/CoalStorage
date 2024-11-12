using Ardalis.GuardClauses;
using CoalStorage.Core.Interfaces;
using CoalStorage.Infrastructure.Data;
using CoalStorage.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Microsoft.OpenApi.Models;
using NSwag;
using NSwag.AspNetCore;


namespace CoalStorage.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionstring = configuration.GetConnectionString("DefaultConnection");
        Guard.Against.Null(connectionstring, message: "Connection string 'DefaultConnection' not found.");

        services.AddControllers();
        services.AddAuthentication();
        services.AddAuthorization();

        services.AddDbContext<AppDbContext>(options =>
        options.UseNpgsql(connectionstring));


        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        services.AddScoped<IStorageRepository, StorageRepository>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<AppDbContextInitialiser>();
        services.AddScoped<AuthRepository>();
        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen(options =>
        {
                options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.ApiKey,
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Description = "Введите 'Bearer {токен}' для доступа к защищенным маршрутам"
                });


            options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>() // Для глобальной безопасности нет дополнительных параметров
        }
    });
        });


        services.AddOpenApiDocument(config =>
        {
            config.DocumentName = "v1";
            config.Title = "Coal Storage API";
            config.Version = "v1";
            config.Description = "API для управления складом угля";
            config.AddSecurity("JWT", new NSwag.OpenApiSecurityScheme
            {
                Type = NSwag.OpenApiSecuritySchemeType.ApiKey,
                Name = "Authorization", 
                In = NSwag.OpenApiSecurityApiKeyLocation.Header,
                Description = "Введите 'Bearer {токен}' для доступа к защищенным маршрутам"
            });

            config.PostProcess = document =>
            {
                document.Info.Contact = new NSwag.OpenApiContact
                {
                    Name = "Техническая поддержка",
                    Email = "zxsqwr520@gmail.com",
                    Url = "https://t.me/friday13teen"
                };
                document.Info.License = new NSwag.OpenApiLicense
                {
                    Name = "Contacts",
                    Url = "https://t.me/friday13teen"
                };
            };
        });


        return services;
    }
}
