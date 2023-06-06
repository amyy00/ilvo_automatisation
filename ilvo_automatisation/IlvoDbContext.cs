using Microsoft.EntityFrameworkCore;

public class IlvoDbContext : DbContext
{
    public IlvoDbContext(DbContextOptions<IlvoDbContext> options) : base(options)
    {
    }

    // Define your entity DbSet properties here
    // For example:
    // public DbSet<Customer> Customers { get; set; }
    // public DbSet<Order> Orders { get; set; }

    // Override OnModelCreating if you need to configure your entity models
    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     // Configure entity relationships, constraints, etc.
    // }

    // Optional: Override OnConfiguring if you want to provide configuration options
    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     // Configure database provider, connection string, etc.
    // }
}