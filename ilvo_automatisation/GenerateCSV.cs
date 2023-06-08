using System.Data;
using Bogus.DataSets;
// using ilvo_automatisation.Helper;
using ilvo_automatisation.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ilvo_automatisation;

public class GenerateCSV
{
    
    public static void GenerateFile(EmavContext dbContext, string outputPath)
    {
        Console.WriteLine("Generating CSV file...");
        // Get the entity types from the DbContext's model
        var entityTypes = dbContext.Model.GetEntityTypes();

        var csvData = new List<string>();

        // Get the current datetime
        string datetime = DateTime.Now.ToString("yyyyMMdd_HHmmss");

        // Create the output filename with datetime
        string outputFileName = $"DatabaseClasses_{datetime}.csv";
        string outputFilePath = Path.Combine(outputPath, outputFileName);

        // Add the data file name above the created rows
        // csvData.Add($"Data File: {outputFileName}");
        // csvData.Add(string.Empty);

        foreach (var entityType in entityTypes)
        {
            var className = entityType.ClrType.Name;
    if (className == "TblPas")
    {
      // Generate the properties of the class based on entity properties
                var properties = entityType.GetProperties()
                    .Select(property => $"public {property.ClrType} {property.Name} {{ get; set; }}")
                    .ToList();
    
                // Add the class definition to the CSV data
                csvData.Add(className);
                Console.WriteLine($"add className: {className} to CSV file.");
    
                // Add the headers for the CSV file
                csvData.Add(string.Join(",", entityType.GetProperties().Select(p => p.Name)));
    
                // Retrieve records for each entity type
                var entityTypeClrType = entityType.ClrType;
                var type = entityType.ClrType.GetType();
                
                var records = dbContext.Set<TblPas>();
                //// Add the records for each entity type to the CSV data
                if (records is not null)
                {
                    Console.WriteLine($"adding record {records} to CSV file.");
                    foreach (var record in records)
                    {
                        var propertyValues = entityType.GetProperties()
                            .Select(property => GetValueString(record, property.Name))
                            .ToList();
        
                        // Add the data file name to the row
                       // propertyValues.Insert(1, outputFileName);
        
                        csvData.Add(string.Join(",", propertyValues));
                    }
                }
    
                // Add an empty row between data tables
                csvData.Add(string.Empty);
            }
    
            // Create the CSV text by joining the CSV data
            var csvText = string.Join(Environment.NewLine, csvData);
    
            // Write the CSV text to the output file
            File.WriteAllText(outputFilePath, csvText);
            Console.WriteLine($"CSV file generated successfully. Output file: {outputFilePath}");
        }
          
    }

    private static string? GetValueString(object obj, string propertyName)
    {
        // Get the value of the specified property from the object
        var propertyValue = obj.GetType().GetProperty(propertyName)?.GetValue(obj);

        if (propertyValue == null)
            return "null";

        if (propertyValue is string)
            return $"\"{propertyValue}\"";

        return propertyValue.ToString();
    }
}