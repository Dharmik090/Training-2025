using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DemoAPI
{
    /// <summary>
    /// Helper class responsible for generating JSON Web Tokens (JWT)
    /// for authentication and authorization purposes.
    /// </summary>
    public static class JwtTokenHelper
    {
        /// <summary>
        /// Generates a JWT token for the specified user.
        /// </summary>
        /// <param name="username">The username included in the token.</param>
        /// <param name="role">The user role included in the token.</param>
        /// <returns>A JWT token string valid for 30 minutes.</returns>
        public static string GenerateToken(string username, string role)
        {

            SymmetricSecurityKey key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("some_very_long_secret_key_1234567"));


            SigningCredentials creds =
                new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


            Claim[] claims = new Claim[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, role)
            };

            JwtSecurityToken token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: creds);

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }
    }
}

