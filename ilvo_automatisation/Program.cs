using ilvo_automatisation;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main(string[] args)
    {
        string connectionString = Constants.connectionString; // Replace with your database connection string
        string outputPath = GetDefaultOutputPath(); // Get the default output path

        GenerateClasses(connectionString, outputPath);
    }

    private static string GetDefaultOutputPath()
    {
        string homeDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        string defaultOutputPath = Path.Combine(homeDirectory, "DatabaseClasses");
        Directory.CreateDirectory(defaultOutputPath);
        return defaultOutputPath;
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

            string outputFilePath = Path.Combine(outputPath, "DatabaseClasses.cs");
            File.WriteAllText(outputFilePath, outputText);
            Console.WriteLine($"Classes generated successfully. Output file: {outputFilePath}");
        }
    }
}
