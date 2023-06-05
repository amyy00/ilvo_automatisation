using ilvo_automatisation;
using Microsoft.EntityFrameworkCore;
using System;
using ilvo_automatisation.Models;

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
        var csvData = new List<string>();

        foreach (var entityType in entityTypes)
        {
            var className = entityType.Name;

            var properties = entityType.GetProperties()
                .Select(property => $"    public {property.ClrType} {property.Name} {{ get; set; }}")
                .ToList();

            var classDefinition = $"public class {className}\n" +
                                  "{\n" +
                                  string.Join("\n", properties) +
                                  "\n}\n";

            var entityTypeClrType = entityType.ClrType;
            var records1 = dbContext.Set<TblPas>().ToList();
            var records2 = dbContext.Set<TblStal>();
            var records3 = dbContext.Set<TblVersie>().ToList();
            var records4 = dbContext.Set<LnkGewassen>().ToList();

            csvData.Add(string.Join(",", entityType.GetProperties().Select(p => p.Name)));

            foreach (var record in records1)
            {
                var propertyValues = entityType.GetProperties()
                    .Select(property => GetValueString(record, property.Name))
                    .ToList();
                csvData.Add(string.Join(",", propertyValues));
            }

            foreach (var record in records2)
            {
                var propertyValues = entityType.GetProperties()
                    .Select(property => GetValueString(record, property.Name))
                    .ToList();
                csvData.Add(string.Join(",", propertyValues));
            }

            foreach (var record in records3)
            {
                var propertyValues = entityType.GetProperties()
                    .Select(property => GetValueString(record, property.Name))
                    .ToList();
                csvData.Add(string.Join(",", propertyValues));
            }

            foreach (var record in records4)
            {
                var propertyValues = entityType.GetProperties()
                    .Select(property => GetValueString(record, property.Name))
                    .ToList();
                csvData.Add(string.Join(",", propertyValues));
            }

            // Add an empty row between data tables
            csvData.Add(string.Empty);
        }

        var csvText = string.Join(Environment.NewLine, csvData);

        string outputFilePath = Path.Combine(outputPath, "DatabaseClasses.csv");
        File.WriteAllText(outputFilePath, csvText);
        Console.WriteLine($"CSV file generated successfully. Output file: {outputFilePath}");
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