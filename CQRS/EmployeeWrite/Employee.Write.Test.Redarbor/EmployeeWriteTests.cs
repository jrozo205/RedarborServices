using Employee.Write.Api.Redarbor.Controllers;
using Employee.Write.Api.Redarbor.Objects;
using Employee.Write.Application.Redarbor.DTOs;
using Employee.Write.Application.Redarbor.UseCases;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Employee.Write.Test.Redarbor
{
    public class EmployeeWriteTests
    {
        private Mock<IInsertEmployeeUseCase> _mockInsertEmployeeUseCase;
        private Mock<IUpdateEmployeeUseCase> _mockUpdateEmployeeUseCase;
        private Mock<IDeleteEmployeeUseCase> _mockDeleteEmployeeUseCase;
        private EmployeeController _controller;

        [SetUp]
        public void Setup()
        {
            _mockInsertEmployeeUseCase = new Mock<IInsertEmployeeUseCase>();
            _mockUpdateEmployeeUseCase = new Mock<IUpdateEmployeeUseCase>();
            _mockDeleteEmployeeUseCase = new Mock<IDeleteEmployeeUseCase>();
            _controller = new EmployeeController(_mockInsertEmployeeUseCase.Object,
                                                 _mockUpdateEmployeeUseCase.Object, 
                                                 _mockDeleteEmployeeUseCase.Object);
        }

        [Test]
        public async Task CreateEmployee_ReturnsOk_WhenEmployeeIsCreated()
        {
            var Createemployee = new CreateEmployeeRequestDto { Name = "Pancho Villa", Email = "pancho.villa@example.com" };
            var employee = new EmployeeDto { Name = "Pancho Villa", Email = "pancho.villa@example.com" };
            _mockInsertEmployeeUseCase.Setup(s => s.ExecuteAsync(employee)).ReturnsAsync(true);

            var result = await _controller.Post(Createemployee);

            Assert.That(result, Is.InstanceOf<OkResult>());
        }

        [Test]
        public async Task CreateEmployee_ReturnsBadRequest_WhenEmployeeIsNull()
        {
            var result = await _controller.Post(null);
            Assert.That(result, Is.InstanceOf<BadRequestResult>());
        }

        [Test]
        public async Task UpdateEmployee_ReturnsOk_WhenEmployeeIsUpdated()
        {
            var employee = new EmployeeDto { Id = 1, Name = "Juana de Arco", Email = "juana.arco@example.com" };
            _mockUpdateEmployeeUseCase.Setup(s => s.ExecuteAsync(employee)).ReturnsAsync(true);

            var result = await _controller.Put(1, employee);

            Assert.That(result, Is.InstanceOf<OkResult>());
        }

        [Test]
        public async Task UpdateEmployee_ReturnsBadRequest_WhenDataIsInvalid()
        {
            // Act
            var result = await _controller.Put(0, null);

            // Assert
            Assert.That(result, Is.InstanceOf<BadRequestResult>());
        }

        [Test]
        public async Task DeleteEmployee_ReturnsOk_WhenEmployeeIsDeleted()
        {
            _mockDeleteEmployeeUseCase.Setup(s => s.ExecuteAsync(1)).ReturnsAsync(true);

            var result = await _controller.Delete(1);

            Assert.That(result, Is.InstanceOf<OkResult>());
        }

        [Test]
        public async Task DeleteEmployee_ReturnsBadRequest_WhenIdIsInvalid()
        {
            var result = await _controller.Delete(0);

            Assert.That(result, Is.InstanceOf<BadRequestResult>());
        }
    }
}