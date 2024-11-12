
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CoalStorage.API.Services;

public class TokenService
{
    private readonly string _secretKey = "your-secret-key-here"; // Секретный ключ
    private readonly string _issuer = "your-app"; // Issuer
    private readonly string _audience = "your-audience"; // Audience

    public string GenerateToken(string username)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, username), // имя пользователя
            new Claim(JwtRegisteredClaimNames.Sub, username), // subject
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) // уникальный идентификатор токена
        };

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(1), // время истечения токена
            Issuer = _issuer,
            Audience = _audience,
            SigningCredentials = credentials
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token); // возвращаем JWT как строку
    }
}
