namespace Limpieza360Pro.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public int PropertyId { get; set; }
        public Property Property { get; set; }
    }
}