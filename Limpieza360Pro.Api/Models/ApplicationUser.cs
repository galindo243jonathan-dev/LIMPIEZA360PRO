using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Limpieza360Pro.Api.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public string Role { get; set; } // Dueño, Manager, Empleado
        public int? PropertyId { get; set; }
        public Property Property { get; set; }
        public ICollection<TaskItem> Tasks { get; set; }
        public ICollection<InventoryItem> Inventory { get; set; }
        public ICollection<ShoppingListItem> ShoppingList { get; set; }
        public ICollection<LoginRecord> LoginRecords { get; set; }
        public string ProfileImageUrl { get; set; }
    }
}