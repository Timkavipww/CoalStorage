namespace CoalStorage.Core.Interfaces;

public interface ITokenService
{
    string GenerateToken(string username, string password);
}

public class TokenService : ITokenService
{
    public string GenerateToken(string username, string password)
    {
        if (username == "admin" && password == "password")
        {
            return "generated-jwt-token";
        }

        return null;
    }
}
