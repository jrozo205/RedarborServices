
using Employee.Read.Domain.Redarbor.Entities;

namespace Employee.Read.Application.Redarbor.DTOs
{
    public class EmployeeDto
    {
        public long Id { get; set; }
        public long CompanyId { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public string Name { get; set; }
        public string Lastlogin { get; set; }
        public string Password { get; set; }
        public long PortalId { get; set; }
        public long RoleId { get; set; }
        public int StatusId { get; set; }
        public string Telephone { get; set; }
        public string Username { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime DeletedOn { get; set; }

        public EmployeeDto() { }
        public EmployeeDto(EEmployee employee) 
        {
            Id = employee.Id;
            Name = employee.Name;
            CompanyId = employee.CompanyId;
            Fax = employee.Fax;
            Email = employee.Email;
            Lastlogin = employee.Lastlogin;
            Password = employee.Password;
            PortalId = employee.PortalId;
            RoleId = employee.RoleId;
            StatusId = employee.StatusId;
            Telephone = employee.Telephone;
            Username = employee.Username;
            UpdatedOn = employee.UpdatedOn;
            CreatedOn = employee.CreatedOn;
            DeletedOn = employee.DeletedOn;
        }
    }
}
