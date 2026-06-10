namespace KanbanApp.Models
{
    public class TaskItem
    {
        public int Id { get; set; }                // Identificador único
        public required string Titulo { get; set; }         // Nombre corto de la tarea
        public required string Descripcion { get; set; }    // Detalle de la tarea
        public string Estado { get; set; } = "To Do"; // Estado inicial
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        // Relación con Usuario
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
