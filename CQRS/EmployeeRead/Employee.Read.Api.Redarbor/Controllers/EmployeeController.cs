using Employee.Read.Application.Redarbor.DTOs;
using Employee.Read.Application.Redarbor.UseCases;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Employee.Read.Api.Redarbor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IGetEmployeeByIdUserCase _getEmployeeByIdUserCase;
        private readonly IGetEmployeesUserCase _getEmployeesUserCase;

        public EmployeeController(IGetEmployeeByIdUserCase getEmployeeByIdUserCase, IGetEmployeesUserCase getEmployeesUserCase) 
        {
            _getEmployeeByIdUserCase = getEmployeeByIdUserCase;
            _getEmployeesUserCase = getEmployeesUserCase;
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> Get()
        {
            try
            {
                var result = await _getEmployeesUserCase.ExecuteAsync();
                if (result == null) return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDto>> Get(int id)
        {
            try
            {
                var result = await _getEmployeeByIdUserCase.ExecuteAsync(id);
                if (result == null) return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
