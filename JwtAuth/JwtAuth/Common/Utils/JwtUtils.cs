using JwtAuth.Common.Helpers;
using JwtAuth.Data.Entity;
using JwtAuth.Data.Entity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JwtAuth.Common.Utils
{
    public static class JwtUtils
    {

        /// <summary>
        /// Token generator
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static string GenerateToken(ApplicationUserModel user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = KeyGenerator.Key;
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(ClaimTypes.Name, user.UserName)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
