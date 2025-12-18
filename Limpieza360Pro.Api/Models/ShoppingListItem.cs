using System;

namespace Limpieza360Pro.Api.Models
{
    public class ShoppingListItem
    {
        public int Id { get; set; }
        public int PropertyId { get; set; }
        public Property Property { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Reason { get; set; }
        public string AddedById { get; set; }
        public ApplicationUser AddedBy { get; set; }
        public string Status { get; set; } // Activo, Completado
        public string Comments { get; set; }
        public DateTime AddedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
    }
}