using System;
using System.Collections.Generic;

namespace Employee.Write.Domain.Redarbor.Entities;

public partial class EmployeeEntity
{
    public long Id { get; set; }

    public long CompanyId { get; set; }

    public string Email { get; set; } = null!;

    public string? Fax { get; set; }

    public string? Name { get; set; }

    public string? Lastlogin { get; set; }

    public string Password { get; set; } = null!;

    public long PortalId { get; set; }

    public long RoleId { get; set; }

    public long StatusId { get; set; }

    public string? Telephone { get; set; }

    public string Username { get; set; } = null!;

    public DateTime? UpdatedOn { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? DeletedOn { get; set; }

    public virtual CompanyEntity Company { get; set; } = null!;

    public virtual PortalEntity Portal { get; set; } = null!;

    public virtual RoleEntity Role { get; set; } = null!;

    public virtual StatusEntity Status { get; set; } = null!;
}
