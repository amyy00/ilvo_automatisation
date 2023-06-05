// Verkrijg de lijst met tabellen
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Data.Common;

public class Program
{
    public static void Main(string[] args)
    {
        string connectionString = "<Your_Connection_String>"; // Replace with your database connection string
        string outputPath = "<Output_Path>"; // Replace with your desired output path

        GenerateClasses(connectionString, outputPath);
    }

    public static void GenerateClasses(string connectionString, string outputPath)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DbContext>();
        optionsBuilder.UseSqlServer(connectionString);

        using (var dbContext = new DbContext(optionsBuilder.Options))
        {
            var entityTypes = dbContext.Model.GetEntityTypes();

            var classDefinitions = entityTypes.Select(entityType =>
            {
                var tableName = entityType.GetTableName();
                var className = entityType.Name;

                var properties = entityType.GetProperties()
                    .Select(property => $"    public {property.ClrType} {property.Name} {{ get; set; }}")
                    .ToList();

                var classDefinition = $"public class {className}\n" +
                    "{\n" +
                    string.Join("\n", properties) +
                    "\n}\n";

                return classDefinition;
            }).ToList();

            var outputText = $"using System;\n\nnamespace DatabaseClasses\n{{\n{string.Join("\n", classDefinitions)}}}";

            File.WriteAllText(outputPath, outputText);
            Console.WriteLine($"Classes generated successfully. Output file: {outputPath}");
        }
    }
}

public class DbContextFactory : IDesignTimeDbContextFactory<DbContext>
{
    public DbContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<DbContext>();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("<Your_Connection_String>"));

        return new DbContext(optionsBuilder.Options);
    }
}
