using Inventory.Models;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Info
{
    public class InventoriesDbContext : DbContext
    {
        public InventoriesDbContext(DbContextOptions options) : base(options)
        {
        }
     
        public DbSet<Registration> Registrations { get; set; }
    }
}
