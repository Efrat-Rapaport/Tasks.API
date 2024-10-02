using Dal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.Model;
using Dal.Models;

namespace link4u.Controllers
{
    [ApiController] 
    [Route("api/[controller]")] 
    public class TaskController : ControllerBase 
    {
        private readonly ITaskDal taskdal;
        private readonly IMapper imapper;

        public TaskController(ITaskDal itaskdal, IMapper imapper)
        {
            taskdal = itaskdal;
            this.imapper = imapper;
        }


        // GET api/task
        // GET: api/task
        [HttpGet]
        public async Task<ActionResult<List<TaskModel>>> GetAll()
        {
            var tasksList = await taskdal.GetAllTaskDal();
            return Ok(tasksList);
        }


        // POST api/task
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TaskModel newTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Return 400 if model is invalid
            }

            await taskdal.PostTaskDal(newTask);

            // Assuming newTask.Id is set after saving it to the database.
            return CreatedAtAction(nameof(GetAll), new { id = newTask.Id }, newTask); // Return 201 Created
        }


        // PUT api/task/{id}
        [HttpPut("{taskId}")]
        public async Task<ActionResult> Put(int taskId, [FromBody] TaskModel updateTask)
        {
            if (taskId != updateTask.Id)
            {
                return BadRequest();
            }

            await taskdal.PutTaskDal(updateTask);
            return NoContent();
        }

        // DELETE api/task/{id}
        [HttpDelete("{taskId}")]
        public async Task<ActionResult> Delete(int taskId)
        {
            await taskdal.DeleteTaskDal(taskId);
            return NoContent(); 
        }
    }
}