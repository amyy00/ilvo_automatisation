﻿using ilvo_automatisation.Automatisation;
using ilvo_automatisation.Data;
using ilvo_automatisation.Data.Test;
using ilvo_automatisation.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Reflection;

namespace ilvo_automatisation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string connectionString = Constants.connectionString;

            // Create the DbContext using the provided connection string
            using var dbContext =
                new EmavContext(new DbContextOptionsBuilder<EmavContext>().UseSqlServer(connectionString).Options);

            // Get the default output path
            string outputPath = GetDefaultOutputPath();

        Begin:
            Console.WriteLine("Please enter a command: csv, trigger, mock data, automate trigger, exit");
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
                    //TODO add comments
                    //TrackHistory.TestTrackHistory();
                    Console.WriteLine("Program completed");
                    break;

                case "mock data":
                    Console.WriteLine("Executing command mockdata...");
                    //To fill the database with mock data
                    GenerateMockData.GenerateData();
                    Console.WriteLine("Program completed");
                    break;

                case "1":
                    Console.WriteLine("Executing command automate trigger");
                    var entityTypes = dbContext.Model.GetEntityTypes();
                    foreach (var entityType in entityTypes)
                    {
                        Triggers.AutomateTriggers(entityType.ClrType);
                    }
                    Console.WriteLine("Program completed");
                    break;
                case "2":
                    Console.WriteLine("Executing command trigger...");
                    var HistoryEntitytypes = dbContext.Model.GetEntityTypes();
                    foreach (var HistoryEntitytype in HistoryEntitytypes)
                    {
                        History.CreateHistoryTables(HistoryEntitytype.ClrType);
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

        private static string GetDefaultOutputPath()
        {
            string homeDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string defaultOutputPath = Path.Combine(homeDirectory, "DatabaseClasses");
            Directory.CreateDirectory(defaultOutputPath);
            return defaultOutputPath;
        }
    }
}