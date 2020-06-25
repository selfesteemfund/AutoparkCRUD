using autopark.Models;
using Microsoft.EntityFrameworkCore;

namespace autopark.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Inspection> Inspections { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().ToTable("Car");
            modelBuilder.Entity<Inspection>().ToTable("Inspection");
        }
    }
}