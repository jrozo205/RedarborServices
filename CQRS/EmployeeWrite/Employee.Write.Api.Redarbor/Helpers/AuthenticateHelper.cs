using Employee.Write.Api.Redarbor.Objects;
using Employee.Write.Application.Redarbor.DTOs;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Employee.Write.Api.Redarbor.Helpers
{
    public interface IAuthenticateHelper
    {
        Task<AuthenticateResponseDto?> Authenticate(AuthenticateRequestDto model);
        Task<UserDto> GetUserTest();
    }

    public class AuthenticateHelper : IAuthenticateHelper
    {
        private readonly string _jwtSecret;

        public AuthenticateHelper(IConfiguration configuration) 
        {
             _jwtSecret = configuration["Secret"].ToString();
        }

        public async Task<AuthenticateResponseDto?> Authenticate(AuthenticateRequestDto authRequest)
        {
            var user = await GetUserTest();

            if (!user.UserName.Equals(authRequest.Username)) return null;

            // authentication successful so generate jwt token
            var token = await GenerateJwtToken(user);

            return new AuthenticateResponseDto(user.Name, user.UserName, token);
        }

        private async Task<string> GenerateJwtToken(UserDto user)
        {
            //Generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = await Task.Run(() =>
            {

                var key = Encoding.ASCII.GetBytes(_jwtSecret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                return tokenHandler.CreateToken(tokenDescriptor);
            });

            return tokenHandler.WriteToken(token);
        }

        public Task<UserDto> GetUserTest() 
        {
            return Task.FromResult(new UserDto
            {
                Id = 1,
                Name = "System",
                UserName = "System"
            });
        }
    }
}
