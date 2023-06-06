using ilvo_automatisation;
using ilvo_automatisation.Models;
using Microsoft.EntityFrameworkCore;

namespace ilvo_automatisation
{
    public class IlvoDbContext : DbContext
    {
        public IlvoDbContext(DbContextOptions<IlvoDbContext> options) : base(options)
        {

        }

        public DbSet<TblStal> TblStal => Set<TblStal>();
        public DbSet<LnkGewassen> LnkGewassen => Set<LnkGewassen>();
        public DbSet<TblPa> TblPas => Set<TblPa>();
        public DbSet<TblVersie> TblVersie => Set<TblVersie>();

        public static IlvoDbContext CreateDbContext(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<IlvoDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new IlvoDbContext(optionsBuilder.Options);
        }
    }
}
