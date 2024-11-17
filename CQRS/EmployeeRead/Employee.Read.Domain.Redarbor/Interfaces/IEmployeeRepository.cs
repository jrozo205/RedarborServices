
using Employee.Read.Domain.Redarbor.Entities;

namespace Employee.Read.Domain.Redarbor.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EEmployee>> GetEmployeesAsync();
        Task<EEmployee> GetEmployeeByIdAsync(long employeeId);
    }
}
