using Microsoft.EntityFrameworkCore;

namespace ilvo_automatisation
{
    public static class DbContextFactory
    {
        public static DbContext CreateDbContext(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new DbContext(optionsBuilder.Options);
        }
    }
}
