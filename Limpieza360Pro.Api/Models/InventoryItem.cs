namespace Limpieza360Pro.Api.Models
{
    public class InventoryItem
    {
        public int Id { get; set; }
        public int PropertyId { get; set; }
        public Property Property { get; set; }
        public string Area { get; set; } // Cocina, Baño, etc.
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; } // Completo, Incompleto
        public string Details { get; set; } // Faltan X items, Roto, etc.
        public string PhotoUrl { get; set; }
    }
}