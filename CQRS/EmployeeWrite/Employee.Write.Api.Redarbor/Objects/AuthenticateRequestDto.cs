using System.ComponentModel;

namespace Employee.Write.Api.Redarbor.Objects
{
    public class AuthenticateRequestDto
    {
        [DefaultValue("System")]
        public required string Username { get; set; }

        [DefaultValue("System")]
        public required string Password { get; set; }
    }
}
