using Microsoft.EntityFrameworkCore;

namespace MVC_Inventory_System.Models
{

    public class ISDBContext : DbContext
    {
        public ISDBContext(DbContextOptions<ISDBContext> options)
            : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}