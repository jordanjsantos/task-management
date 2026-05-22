using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Api.Persistence;

namespace TaskManagement.Api.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TaskController : ControllerBase
    {
        private readonly TaskDbContext _dbContext;

        public TaskController(TaskDbContext dbContext) {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Entities.Task>>> FindAll()
        {
            var tasks = await _dbContext.Tasks.ToListAsync();

            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Entities.Task>> FindById(int id)
        {
            var task = await _dbContext.Tasks.FindAsync(id);

            if (task is null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Entities.Task task)
        {
            _dbContext.Tasks.Add(task);

            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(FindById), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Entities.Task updatedTask)
        {
            var task = await _dbContext.Tasks.FindAsync(id);

            if (task is null)
            {
                return NotFound();
            }

            task.Title = updatedTask.Title;
            task.Description = updatedTask.Description;
            task.Status = updatedTask.Status;

            await _dbContext.SaveChangesAsync();

            return Ok(task);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var task = await _dbContext.Tasks.FindAsync(id);

            if (task is null)
            {
                return NotFound();
            }

            _dbContext.Tasks.Remove(task);

            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
