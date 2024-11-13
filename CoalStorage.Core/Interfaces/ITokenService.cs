namespace CoalStorage.Core.Interfaces;

public interface ITokenService
{
    string GenerateToken(string username, string password);
}

