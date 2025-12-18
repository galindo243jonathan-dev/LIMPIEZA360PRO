using System;

namespace Limpieza360Pro.Api.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public int PropertyId { get; set; }
        public Property Property { get; set; }
        public string? EmployeeId { get; set; }
        public ApplicationUser? Employee { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; } // Limpieza Profunda, General, Mantenimiento
        public string Description { get; set; }
        public string Status { get; set; } // Completado, Incompleto
        public string IncompleteReason { get; set; }
        public string PhotoUrl { get; set; }
        public DateTime? CompletedAt { get; set; }
    }
}