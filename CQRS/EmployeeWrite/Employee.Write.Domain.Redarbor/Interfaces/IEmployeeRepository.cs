using Employee.Write.Domain.Redarbor.Entities;

namespace Employee.Write.Domain.Redarbor.Interfaces
{
   public interface IEmployeeRepository
    {
        Task<bool> InsertEmployee(EmployeeEntity employee);
        Task<bool> UpdateEmployee(EmployeeEntity employee);
        Task<bool> DeleteEmployee(long employeeId);
    }
}
