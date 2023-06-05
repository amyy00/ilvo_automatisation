using ilvo_automatisation.Models;
using Microsoft.EntityFrameworkCore;

public class IlvoDbContext : DbContext
{
    public DbSet<LnkGewassen> LnkGewassen { get; set; }
    public DbSet<TblPas> TblPas { get; set; }
    public DbSet<TblStal> TblStal { get; set; }
    public DbSet<TblVersie> TblVersie { get; set; }

    public IlvoDbContext(DbContextOptions<IlvoDbContext> options) : base(options)
    {
    }

    // Override OnModelCreating if you need to configure your entity models
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure entity relationships, constraints, etc.
        // For example:
        // modelBuilder.Entity<Customer>()
        //     .HasMany(c => c.Orders)
        //     .WithOne(o => o.Customer)
        //     .HasForeignKey(o => o.CustomerId);
    }

    // Optional: Override OnConfiguring if you want to provide configuration options
    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     // Configure database provider, connection string, etc.
    // }

    // Custom Set method to retrieve DbSet dynamically
    public DbSet<TEntity> Set<TEntity>() where TEntity : class
    {
        return base.Set<TEntity>();
    }
}