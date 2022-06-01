using Microsoft.EntityFrameworkCore;

namespace IntrooApi.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Repair> Repairs { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Car> Cars { get; set; } = null!;
        public DbSet<Event> Events { get; set; } = null!;
        public DbSet<StoreFile> StoreFiles { get; set; } = null!;

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}