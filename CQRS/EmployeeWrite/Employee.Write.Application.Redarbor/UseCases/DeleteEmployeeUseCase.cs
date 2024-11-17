
using Employee.Write.Application.Redarbor.DTOs;
using Employee.Write.Domain.Redarbor.Interfaces;

namespace Employee.Write.Application.Redarbor.UseCases
{
    public interface IDeleteEmployeeUseCase
    {
        Task<bool> ExecuteAsync(long employeeId);
    }
    public class DeleteEmployeeUseCase : IDeleteEmployeeUseCase
    {
        private IEmployeeRepository _employeeRepository;

        public DeleteEmployeeUseCase(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<bool> ExecuteAsync(long employeeId)
        {
            var result = await _employeeRepository.DeleteEmployee(employeeId);
            return result;
        }
    }
}
