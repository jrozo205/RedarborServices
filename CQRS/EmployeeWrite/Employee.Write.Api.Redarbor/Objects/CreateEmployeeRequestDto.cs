using Employee.Write.Application.Redarbor.DTOs;
using System.ComponentModel.DataAnnotations;

namespace Employee.Write.Api.Redarbor.Objects
{
    public class CreateEmployeeRequestDto
    {
        public long Id { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than 0")]
        public long CompanyId { get; set; }
        public string Email { get; set; }
        public string? Fax { get; set; }
        public string? Name { get; set; }
        public string? Lastlogin { get; set; }
        public string Password { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than 0")]
        public long PortalId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than 0")]
        public long RoleId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than 0")]
        public long StatusId { get; set; }
        public string? Telephone { get; set; }
        public string Username { get; set; }
        public string? UpdatedOn { get; set; }
        public string? CreatedOn { get; set; }
        public string? DeletedOn { get; set; }

        public EmployeeDto ConverToEmployeeDto() 
        {
            return new EmployeeDto
            {
                Id = this.Id,
                Name = this.Name,
                CompanyId = this.CompanyId,
                Fax = this.Fax,
                Email = this.Email,
                Lastlogin = this.Lastlogin,
                Password = this.Password,
                PortalId = this.PortalId,
                RoleId = this.RoleId,
                StatusId = this.StatusId,
                Telephone = this.Telephone,
                Username = this.Username,
                UpdatedOn = this.UpdatedOn,
                CreatedOn = this.CreatedOn,
                DeletedOn = this.DeletedOn
            };
        }
    }
}
