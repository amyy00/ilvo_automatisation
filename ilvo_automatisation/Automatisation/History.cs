using ilvo_automatisation.Data;
using Microsoft.Data.SqlClient;
using System;

namespace ilvo_automatisation.Automatisation
{
    public class History
    {
        // Method to create history tables for the specified entity type
        public static void CreateHistoryTables(Type entityType)
        {
            try
            {
                // Get the table name based on the entity type
                string tableName = entityType.Name;

                // Create a new SQL connection using the connection string from Constants class
                using (SqlConnection connection = new SqlConnection(Constants.connectionString))
                {
                    connection.Open();

                    // Create the fully qualified history table name
                    string historyTableName = $"history.{tableName}";

                    // SQL query to drop the existing history table if it exists
                    string dropHistoryTableQuery = $"IF OBJECT_ID('{historyTableName}', 'U') IS NOT NULL DROP TABLE {historyTableName}";

                    // Execute the drop table query using a SqlCommand
                    using (SqlCommand dropTableCommand = new SqlCommand(dropHistoryTableQuery, connection))
                    {
                        dropTableCommand.ExecuteNonQuery();
                        Console.WriteLine($"Deleting table {historyTableName}");
                    }

                    // SQL query to create the history table
                    string createHistoryTableQuery = $@"
                            CREATE TABLE {historyTableName}(
                                [HistoryID] [int] IDENTITY(1,1) NOT NULL,
                                [ID] [uniqueidentifier] NOT NULL,
                                [Naam] [nvarchar](50) NOT NULL,
                                [GebruikerID] [uniqueidentifier] NOT NULL,
                                [Publiek] [bit] NOT NULL,
                                [UpdatedBy] [nvarchar](128) NULL,
                                [UpdatedOn] [datetime] NULL,
                                [Status] [nvarchar](30) NULL,
                                PRIMARY KEY CLUSTERED ([HistoryID] ASC)
                            )";

                    // Execute the create table query using a SqlCommand
                    using (SqlCommand createTableCommand = new SqlCommand(createHistoryTableQuery, connection))
                    {
                        createTableCommand.ExecuteNonQuery();
                    }

                    // Display success message after creating the history table
                    Console.WriteLine($"History table {historyTableName} created successfully!");
                }
            }
            catch (Exception ex)
            {
                // Display error message if an exception occurs during table creation
                Console.WriteLine($"Error creating history table: {ex.Message}");
            }
        }
    }
}
