using CoalStorage.Core.Interfaces;
using CoalStorage.Inftastructure.Data;
using CoalStorage.Inftastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoalStorage.Inftastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionstring = configuration.GetConnectionString("DefaultConnection");

        //Guard.Against.Null(connectionString, message: "Connection string 'DefaultConnection' not found.");
        services.AddDbContext<AppDbContext>(options =>
        options.UseNpgsql(connectionstring));
        services.AddOpenApiDocument(document => document.DocumentName = "a");
        services.AddSwaggerDocument(document => document.DocumentName = "b");
        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        services.AddScoped<IStorageRepository, StorageRepository>();
        services.AddScoped<AppDbContextInitialiser>();

        return services;
    }
}
