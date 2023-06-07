using ilvo_automatisation.Data;
using ilvo_automatisation.Data.Test;
using ilvo_automatisation.Models;
using Microsoft.EntityFrameworkCore;

namespace ilvo_automatisation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Get the default output path
            string outputPath = GetDefaultOutputPath();

            string connectionString = Constants.connectionString;

            // Create the DbContext using the provided connection string
            using var dbContext = new EmavContext(new DbContextOptionsBuilder<EmavContext>().UseSqlServer(connectionString).Options);

            // Create an instance of GenerateCSV
            var generateCSV = new GenerateCsv();

            // Generate CSV file
            generateCSV.GenerateFile(dbContext, outputPath);

            //To fill the database with mock data
            GenerateMockData.GenerateData();

            Console.ReadLine();
        }

        private static string GetDefaultOutputPath()
        {
            string homeDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string defaultOutputPath = Path.Combine(homeDirectory, "DatabaseClasses");
            Directory.CreateDirectory(defaultOutputPath);
            return defaultOutputPath;
        }
    }
}