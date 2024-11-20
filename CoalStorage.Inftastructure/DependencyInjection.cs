namespace CoalStorage.Infrastructure;

public static class DependencyInjection
{

    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var secretKey = configuration["JwtSettings:SecretKey"];
        var issuer = configuration["JwtSettings:Issuer"];
        var audience = configuration["JwtSettings:Audience"];
        var connectionstring = configuration.GetConnectionString("DefaultConnection");

        Guard.Against.Null(connectionstring, message: "Connection string 'DefaultConnection' not found.");

        services.AddControllers();

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;

                // Загружаем параметры из конфигурации
                var issuer = configuration["JwtSettings:Issuer"];
                var audience = configuration["JwtSettings:Audience"];
                var secretKey = configuration["JwtSettings:SecretKey"];

                // Проверка на длину ключа
                if (string.IsNullOrEmpty(secretKey) || secretKey.Length < 32)
                {
                    throw new ArgumentException("SecretKey must be at least 32 characters long.");
                }

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = issuer,
                    ValidAudience = audience,
                    // Убедитесь, что длина ключа корректна
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                };
            });


        services.AddAuthorization();

        services.AddDbContext<AppDbContext>(options => {
            options.UseNpgsql(connectionstring);
            options.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole())).EnableSensitiveDataLogging();
        }
        );


        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        services.AddScoped<IStorageRepository, StorageRepository>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IAreaRepository, AreaRepository>();
        services.AddScoped<AppDbContextInitialiser>();
        services.AddScoped<AuthRepository>();
        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen(options =>
        {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.ApiKey,
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Description = "Введите 'Bearer {токен}' для доступа к защищенным маршрутам"
                });


            options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
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
