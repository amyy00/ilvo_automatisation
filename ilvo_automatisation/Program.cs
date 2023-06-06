using ilvo_automatisation.Data;
using ilvo_automatisation.Models;
using Microsoft.EntityFrameworkCore;

namespace ilvo_automatisation;

public class Program
{
    public static void Main(string[] args)
    {
        // Get the default output path
        string outputPath = GetDefaultOutputPath();

        string connectionString = Constants.connectionString;
        
        // Create the DbContext using the provided connection string
        using var dbContext = new EmavContext(new DbContextOptionsBuilder<EmavContext>().UseSqlServer(connectionString).Options);

        // Generate classes and CSV files
        GenerateCSV.GenerateFile(dbContext, outputPath);

        ////To fill the database with mock data
        //GenerateMockData.GenerateData();
    }

    private static string GetDefaultOutputPath()
    {
        string homeDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        string defaultOutputPath = Path.Combine(homeDirectory, "DatabaseClasses");
        Directory.CreateDirectory(defaultOutputPath);
        return defaultOutputPath;
    }
}