using KanbanApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KanbanApp.Controllers
{
    [ApiController]
    [Route("tasks")]
    public class TasksController : ControllerBase
    {
        private readonly KanbanContext _context;
        public TasksController(KanbanContext context) => _context = context;

        [HttpGet]
        public async Task<IEnumerable<TaskItem>> GetTasks() =>
            await _context.Tasks.Include(t => t.User).ToListAsync();

        [HttpPost]
        public async Task<IActionResult> CreateTask(TaskItem task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return Ok(task);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null) return NotFound();

            task.Estado = task.Estado switch
            {
                "To Do" => "In Progress",
                "In Progress" => "Done",
                _ => task.Estado
            };

            await _context.SaveChangesAsync();
            return Ok(task);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null) return NotFound();

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
