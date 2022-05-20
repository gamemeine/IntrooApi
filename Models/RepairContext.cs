using Microsoft.EntityFrameworkCore;

namespace IntrooApi.Models
{
    public class RepairContext : DbContext
    {
        public RepairContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Repair> Repairs { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Car> Cars { get; set; } = null!;
        public DbSet<Event> Events { get; set; } = null!;
    }
}