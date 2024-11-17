using Employee.Write.Domain.Redarbor.Entities;
using Employee.Write.Domain.Redarbor.Interfaces;
using Employee.Write.Infraestructure.Redarbor.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.Design;

namespace Employee.Write.Infraestructure.Redarbor.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private DbEmployeeContext _dbContext;

        public EmployeeRepository(DbEmployeeContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> DeleteEmployee(long employeeId)
        {
            var employee = await _dbContext.Employees.FindAsync(employeeId);
            var statusDeleted = await _dbContext.Statuses.FirstOrDefaultAsync(x=>x.Name.Equals("Deleted"));
            if (employee == null) return false;
            employee.DeletedOn = DateTime.Now;
            employee.StatusId = statusDeleted.Id;
            _dbContext.Employees.Update(employee);
            var result = await _dbContext.SaveChangesAsync();
            return result == 1;
        }

        public async Task<bool> InsertEmployee(EmployeeEntity employee)
        {
            employee.CreatedOn = DateTime.Now;
            var statusDeleted = await _dbContext.Statuses.FirstOrDefaultAsync(x => x.Name.Equals("Active"));
            employee.StatusId = statusDeleted.Id;
            _dbContext.Employees.Add(employee);
            var result = await _dbContext.SaveChangesAsync();
            return result == 1; 
        }

        public async Task<bool> UpdateEmployee(EmployeeEntity employee)
        {
            var employeeToUpdate = await _dbContext.Employees.FindAsync(employee.Id);
            if (employeeToUpdate == null) return false;
            
            if (!string.IsNullOrEmpty(employee.Name))
                employeeToUpdate.Name = employee.Name;

            if (!string.IsNullOrEmpty(employee.Password))
                employeeToUpdate.Password = employee.Password;

            if (employee.CompanyId > 0)
                employee.CompanyId = employee.CompanyId;

            if (employee.PortalId > 0)
                employee.PortalId = employee.PortalId;

            if (employee.RoleId > 0)
                employee.RoleId = employee.RoleId;

            if (!string.IsNullOrEmpty(employee.Telephone))
                employeeToUpdate.Telephone = employee.Telephone;

            if (!string.IsNullOrEmpty(employee.Username))
                employeeToUpdate.Username = employee.Username;

            employeeToUpdate.UpdatedOn = DateTime.Now;

            _dbContext.Employees.Update(employeeToUpdate);
            var result = await _dbContext.SaveChangesAsync();
            return result == 1;
        }
    }
}
