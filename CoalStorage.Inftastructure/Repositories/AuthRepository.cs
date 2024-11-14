namespace CoalStorage.Infrastructure.Repositories;

public class AuthRepository
{
    private readonly string _secretKey;
    private readonly string _issuer;
    private readonly string _audience;
    private readonly ITokenService _tokenService;
    public AuthRepository(IConfiguration configuration, ITokenService tokenService)
    {
        _tokenService = tokenService;
        _secretKey = configuration["JwtSettings:SecretKey"] ?? throw new ArgumentNullException("SecretKey is not set");
        _issuer = configuration["JwtSettings:Issuer"] ?? throw new ArgumentNullException("Issuer is not set");
        _audience = configuration["JwtSettings:Audience"] ?? throw new ArgumentNullException("Audience is not set");
    }

    public string AuthenticateUser(LoginModel model)
    {
        var users = new Dictionary<string, string>
        {
            { "testuser", "password123" }
        };

        if (users.ContainsKey(model.Username) && users[model.Username] == model.Password)
        {
            return _tokenService.GenerateToken(model.Username, model.Password);
        }

        return null;
    }

   
}
