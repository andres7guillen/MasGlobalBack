using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
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

        [HttpGet("{id}")]
        public async Task<IActionResult> getEmployeeById(int id)
        {
            var result = await _service.getEmployeeById(id);
            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpGet("GetEmployees")]
        public async Task<IActionResult> getEmployees()
        {
            var result = await _service.getEmployees();
            return Ok(result);
        }

        [HttpGet("getEmployeesByHourlySalary")]
        public async Task<IActionResult> getEmployeesByHourlySalary()
        {
            var result = await _service.getEmployeesByHourlySalary();
            return Ok(result);
        }

        [HttpGet("getEmployeesByMonthlySalary")]
        public async Task<IActionResult> getEmployeesByMonthlySalary()
        {
            var result = await _service.getEmployeesByMonthlySalary();
            return Ok(result);
        }

    }
}