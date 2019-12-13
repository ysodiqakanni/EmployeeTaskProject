using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeTask.DomainModels;
using EmployeeTask.Services.Contracts;
using EmployeeTask.Services.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTask.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        IEmployeeService empService;

        public EmployeesController(IEmployeeService _emplService)
        {
            empService = _emplService; 
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var data = empService.GetAll();
            return Ok(data);
        }

        [HttpGet]
        [Route("{Id}")]
        public IActionResult GetById([FromRoute]int Id)
        {
            var employee = empService.GetEmployeeById(Id);
            if (employee == null)
                return NotFound();
            return Ok(employee);
        }

        [HttpPost] 
        public IActionResult AddEmployee([FromBody] Employee employee)
        {
            if (employee == null)
                return BadRequest("Request is null!");

            if (!ModelState.IsValid)
                return BadRequest("Data validation errors!");


            var response = empService.CreateNewEmployee(employee);

            return Ok(response);
        }

        [HttpPut]
        public IActionResult UpdateEmployee([FromBody]Employee emp)
        {
            if (emp == null)
                return BadRequest("Request is null!");

            if (!ModelState.IsValid)
                return BadRequest("Data validation errors!");
             
            emp.DateUpdated = DateTime.Now;

            var response = empService.UpdateEmployee(emp);
            return Ok(response);

        }
        [HttpGet]
        [Route("delete/{Id}")]
        public IActionResult DeleteEmployee([FromRoute]int Id)
        {
            var employee = empService.GetEmployeeById(Id);
            if (employee == null)
                return BadRequest();
            empService.DeleteEmployee(employee);
            return Ok(employee);
        }
    }
}