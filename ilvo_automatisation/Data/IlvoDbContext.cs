using ilvo_automatisation;
using ilvo_automatisation.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ilvo_automatisation
{
    public class IlvoDbContext : DbContext
    {
        public IlvoDbContext()
        {
        }

        public DbSet<TblStal> TblStal => Set<TblStal>();
        public DbSet<LnkGewassen> LnkGewassen => Set<LnkGewassen>();
        public DbSet<TblPas> TblPas => Set<TblPas>();
        public DbSet<TblVersie> TblVersie => Set<TblVersie>();

        public IlvoDbContext(DbContextOptions<IlvoDbContext> options) : base(options)
        {
        }



        // Override OnModelCreating if you need to configure your entity models
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }



        // Optional: Override OnConfiguring if you want to provide configuration options
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configure database provider, connection string, etc.
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = Constants.connectionString;
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        // Custom Set method to retrieve DbSet dynamically
        public DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}
