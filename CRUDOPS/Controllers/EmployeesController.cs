using CRUDOPS.EmployeeData;
using CRUDOPS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDOPS.Controllers
{   
    [ApiController]
    [Route("api")]
    public class EmployeesController : ControllerBase
    {
        private IEmployeeData _employeeData;
        private readonly JwtAuthManager jwtAuthManager;

        public EmployeesController(IEmployeeData employeeData,JwtAuthManager jwtAuthManager)
        {
            _employeeData = employeeData;
            this.jwtAuthManager = jwtAuthManager;
        }

        [Authorize]
        [HttpGet]
        [Route("[controller]")]
        public IActionResult GetEmployees()
        {
            return Ok(_employeeData.GetEmployees());
        }

        [Authorize]
        [HttpGet]
        [Route("[controller]/{id}")]

        public IActionResult GetEmployee(Guid id)
        {
            var employee = _employeeData.GetEmployee(id);
            if (employee != null)
            {
                return Ok(employee);
            }
            return NotFound($"Employee with id: {id} was not found");
        }
        [Authorize]
        [HttpPost]
        [Route("[controller]")]
        public IActionResult GetEmployee(Employee employee)
        {
            _employeeData.CreateEmployee(employee);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + employee.Id,employee);
        }

        [Authorize]
        [HttpDelete]
        [Route("[controller]/{id}")]

        public IActionResult DeleteEmployee(Guid id)
        {
            var employee = _employeeData.GetEmployee(id);
            if (employee != null)
            {
                _employeeData.DeleteEmployee(employee);
                return Ok($"Employee with id: {id} was deleted successfully");
            }
            return NotFound($"Employee with id: {id} was not found");
        }

        [Authorize]
        [HttpPatch]
        [Route("[controller]/{id}")]

        public IActionResult UpdateEmployee(Guid id, Employee employee)
        {
            var existingEmployee = _employeeData.GetEmployee(id);
            if (existingEmployee != null)
            {
                employee.Id =existingEmployee.Id;
                _employeeData.UpdateEmployee(employee);
                return Ok($"Employee with id: {id} was updated successfully");
            }
            return NotFound($"Employee with id: {id} was not found");
        }

        [HttpPost("authorize")]
        public IActionResult AuthUser([FromBody] User user)
        {
            var token = jwtAuthManager.authenticate(user.username!,user.password!);
            if(token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }

    }
    public class User
    {
        public string? username { get; set; }
        public string? password { get; set; }
    }
}
