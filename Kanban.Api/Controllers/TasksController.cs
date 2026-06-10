using Kanban.Api.Data;
using Kanban.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kanban.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly AppDbContext _context;

    public TasksController(AppDbContext context)
    {
        _context = context;
    }

    // 1. GET /api/tasks → Listar todas las tareas
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TaskItem>>> GetTasks()
    {
        return await _context.TaskItems
                             .Include(t => t.User)
                             .OrderByDescending(t => t.FechaCreacion)
                             .ToListAsync();
    }

    // 2. GET /api/tasks/{id} → Obtener una tarea específica por su ID (Este es el que faltaba)
    [HttpGet("{id}")]
    public async Task<ActionResult<TaskItem>> GetTaskItem(int id)
    {
        var taskItem = await _context.TaskItems
                                     .Include(t => t.User)
                                     .FirstOrDefaultAsync(t => t.Id == id);

        if (taskItem == null)
        {
            return NotFound("Tarea no encontrada.");
        }

        return taskItem;
    }

    // 3. POST /api/tasks → Crear una nueva tarea
    [HttpPost]
    public async Task<ActionResult<TaskItem>> PostTaskItem(TaskItem taskItem)
    {
        if (taskItem.FechaCreacion == default)
        {
            taskItem.FechaCreacion = DateTime.UtcNow;
        }
        
        _context.TaskItems.Add(taskItem);
        await _context.SaveChangesAsync();

        // Ahora sí puede referenciar a GetTaskItem correctamente
        return CreatedAtAction(nameof(GetTaskItem), new { id = taskItem.Id }, taskItem);
    }

    // 4. PUT /api/tasks/{id} → Actualizar tarea (cambiar estado, título, etc.)
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTaskItem(int id, TaskItem taskItem)
    {
        if (id != taskItem.Id) return BadRequest("El ID de la URL no coincide con el ID del cuerpo.");

        var existingTask = await _context.TaskItems.FindAsync(id);
        if (existingTask == null) return NotFound("Tarea no encontrada.");

        existingTask.Titulo = taskItem.Titulo;
        existingTask.Descripcion = taskItem.Descripcion;
        existingTask.Estado = taskItem.Estado;
        existingTask.UserId = taskItem.UserId;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TaskItemExists(id)) return NotFound();
            else throw;
        }

        return NoContent();
    }

    // 5. DELETE /api/tasks/{id} → Eliminar tarea
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTaskItem(int id)
    {
        var taskItem = await _context.TaskItems.FindAsync(id);
        if (taskItem == null) return NotFound("Tarea no encontrada.");

        _context.TaskItems.Remove(taskItem);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // Método auxiliar
    private bool TaskItemExists(int id)
    {
        return _context.TaskItems.Any(e => e.Id == id);
    }
}