using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Employee.Write.Api.Redarbor.Helpers
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _jwtSecret;

        public JwtMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _jwtSecret = configuration["Secret"].ToString();
        }

        public async Task Invoke(HttpContext context, IAuthenticateHelper authenticateHelper)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
                await attachUserToContext(context, authenticateHelper, token);

            await _next(context);
        }

        private async Task attachUserToContext(HttpContext context, IAuthenticateHelper authenticateHelper, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_jwtSecret);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

                context.Items["User"] = await authenticateHelper.GetUserTest();
            }
            catch
            {
                //Do nothing if JWT validation fails
                // user is not attached to context so the request won't have access to secure routes
            }
        }
    }
}
