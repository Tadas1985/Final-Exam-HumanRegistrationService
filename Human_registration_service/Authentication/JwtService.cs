using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
namespace Human_Registration_Service.Authentication

{
    
    public class JwtService: IJwtService
    {
        private readonly IConfiguration _configuration;
        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GetJwtToken(string username, string role)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,username),
                new Claim(ClaimTypes.Role, role)
            };
            var secretToken = _configuration.GetSection("Jwt:Key").Value;
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(secretToken));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                issuer: "https://localhost:44339/",
                audience: "https://localhost:44339/",
                claims: claims,
                expires: System.DateTime.Now.AddDays(1),
                signingCredentials: cred);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
