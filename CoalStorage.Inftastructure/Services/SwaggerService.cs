namespace CoalStorage.Infrastructure.Services;

public static class SwaggerService
{
    public static void addSwagger(this WebApplication app)
    {
        app.UseOpenApi();
        app.UseSwaggerUi();
        
    }
}
