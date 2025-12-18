using System.Collections.Generic;

namespace Limpieza360Pro.Models
{
    public class Property
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public ICollection<Task> Tasks { get; set; }
        public ICollection<Inventory> Inventories { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}