using Microsoft.IdentityModel.Tokens;
using smart_street_backend.Model;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace smart_street_backend.Helpers
{
    public class Authetication
    {
        public string GenerateJsonToken(user user)
        {
            var s = Environment.GetEnvironmentVariable("Key");
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("Key")));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, user.username),
                new Claim(JwtRegisteredClaimNames.Email, user.email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),

            };
            var token = new JwtSecurityToken(Environment.GetEnvironmentVariable("Issuer"),
            Environment.GetEnvironmentVariable("Issuer"), claims,
            expires: DateTime.Now.AddDays(360),
            signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
