﻿using ilvo_automatisation.Data;
using ilvo_automatisation.Data.Test;
using ilvo_automatisation.Models;
using Microsoft.EntityFrameworkCore;

namespace ilvo_automatisation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string connectionString = Constants.connectionString;
            
            // Create the DbContext using the provided connection string
            using var dbContext = new EmavContext(new DbContextOptionsBuilder<EmavContext>().UseSqlServer(connectionString).Options);

            // Get the default output path
            string outputPath = GetDefaultOutputPath();

            Console.WriteLine("Please enter a command: csv, trigger, mockdata");
            string? input = Console.ReadLine();

            switch (input)
            {
                case "csv":
                    Console.WriteLine("Executing command csv...");
                    // Create an instance of GenerateCSV
                    var generateCSV = new GenerateCsv();

                    // Generate CSV file
                    generateCSV.GenerateFile(dbContext, outputPath);
                    Console.WriteLine("Program completed");
                    break;
                
                case "trigger":
                    Console.WriteLine("Executing command trigger...");
                    TrackHistory.TestTrackHistory();
                    Console.WriteLine("Program completed");
                    break;

                case "mockdata":
                    Console.WriteLine("Executing command mockdata...");
                    //To fill the database with mock data
                    GenerateMockData.GenerateData();
                    Console.WriteLine("Program completed");
                    break;

                default:
                    Console.WriteLine("Unknown command.");
                    break;
            }

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