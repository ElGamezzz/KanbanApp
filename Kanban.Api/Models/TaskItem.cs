namespace Kanban.Api.Models;

public class TaskItem
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    public EstadoTarea Estado { get; set; } = EstadoTarea.ToDo;
    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

    // Clave foránea para la relación con User
    public int UserId { get; set; }
    public User? User { get; set; }
}

// Enum para los estados del Kanban
public enum EstadoTarea
{
    ToDo,
    InProgress,
    Done
}