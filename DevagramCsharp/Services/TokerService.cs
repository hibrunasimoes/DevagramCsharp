using System;
using DevagramCsharp.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.IdentityModel;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace DevagramCsharp.Services
{
    public class TokerService
    {
        public static string CreatToken (User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var keyCryptography = Encoding.ASCII.GetBytes(KeyJWT.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Sid, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Name)

                }),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keycryptography), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}

