using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeTask.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTask.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeeTasksController : ControllerBase
    {
        IEmployeeTaskService svc; 
        public EmployeeTasksController(IEmployeeTaskService _svc)
        {
            svc = _svc;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var data = svc.GetAll();
            return Ok(data);
        }

        [HttpGet]
        [Route("{Id}")]
        public IActionResult GetById([FromRoute]int Id)
        {
            var task = svc.GetEmployeeTaskById(Id);
            if (task == null)
                return NotFound();
            return Ok(task);
        }

        [HttpPost] 
        public IActionResult AddTask([FromBody] DomainModels.EmployeeTask task)
        {
            if (task == null)
                return BadRequest("Request is null!");
            if (task.EmployeeId <= 0)
                return BadRequest("Invalid Employee selected!");

            if (!ModelState.IsValid)
                return BadRequest("Data validation errors!");

            try
            {

                var response = svc.CreateNewTask(task);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateEmployeeTask([FromBody]DomainModels.EmployeeTask task)
        {
            if (task == null)
                return BadRequest("Request is null!");

            if (!ModelState.IsValid)
                return BadRequest("Data validation errors!");

            task.DateUpdated = DateTime.Now;

            var response = svc.UpdateEmployeeTask(task);
            return Ok(response);

        }
        [HttpGet]
        [Route("delete/{Id}")]
        public IActionResult DeleteEmployeeTask([FromRoute]int Id)
        {
            var task = svc.GetEmployeeTaskById(Id);
            if (task == null)
                return BadRequest();
            svc.DeleteEmployeeTask(task);
            return Ok(task);
        }
    }
}