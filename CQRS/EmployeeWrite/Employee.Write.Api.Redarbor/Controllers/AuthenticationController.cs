using Employee.Write.Api.Redarbor.Helpers;
using Employee.Write.Api.Redarbor.Objects;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Write.Api.Redarbor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IAuthenticateHelper _authenticateHelper;

        public AuthenticationController(IAuthenticateHelper authenticateHelper) 
        {
            _authenticateHelper = authenticateHelper;
        }


        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(AuthenticateRequestDto authRequest)
        {
            var response = await _authenticateHelper.Authenticate(authRequest);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }


    }
}
