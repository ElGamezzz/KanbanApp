namespace KanbanApp.Models
{
    public class User
    {
        public int Id { get; set; }                 // Identificador único
        public required string Nombre { get; set; }          // Nombre del usuario
        public required string Correo { get; set; }          // Email del usuario

        // Relación: un usuario puede tener varias tareas
        public required ICollection<TaskItem> Tasks { get; set; }
    }
}
