using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Limpieza360Pro.Models;

namespace Limpieza360Pro.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Property> Properties { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<ShoppingList> ShoppingLists { get; set; }
        public DbSet<Reminder> Reminders { get; set; }
    }
}