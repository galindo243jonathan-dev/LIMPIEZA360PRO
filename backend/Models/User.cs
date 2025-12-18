using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Limpieza360Pro.Models
{
    public class User : IdentityUser
    {
        public string Rol { get; set; } // Dueño, Manager, Empleado
        public ICollection<Property> Properties { get; set; }
        public ICollection<Task> Tasks { get; set; }
        public ICollection<Reminder> Reminders { get; set; }
    }
}