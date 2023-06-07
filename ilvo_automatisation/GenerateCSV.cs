using ilvo_automatisation.Models;
using Microsoft.EntityFrameworkCore;

namespace ilvo_automatisation
{
    public class GenerateCsv
    {
        public void GenerateFile(EmavContext dbContext, string outputPath)
        {
            using (var dbContexts = new EmavContext())
            {
                // Execute your SQL query
                var query = "SELECT * FROM tblPAS";
                var result = dbContext.TblPas.FromSqlRaw(query);

                // Output the retrieved data
                foreach (var item in result)
                {
                    Console.WriteLine(item.ToString()); // Adjust this based on your entity's properties
                }
            }

            Console.ReadLine();
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
            csvData.Add($"Data File: {outputFileName}");
            csvData.Add(string.Empty);

            foreach (var entityType in entityTypes)
            {
                var className = entityType.ClrType.Name;

                // Generate the properties of the class based on entity properties
                var properties = entityType.GetProperties()
                    .Select(property => $"    public {property.ClrType} {property.Name} {{ get; set; }}")
                    .ToList();

                // Add the class definition to the CSV data
                csvData.Add(className);

                // Add the headers for the CSV file
                csvData.Add(string.Join(",", entityType.GetProperties().Select(p => p.Name)));

                // Retrieve records for each entity type
                var records = GetRecords(dbContext, entityType.ClrType);

                // Add the records for each entity type to the CSV data
                foreach (var record in records)
                {
                    var propertyValues = entityType.GetProperties()
                        .Select(property => GetValueString(record, property.Name))
                        .ToList();

                    csvData.Add(string.Join(",", propertyValues));
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

        private static List<object> GetRecords(EmavContext dbContext, Type entityType)
        {
            var dbSetMethod = typeof(DbContext)
                .GetMethod("Set", new[] {typeof(Type)})
                .MakeGenericMethod(entityType);

            var dbSet = dbSetMethod?.Invoke(dbContext, null);

            var toListMethod = typeof(Enumerable)
                .GetMethod("ToList")
                .MakeGenericMethod(entityType);

            var records = toListMethod?.Invoke(null, new[] {dbSet});

            return (List<object>) records;
        }
    }
}