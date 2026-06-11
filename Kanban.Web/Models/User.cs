namespace Kanban.Web.Models;
public class User
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Correo { get; set; } = string.Empty;

    // Relación: Un usuario tiene muchas tareas
    public ICollection<TaskItem> Tareas { get; set; } = new List<TaskItem>();
}