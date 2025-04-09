using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Infrastructure.Utils
{
    public class JwtService
    {
        public static string Generate(User user, IConfiguration configuration)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_KEY") ?? configuration["Jwt:Key"]!));
            var issuer = Environment.GetEnvironmentVariable("JWT_ISSUER") ?? configuration["Jwt:Issuer"];
            var audience = Environment.GetEnvironmentVariable("JWT_AUDIENCE") ?? configuration["Jwt:Audience"];
            var jwtExpireMinutes = Environment.GetEnvironmentVariable("JWT_EXPIRATION_IN_MINUTES") ?? configuration["Jwt:ExpirationInMinutes"] ?? "60";

            var expires = DateTime.UtcNow.AddMinutes(int.Parse(jwtExpireMinutes));

            IEnumerable<Claim> claims =
            [
                new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new(ClaimTypes.Email, user.Email!),
                new(ClaimTypes.Role, user.RoleName!),
                new(ClaimTypes.Name, user.FullName!),
            ];

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Issuer = issuer,
                Audience = audience,
                Expires = expires,
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public static ClaimsPrincipal GetPrincipalFromToken(string token, IConfiguration configuration)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_KEY") ?? configuration["Jwt:Key"]!);

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = false
            };

            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken);

            if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token!");

            return principal;
        }
    }
}