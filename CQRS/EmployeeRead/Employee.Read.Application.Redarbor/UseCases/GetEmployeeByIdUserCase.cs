
using Employee.Read.Application.Redarbor.DTOs;
using Employee.Read.Domain.Redarbor.Interfaces;

namespace Employee.Read.Application.Redarbor.UseCases
{
    public interface IGetEmployeeByIdUserCase 
    {
        Task<EmployeeDto> ExecuteAsync(long employeeId);
    }

    public class GetEmployeeByIdUserCase : IGetEmployeeByIdUserCase
    {
        private IEmployeeRepository _employeeRepository;

        public GetEmployeeByIdUserCase(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<EmployeeDto> ExecuteAsync(long employeeId)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(employeeId);
            if (employee == null) return null;

            return new EmployeeDto(employee);
        }
    }
}
