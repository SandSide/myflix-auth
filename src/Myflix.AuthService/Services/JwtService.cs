using Microsoft.AspNetCore.Authentication;
using Microsoft.CodeAnalysis.Elfie.Extensions;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Myflix.AuthService.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Myflix.AuthService.Services
{
    public class JwtService : ITokenService
    { 
        public string GenerateAuthToken(string username)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("x+RxEw(WF({0&y6$2zxvewrZ8{vfycB%._)!W+k_D8*n#d4(UpryY%T&CL3JDi)xJw)*iE6i?gb[.EnE9_F6RmCX=S@?xG]?rna%qAWH+R(TC?#!u97Zi/78bCBFA-_V"));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var expirationTimeStamp = DateTime.Now.AddMinutes(30);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, "User")
            };

            var tokenOptions = new JwtSecurityToken(
                issuer: "http://localhost:5002",
                claims: claims,
                expires: expirationTimeStamp,
                signingCredentials: signingCredentials
                );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return tokenString;
        }
    }
}
