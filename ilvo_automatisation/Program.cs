﻿using ilvo_automatisation.Automatisation;
using ilvo_automatisation.Data;
using ilvo_automatisation.Data.Test;
using ilvo_automatisation.Models;
using Microsoft.EntityFrameworkCore;

namespace ilvo_automatisation;

public abstract class Program
{
    public static void Main(string[] args)
    {
        // Make sure to have a Constants.cs file with the following details:
        // public class Constants
        // {
        //     internal static string connectionString = "{connection string}";
        // }

        // Get the connection string from Constants.cs
        string connectionString = Constants.connectionString;

        // Create the DbContext using the provided connection string
        using var dbContext =
            new EmavContext(new DbContextOptionsBuilder<EmavContext>().UseSqlServer(connectionString).Options);

        // Get the default output path
        string outputPath = GetDefaultOutputPath();

        Begin:
        Console.WriteLine("Please enter a command: csv, mock data, trigger, exit");
        string? input = Console.ReadLine();

        switch (input)
        {
            case "csv":
                Console.WriteLine("Executing command csv...");
                // Create an instance of GenerateCSV
                var generateCsv= new GenerateCsv();

                // Generate CSV file
                generateCsv.GenerateFile(dbContext, outputPath);
                Console.WriteLine("Program completed");
                break;

            case "mock data":
                Console.WriteLine("Executing command mockdata...");
                // To fill the database with mock data
                GenerateMockData.GenerateData();
                Console.WriteLine("Program completed");
                break;

            case "trigger":
                Console.WriteLine("Executing command automate trigger");
                // Get all entity types from the DbContext model
                var triggerEntityTypes = dbContext.Model.GetEntityTypes();
                foreach (var triggerEntityType in triggerEntityTypes)
                {
                    // Automate triggers for each entity type
                    Triggers.AutomateTriggers(triggerEntityType.ClrType);
                }
                Console.WriteLine("Program completed");
                break;

            case "history":
                Console.WriteLine("Executing command trigger...");
                // Get all entity types from the DbContext model
                var historyEntityTypes = dbContext.Model.GetEntityTypes();
                foreach (var historyEntityType in historyEntityTypes)
                {
                    // Create history tables for each entity type
                    History.CreateHistoryTables(historyEntityType.ClrType);
                }
                Console.WriteLine("Program completed");
                break;

            case "exit":
                Console.WriteLine("Closing program...");
                Console.ReadLine();
                goto End;
                break;

            default:
                Console.WriteLine("Unknown command.");
                break;
        }
        goto Begin;
        End:;
    }

    // Method to get the default output path
    private static string GetDefaultOutputPath()
    {
        string homeDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        string defaultOutputPath = Path.Combine(homeDirectory, "DatabaseClasses");
        Directory.CreateDirectory(defaultOutputPath);
        return defaultOutputPath;
    }
}