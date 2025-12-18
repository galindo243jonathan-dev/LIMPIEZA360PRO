namespace Limpieza360Pro.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public bool Completada { get; set; }
        public int PropertyId { get; set; }
        public Property Property { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}