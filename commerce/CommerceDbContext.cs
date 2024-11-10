using commerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace commerce
{
    public class CommerceDbContext: DbContext
    {

        public CommerceDbContext(DbContextOptions<CommerceDbContext> options) : base(options)
        {
            
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }

    }
}
