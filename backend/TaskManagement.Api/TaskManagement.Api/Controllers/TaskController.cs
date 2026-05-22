using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using TaskManagement.Api.Entities;
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
    }
}
