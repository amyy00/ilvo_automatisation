using ilvo_automatisation;
using Microsoft.EntityFrameworkCore;
using System;

public class Program
{
    public static void Main(string[] args)
    {
        string connectionString = Constants.connectionString;
        string outputPath = GetDefaultOutputPath(); // Get the default output path

        using (var dbContext = new IlvoDbContext(new DbContextOptionsBuilder<IlvoDbContext>().UseSqlServer(connectionString).Options))
        {
            GenerateClasses(dbContext, outputPath);
        }
      
        GenerateMockData generateMockData;
        generateMockData = new GenerateMockData();
    }

    private static string GetDefaultOutputPath()
    {
        string homeDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        string defaultOutputPath = Path.Combine(homeDirectory, "DatabaseClasses");
        Directory.CreateDirectory(defaultOutputPath);
        return defaultOutputPath;
    }

    private static void GenerateClasses(IlvoDbContext dbContext, string outputPath)
    {
        var entityTypes = dbContext.Model.GetEntityTypes();

        foreach (var entityType in entityTypes)
        {
            var className = entityType.Name;

            var properties = entityType.GetProperties()
                .Select(property => $"    public {property.ClrType} {property.Name} {{ get; set; }}")
                .ToList();

            var classDefinition = $"public class {className}\n" +
                                  "{{\n" +
                                  string.Join("\n", properties) +
                                  "\n}}\n";

            var entityTypeClrType = entityType.ClrType;
            var records = dbContext.Set(entityTypeClrType).ToList();

            var csvData = new List<string>();
            csvData.Add(string.Join(",", entityType.GetProperties().Select(p => p.Name)));

            foreach (var record in records)
            {
                var propertyValues = entityType.GetProperties()
                    .Select(property => GetValueString(record, property.Name))
                    .ToList();
                csvData.Add(string.Join(",", propertyValues));
            }

            var csvText = string.Join(Environment.NewLine, csvData);

            string outputFilePath = Path.Combine(outputPath, $"{className}.csv");
            File.WriteAllText(outputFilePath, csvText);
            Console.WriteLine($"CSV file generated successfully. Output file: {outputFilePath}");
        }
    }

    private static string GetValueString(object obj, string propertyName)
    {
        var propertyValue = obj.GetType().GetProperty(propertyName)?.GetValue(obj);
        if (propertyValue == null)
            return "null";

        if (propertyValue is string)
            return $"\"{propertyValue}\"";

        return propertyValue.ToString();
    }
}