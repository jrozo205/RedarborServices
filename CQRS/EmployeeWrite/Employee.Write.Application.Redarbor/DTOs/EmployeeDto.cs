
using Newtonsoft.Json;

namespace Employee.Write.Application.Redarbor.DTOs
{
    public class EmployeeDto
    {
        public long Id { get; set; }
        public long CompanyId { get; set; }
        public string? Email { get; set; }
        public string? Fax { get; set; }
        public string? Name { get; set; }
        public string? Lastlogin { get; set; }
        public string? Password { get; set; }
        public long PortalId { get; set; }
        public long RoleId { get; set; }
        public long StatusId { get; set; }
        public string? Telephone { get; set; }
        public string? Username { get; set; }
        public string? UpdatedOn { get; set; }
        public string? CreatedOn { get; set; }
        public string? DeletedOn { get; set; }

    }
}
