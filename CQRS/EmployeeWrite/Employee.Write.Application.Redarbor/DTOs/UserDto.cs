
using System.Text.Json.Serialization;

namespace Employee.Write.Application.Redarbor.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string UserName { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
    }
}
