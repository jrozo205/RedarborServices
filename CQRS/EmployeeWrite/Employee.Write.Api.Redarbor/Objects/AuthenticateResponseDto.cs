namespace Employee.Write.Api.Redarbor.Objects
{
    public class AuthenticateResponseDto
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }

        public AuthenticateResponseDto(string name, string userName, string token)
        {
            Name = name;
            UserName = userName;
            Token = token;
        }
    }
}
