using System;

namespace Limpieza360Pro.Api.Models
{
    public class Reminder
    {
        public int Id { get; set; }
        public int PropertyId { get; set; }
        public Property Property { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Type { get; set; } // Agua, Luz, Teléfono, etc.
        public string Entity { get; set; } // Banco, proveedor
        public string AccountNumber { get; set; }
        public bool Notified { get; set; }
    }
}