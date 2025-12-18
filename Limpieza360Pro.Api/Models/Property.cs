using System.Collections.Generic;

namespace Limpieza360Pro.Api.Models
{
    public class Property
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public ICollection<ApplicationUser> Users { get; set; }
        public ICollection<TaskItem> Tasks { get; set; }
        public ICollection<InventoryItem> Inventory { get; set; }
        public ICollection<ShoppingListItem> ShoppingList { get; set; }
        public ICollection<Reminder> Reminders { get; set; }
    }
}