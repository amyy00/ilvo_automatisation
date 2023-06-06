using ilvo_automatisation.Models;
using Microsoft.EntityFrameworkCore;

namespace ilvo_automatisation;

public class Program
{
    public static void Main(string[] args)
    {
        string connectionString = Constants.connectionString;
        
        // Create the DbContext using the provided connection string
        using var dbContext = new EmavContext(new DbContextOptionsBuilder<EmavContext>().UseSqlServer(connectionString).Options);

        // Generate classes and CSV files
        GenerateCSV.GenerateFile(dbContext);
    }
}