using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Timesheets.Service.Authentication
{
    public class UserService : IUserService
    {
        private readonly IDictionary<string, AuthResponse> _users = new Dictionary<string, AuthResponse>
        {
            {"test", new AuthResponse { Password = "test"}}
    	};

    	public static readonly string SecretCode = "THIS IS SOME VERY SECRET STRING!!! Geek brains project";

    	public TokenResponse Authenticate(string user, string password)
    	{
        	if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(password))
        	{
                return null;
        	}
            var tokenResponse = new TokenResponse();	
            var i = 0;	
            foreach (var pair in _users)
        	{
                i++;
                if (string.CompareOrdinal(pair.Key, user) != 0 ||
                    string.CompareOrdinal(pair.Value.Password, password) != 0) continue;
                tokenResponse.Token = GenerateJwtToken(i, 1); 
                var refreshToken = GenerateRefreshToken(i);
                pair.Value.LatestRefreshToken = refreshToken; 
                tokenResponse.RefreshToken = refreshToken.Token;
                return tokenResponse;
            }
            return null;
    	}
    	public string RefreshToken(string token)
    	{
            var i = 0;
            foreach (var (_, value) in _users)
        	{
                i++;
                if (string.CompareOrdinal(value.LatestRefreshToken.Token, token) != 0 ||
                    value.LatestRefreshToken.IsExpired is not false) continue;
                value.LatestRefreshToken = GenerateRefreshToken(i);
                return value.LatestRefreshToken.Token;
            }
            return string.Empty;
    	}
        private string GenerateJwtToken(int id, int minutes)
    	{
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(SecretCode);

            var tokenDescriptor = new SecurityTokenDescriptor
        	{
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, id.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(minutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        	};
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
    	}

    	public RefreshToken GenerateRefreshToken(int id)
    	{
            var refreshToken = new RefreshToken
            {
	            Expires = DateTime.Now.AddMinutes(360),
	            Token = GenerateJwtToken(id, 360)
            };
            return refreshToken;
    	}
    }
}