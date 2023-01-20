using EmployeesDapper.Model;
using EmployeesDapper.Services;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace EmployeesDapper.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeService _service;

        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }

        [HttpPost("Post")]
        public async Task<IActionResult> CreateEmployee(Employee employee)
        {
            await _service.CreateEmployeeAsync(employee);
            return Ok();
        }


        [HttpGet("Get")]
        public async Task<IActionResult> GetAllEmployees()
        {
           return Ok(await _service.GetAllEmployeesAsync());
        }


        [HttpGet("GetID")]
        public async Task<IActionResult> GetEmployeeByID(int id)
        {
            return Ok(await _service.GetEmployeeByIDAsync(id));
        }


        [HttpPut("Put")]
        public async Task<IActionResult> UpdateEmployee(int id, Employee employee)
        {
            await _service.UpdateEmployeeAsync(id, employee);
            return Ok();
        }


        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _service.DeleteEmployeeAsync(id);
            return Ok();
        }


    }


}
