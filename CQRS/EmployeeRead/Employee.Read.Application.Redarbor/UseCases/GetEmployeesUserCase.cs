
using Employee.Read.Application.Redarbor.DTOs;
using Employee.Read.Domain.Redarbor.Interfaces;

namespace Employee.Read.Application.Redarbor.UseCases
{
    public interface IGetEmployeesUserCase 
    {
        Task<IEnumerable<EmployeeDto>> ExecuteAsync();
    }


    public class GetEmployeesUserCase : IGetEmployeesUserCase
    {
        private IEmployeeRepository _employeeRepository;

        public GetEmployeesUserCase(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<IEnumerable<EmployeeDto>> ExecuteAsync()
        {
            var result = await _employeeRepository.GetEmployeesAsync();
            if(result == null) return null;

            return result.Select(x => new EmployeeDto(x));

        }
    }
}
