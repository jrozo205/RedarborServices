using System;
using System.Collections.Generic;

namespace Employee.Write.Domain.Redarbor.Entities;

public partial class RoleEntity
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<EmployeeEntity> Employees { get; set; } = new List<EmployeeEntity>();
}
