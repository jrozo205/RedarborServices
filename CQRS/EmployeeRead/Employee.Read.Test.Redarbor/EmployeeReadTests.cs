using Employee.Read.Api.Redarbor.Controllers;
using Employee.Read.Application.Redarbor.DTOs;
using Employee.Read.Application.Redarbor.UseCases;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Employee.Read.Test.Redarbor
{
    public class EmployeeReadTests
    {
        private Mock<IGetEmployeeByIdUserCase> _mockGetEmployeeByIdUserCasee;
        private Mock<IGetEmployeesUserCase> _mockGetEmployeesUserCase;
        private EmployeeController _controller;

        [SetUp]
        public void Setup()
        {
            _mockGetEmployeeByIdUserCasee = new Mock<IGetEmployeeByIdUserCase>();
            _mockGetEmployeesUserCase = new Mock<IGetEmployeesUserCase>();
            _controller = new EmployeeController(_mockGetEmployeeByIdUserCasee.Object,
                                                 _mockGetEmployeesUserCase.Object);
        }

        [Test]
        public async Task GetAllEmployees_ReturnsOk_WithListOfEmployees()
        {
            var employees = new List<EmployeeDto>
                {
                    new() { Name = "Pancho Villa", Email = "pancho.villa@example.com" },
                    new() { Name = "Juana de Arco", Email = "juana.arco@example.com" }
                };

            _mockGetEmployeesUserCase.Setup(s => s.ExecuteAsync()).ReturnsAsync(employees);

            var result = await _controller.Get();

            Assert.That(result, Is.InstanceOf<ActionResult<IEnumerable<EmployeeDto>>>());           
            var okResult = result as ActionResult<IEnumerable<EmployeeDto>>;
            Assert.That(okResult, Is.Not.Null);
        }

        [Test]
        public async Task GetEmployeeById_ReturnsOk_WithEmployee()
        {
            var employee = new EmployeeDto { Id = 1, Name = "Pancho Villa", Email = "pancho.villa@example.com" };
            _mockGetEmployeeByIdUserCasee.Setup(s => s.ExecuteAsync(1)).ReturnsAsync(employee);

            var result = await _controller.Get(1);

            Assert.That(result, Is.InstanceOf<ActionResult<EmployeeDto>>());
            var okResult = result as ActionResult<EmployeeDto>;
            Assert.That(okResult, Is.Not.Null);
        }
    }
}