namespace CoalStorage.Web.Services;

/// <summary>
/// Services Extensions
/// </summary>
public static class ServicesExtensions
{
    public static IServiceCollection addServices(this IServiceCollection services)
    {
        
        services.AddOpenApiDocument(document => document.DocumentName = "a");
        services.AddSwaggerDocument(document => document.DocumentName = "b");
        
        return services;
    }
}
