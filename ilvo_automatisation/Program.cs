using ilvo_automatisation;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main(string[] args)
    {
        GenerateMockData generateMockData;
        //string connectionString = Constants.connectionString; // Replace with your database connection string
        //string outputPath = GetDefaultOutputPath(); // Get the default output path

        //To fill the database with mock data
        var dataGenerator = new GenerateMockData();
        dataGenerator.GenerateData();
    }

    //private static string GetDefaultOutputPath()
    //{
    //    string homeDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
    //    string defaultOutputPath = Path.Combine(homeDirectory, "DatabaseClasses");
    //    Directory.CreateDirectory(defaultOutputPath);
    //    return defaultOutputPath;
    //}
}
