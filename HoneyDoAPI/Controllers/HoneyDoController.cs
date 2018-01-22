using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HoneyDo.Data;
using HoneyDo.Data.Entity;
using HoneyDoAPI.Model;
using HoneyDoAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HoneyDoAPI.Controllers
{
    [Route("api/[controller]")]
    public class HoneyDoController : Controller
    {

        private readonly IHoneyDoService _service = null;
        
        public HoneyDoController(HoneyDoContext context)
        {
            _service = new HoneyDoService(context);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<HoneyDoTaskView> tasks = _service.GetTasks();
            if (tasks != null)
                return Ok(tasks);

            return NotFound();
        }

        [HttpGet("{id}", Name = "GetSingleHoneyDoTask")]
        public IActionResult GetById(int id)
        {
            HoneyDoTaskView task = _service.GetTask(id);
            if (task != null)
                return Ok(task);

            return NotFound();
        }

        [HttpPost]
        public IActionResult Create([FromBody] HoneyDoTaskView task)
        {
            if (task == null)
                return BadRequest();

            task = _service.AddTask(task);
            if (task == null)
                return BadRequest();

            return CreatedAtRoute("GetSingleHoneyDoTask", new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] HoneyDoTaskView task)
        {
            if (task == null || task.Id != id)
            {
                return BadRequest();
            }

            _service.UpdateTask(id,task);

            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.DeleteTask(id);
            return new NoContentResult();
        }

        [Route("seed")]
        [HttpGet]
        public IActionResult GetAllSeeded()
        {
            List<HoneyDoTaskView> tasks = _service.GetSeededTasks();
            if (tasks != null)
                return Ok(tasks);

            return NotFound();
        }
    }
}