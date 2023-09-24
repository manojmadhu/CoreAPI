using CoreAPI.Model;
using CoreAPI.Repository;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles ="Admin")]
        public async Task<ActionResult> Get()
        {
            var employees = await _employeeRepository.GetAll();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        [Authorize(Roles ="Admin,Employee")]
        public IActionResult GetEmployee(int id)
        {
            Employee employee = _employeeRepository.GetById(id);
            return Ok(employee);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Post([FromBody] Employee employee)
        {
            int id = _employeeRepository.Add(employee);
            return Ok(id);
        }
    }
}
