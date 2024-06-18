using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace backendnet.Services;

public class JwtTokenService(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
{
    public string GeneraToken(List<Claim> claims)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Secret"]!));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        var tokenDescriptor = new JwtSecurityToken(
            issuer: configuration["Jwt:Issuer"],
            audience: configuration["jwtAudience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(20),
            signingCredentials: credentials);

        var jwt = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);

        return jwt;
    }

    public string? TiempoRestanteToken()
    {
        string authorization = httpContextAccessor.HttpContext?.Request.Headers.Authorization!;
        if(string.IsNullOrEmpty(authorization) || !authorization.StartsWith("Bearer"))
            return null;

        JwtSecurityToken token = new JwtSecurityTokenHandler().ReadJwtToken(authorization[7..]);

        return token?.ValidTo.Subtract(DateTime.UtcNow).ToString(@"hh\:mm\:ss");
    }
}