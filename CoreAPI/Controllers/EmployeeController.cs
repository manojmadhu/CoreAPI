using CoreAPI.Model;
using CoreAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CoreAPI.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IDataHandlerRepository<Employee> _employeeRepository;

        public EmployeeController(IDataHandlerRepository<Employee> dataHandlerRepository)
        {
            _employeeRepository = dataHandlerRepository;
        }

        [HttpGet("GetAllEmployees")]
        public async Task<ActionResult> Get()
        {
            var employees = await _employeeRepository.GetAll();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployee(int id)
        {
            Employee employee = _employeeRepository.GetById(id);
            return Ok(employee);
        }
    }
}
