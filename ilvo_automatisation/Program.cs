// Verkrijg de lijst met tabellen
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class Program
{
    public static void Main(string[] args)
    {
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EMAV;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"; // Replace with your database connection string
        string outputPath = "C:\\Users\\TheWi\\Desktop"; // Replace with your desired output path

        GenerateClasses(connectionString, outputPath);
    }

    private static void GenerateClasses(string connectionString, string outputPath)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DbContext>();
        optionsBuilder.UseSqlServer(connectionString);

        using (var dbContext = new DbContext(optionsBuilder.Options))
        {
            var entityTypes = dbContext.Model.GetEntityTypes();

            var classDefinitions = entityTypes.Select(entityType =>
            {
                //var tableName = entityType.GetTableName();
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