using System;

namespace Limpieza360Pro.Models
{
    public class Reminder
    {
        public int Id { get; set; }
        public string Mensaje { get; set; }
        public DateTime Fecha { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}