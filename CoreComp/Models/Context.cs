using Microsoft.EntityFrameworkCore;

namespace CoreComp.Models
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=WIN-0AVBIPRU9F2;database=CoreProduct;integrated security=true"); 
        }
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }
        
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Country> Countries { get; set; }
    }
}
