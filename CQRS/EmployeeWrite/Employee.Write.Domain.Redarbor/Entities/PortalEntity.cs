using System;
using System.Collections.Generic;

namespace Employee.Write.Domain.Redarbor.Entities;

public partial class PortalEntity
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<EmployeeEntity> Employees { get; set; } = new List<EmployeeEntity>();
}
