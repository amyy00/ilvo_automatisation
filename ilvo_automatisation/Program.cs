using ilvo_automatisation;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main(string[] args)
    {
        GenerateMockData generateMockData;
        string connectionString = Constants.connectionString; // Replace with your database connection string
        string outputPath = GetDefaultOutputPath(); // Get the default output path
        generateMockData = new GenerateMockData();
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
        using (var dbContext = DbContextFactory.CreateDbContext(connectionString))
        {
            var classGenerator = new ClassGenerator(dbContext);
            classGenerator.GenerateClasses(outputPath);
        }
    }
}
