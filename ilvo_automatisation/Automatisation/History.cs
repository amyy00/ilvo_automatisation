using ilvo_automatisation.Data;
using Microsoft.Data.SqlClient;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace ilvo_automatisation.Automatisation
{
    public class History
    {
        // Method to create history tables for the specified entity type
        public static void CreateHistoryTables(Type entityType, string databaseName)
        {
            try
            {
                // Get the table name based on the entity type
                string tableName = entityType.GetCustomAttributesData()
                    .FirstOrDefault(x => x.AttributeType == typeof(TableAttribute))
                    ?.ConstructorArguments
                    .FirstOrDefault()
                    .Value
                    .ToString();

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

                    DataTable schemaTable = connection.GetSchema("Columns", new[] { databaseName, null, tableName });

                    var dataRows = schemaTable.Rows.Cast<DataRow>()
                            //.Select(row => $"[{row["COLUMN_NAME"]}] [{row["DATA_TYPE"]}] [{row["CHARACTER_MAXIMUM_LENGTH"]}] [{row["IS_NULLABLE"]}]");
                            .Select(row => $"[{row["COLUMN_NAME"]}] [{row["DATA_TYPE"]}]");

                    // SQL query to create the history table
                    string createHistoryTableQuery = $@"
                    CREATE TABLE {historyTableName}(
                        {string.Join(",", dataRows)},
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
