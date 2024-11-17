
using Employee.Write.Application.Redarbor.DTOs;
using Employee.Write.Domain.Redarbor.Entities;
using Employee.Write.Domain.Redarbor.Interfaces;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace Employee.Write.Application.Redarbor.UseCases
{
    public interface IUpdateEmployeeUseCase
    {
        Task<bool> ExecuteAsync(EmployeeDto employee);
    }

    public class UpdateEmployeeUseCase : IUpdateEmployeeUseCase
    {
        private IEmployeeRepository _employeeRepository;

        public UpdateEmployeeUseCase(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }   

        public async Task<bool> ExecuteAsync(EmployeeDto employee)
        {
            string? password = !string.IsNullOrEmpty(employee.Password) ? EncryptPassword(employee.Password) : employee.Password;
            var employeeEntity = new EmployeeEntity()
            {
                Id = employee.Id,
                CompanyId = employee.CompanyId,
                Email = employee.Email,
                Fax = employee.Fax,
                Lastlogin = employee.Lastlogin,
                Password = password,
                Name = employee.Name,
                PortalId = employee.PortalId,
                RoleId = employee.RoleId,
                Telephone = employee.Telephone,
                Username = employee.Username,
            };
            var result = await _employeeRepository.UpdateEmployee(employeeEntity);
            return result;
        }

        private static string EncryptPassword(string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(128 / 8);
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password!,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
            return hashed;
        }
    }
}
