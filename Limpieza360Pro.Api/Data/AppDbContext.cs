using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Limpieza360Pro.Api.Models;

namespace Limpieza360Pro.Api.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Property> Properties { get; set; }
        public DbSet<TaskItem> Tasks { get; set; }
        public DbSet<InventoryItem> Inventory { get; set; }
        public DbSet<ShoppingListItem> ShoppingList { get; set; }
        public DbSet<Reminder> Reminders { get; set; }
        public DbSet<LoginRecord> LoginRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Relaciones y restricciones personalizadas aquí si es necesario

            builder.Entity<TaskItem>()
                .HasOne(t => t.Employee)
                .WithMany(u => u.Tasks)
                .HasForeignKey(t => t.EmployeeId)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired(false);
        }
    }
}