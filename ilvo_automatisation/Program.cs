using ilvo_automatisation.Models;
using Microsoft.EntityFrameworkCore;

namespace ilvo_automatisation;

public class Program
{
    public static void Main(string[] args)
    {
        string connectionString = Constants.connectionString;
        // Get the default output path
        string outputPath = GetDefaultOutputPath(); 

        // Create the DbContext using the provided connection string
        using var dbContext =
            new IlvoDbContext(
                new DbContextOptionsBuilder<IlvoDbContext>().UseSqlServer(connectionString).Options);
        
        // Add data to the DbContext
        AddData(dbContext);

        // Save the changes to the database
        dbContext.SaveChanges();

        // Generate classes and CSV files
        GenerateClasses(dbContext, outputPath);
    }

    private static string GetDefaultOutputPath()
    {
        string homeDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        string defaultOutputPath = Path.Combine(homeDirectory, "DatabaseClasses");
        Directory.CreateDirectory(defaultOutputPath);
        return defaultOutputPath;
    }

    private static void AddData(IlvoDbContext dbContext)
    {
        // Create instances of the entity classes and add them to the respective DbSet properties

        // Create a LutGewasGroep instance to use as the foreign key reference for LnkGewassen
        var lutGewasGroep = new LutGewasGroep { Id = Guid.NewGuid() };
        dbContext.LutGewasGroeps.Add(lutGewasGroep);

        var lnkGewassen = new LnkGewassen
        {
            Id = Guid.NewGuid(),
            CodeHoofdTeelt = 123,
            GewasGroepId = lutGewasGroep.Id, // Assign the foreign key value from the lutGewasGroep instance
            VersieId = Guid.NewGuid(),
            OmsHoofdTeelt = "Some value",
            GewasGroep = lutGewasGroep // Set the navigation property value
        };
        dbContext.LnkGewassens.Add(lnkGewassen);

        // Create a TblVersie instance to use as the foreign key reference for TblPas
        var tblVersie = new TblVersie { Id = Guid.NewGuid() };
        dbContext.TblVersies.Add(tblVersie);

        var tblPas = new TblPas
        {
            Id = Guid.NewGuid(),
            Naam = "Some name",
            ReductiePercentage = 0.5,
            Passtal = true,
            Pasvoeding = true,
            Pasweide = false,
            VersieId = tblVersie.Id // Assign the foreign key value from the tblVersie instance
        };
        dbContext.TblPas.Add(tblPas);

        // Create a LutStalType instance to use as the foreign key reference for TblStal
        var lutStalType = new LutStalType { Id = Guid.NewGuid() };
        dbContext.LutStalTypes.Add(lutStalType);

        var tblStal = new TblStal
        {
            Id = Guid.NewGuid(),
            Naam = "Some name",
            Omschrijving = "Some description",
            FractieVloeibaar = 0.75,
            ReductiePercentage = null, // Update if necessary
            MestTypeId = Guid.NewGuid(),
            StalTypeId = lutStalType.Id, // Assign the foreign key value from the lutStalType instance
            VersieId = Guid.NewGuid(),
            LnkStalDierSubCategories = new List<LnkStalDierSubCategorie>(), // Update if necessary
            MestType = null!, // Update if necessary
            StalType = lutStalType // Set the navigation property value
        };
        dbContext.TblStals.Add(tblStal);

        // Create a TblGebruiker instance to use as the foreign key reference for TblVersie
        var tblGebruiker = new TblGebruiker { Id = Guid.NewGuid() };
        dbContext.TblGebruikers.Add(tblGebruiker);

        var tblVersie2 = new TblVersie
        {
            Id = Guid.NewGuid(),
            Naam = "Some name",
            GebruikerId = tblGebruiker.Id, // Assign the foreign key value from the tblGebruiker instance
            Publiek = true,
            Gebruiker = tblGebruiker // Set the navigation property value
        };
        dbContext.TblVersies.Add(tblVersie2);

        // Save the changes to the database
        dbContext.SaveChanges();
    }

    private static void GenerateClasses(IlvoDbContext dbContext, string outputPath)
    {
        // Get the entity types from the DbContext's model
        var entityTypes = dbContext.Model.GetEntityTypes();
        var csvData = new List<string>();

        foreach (var entityType in entityTypes)
        {
            var className = entityType.Name;

            // Generate the properties of the class based on entity properties
            var properties = entityType.GetProperties()
                .Select(property => $"    public {property.ClrType} {property.Name} {{ get; set; }}")
                .ToList();

            var classDefinition = $"public class {className}\n" +
                                  "{\n" +
                                  string.Join("\n", properties) +
                                  "\n}\n";

            // Retrieve records for each entity type
            var records1 = dbContext.Set<TblPas>().ToList();
            var records2 = dbContext.Set<TblStal>().ToList();
            var records3 = dbContext.Set<TblVersie>().ToList();
            var records4 = dbContext.Set<LnkGewassen>().ToList();

            // Add the headers for the CSV file
            csvData.Add(string.Join(",", entityType.GetProperties().Select(p => p.Name)));

            // Add the records for each entity type to the CSV data
            csvData.AddRange(records1.Select(record => entityType.GetProperties()
                    .Select(property => GetValueString(record, property.Name))
                    .ToList())
                .Select(propertyValues => string.Join(",", propertyValues)));

            csvData.AddRange(records2.Select(record => entityType.GetProperties()
                    .Select(property => GetValueString(record, property.Name))
                    .ToList())
                .Select(propertyValues => string.Join(",", propertyValues)));

            csvData.AddRange(records3.Select(record => entityType.GetProperties()
                    .Select(property => GetValueString(record, property.Name))
                    .ToList())
                .Select(propertyValues => string.Join(",", propertyValues)));

            csvData.AddRange(records4.Select(record => entityType.GetProperties()
                    .Select(property => GetValueString(record, property.Name))
                    .ToList())
                .Select(propertyValues => string.Join(",", propertyValues)));

            // Add an empty row between data tables
            csvData.Add(string.Empty);
        }

        // Create the CSV text by joining the CSV data
        var csvText = string.Join(Environment.NewLine, csvData);

        string outputFilePath = Path.Combine(outputPath, "DatabaseClasses.csv");
        
        // Write the CSV text to the output file
        File.WriteAllText(outputFilePath, csvText);
        Console.WriteLine($"CSV file generated successfully. Output file: {outputFilePath}");
    }

    private static string GetValueString(object obj, string propertyName)
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