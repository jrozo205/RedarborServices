using Employee.Write.Api.Redarbor.Helpers;
using Employee.Write.Api.Redarbor.Objects;
using Employee.Write.Application.Redarbor.DTOs;
using Employee.Write.Application.Redarbor.UseCases;
using Employee.Write.Domain.Redarbor.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Employee.Write.Api.Redarbor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IInsertEmployeeUseCase _insertEmployeeUseCase;
        private IUpdateEmployeeUseCase _updateEmployeeUseCase;
        private IDeleteEmployeeUseCase _deleteEmployeeUseCase;

        public EmployeeController(IInsertEmployeeUseCase insertEmployeeUseCase, IUpdateEmployeeUseCase updateEmployeeUseCase, IDeleteEmployeeUseCase deleteEmployeeUseCase) 
        {
            _insertEmployeeUseCase = insertEmployeeUseCase;
            _updateEmployeeUseCase = updateEmployeeUseCase;
            _deleteEmployeeUseCase = deleteEmployeeUseCase;
        }

        // POST api/<EmployeeController>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Post(CreateEmployeeRequestDto createEmployee)
        {
            try
            {
                if (createEmployee == null) return BadRequest();

                var result = await _insertEmployeeUseCase.ExecuteAsync(createEmployee.ConverToEmployeeDto());
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
            
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult> Put(long id, EmployeeDto employee)
        {
            try
            {
                if (id == 0) return BadRequest();

                employee.Id = id;
                var result = await _updateEmployeeUseCase.ExecuteAsync(employee);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> Delete(long id)
        {
            try
            {
                if (id == 0) return BadRequest(); 

                var result = await _deleteEmployeeUseCase.ExecuteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
