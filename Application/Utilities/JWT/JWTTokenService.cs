#region Usings
using Domain.Entities;

using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace Application.Utilities.JWT;

public static class JWTTokenService
{


    //Generate Access Token
    public static async Task<string> GenerateToken(User user, IConfiguration _configuration)
    {

        var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWTSettings:Key"]));
        var credential = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);

        var Claims = new List<Claim>()
        {

            new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Name,user.FullName),

                    new Claim(JwtRegisteredClaimNames.Sub,user.PhoneNumber),

        };

        var Token = new JwtSecurityToken(
            issuer: _configuration["JWTSettings:Issuer"],
            audience: _configuration["JWTSettings:Audience"],
            claims: Claims,
            expires: DateTime.Now.AddHours(Convert.ToInt32(_configuration["JWTSettings:Duration"])),
            signingCredentials: credential
            );


        return new JwtSecurityTokenHandler().WriteToken(Token);

    }


    // روش تولید Refresh Token
    public static string GenerateRefreshToken()
    {
        return Guid.NewGuid().ToString(); // تولید یک رشته یکتا
    }


}
