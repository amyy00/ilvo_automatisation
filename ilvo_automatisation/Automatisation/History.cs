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
                using (var connection = new SqlConnection(Constants.connectionString))
                {
                    connection.Open();

                    // Create the fully qualified history table name
                    var historyTableName = $"history_{tableName}";

                    // SQL query to drop the existing history table if it exists
                    var dropHistoryTableQuery = $@"
                    IF EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'{historyTableName}') AND type = N'U')
                    DROP TABLE {historyTableName}";

                    // Execute the check and drop table query using a SqlCommand
                    using (var dropTableCommand = new SqlCommand(dropHistoryTableQuery, connection))
                    {
                        dropTableCommand.ExecuteNonQuery();
                        Console.WriteLine($"Dropping {historyTableName}...");
                    }

                    DataTable schemaTable = connection.GetSchema("Columns", new[] { databaseName, null, tableName });

                    var dataRows = schemaTable.Rows.Cast<DataRow>()
                        .Select(row =>
                        {
                            string? columnName = row["COLUMN_NAME"].ToString();
                            string? dataType = row["DATA_TYPE"].ToString();
                            string? maxLength = row["CHARACTER_MAXIMUM_LENGTH"].ToString();
                            string? isNullable = row["IS_NULLABLE"].ToString();
                            return $"[{columnName}] [{dataType}] {(string.IsNullOrEmpty(maxLength) ? "" : $"({maxLength})")} {(isNullable == "YES" ? "NULL" : "NOT NULL")}";
                        });

                    // SQL query to create the history table
                    var createHistoryTableQuery = $@"
                    CREATE TABLE {historyTableName}(
	                [HistoryID] [int] IDENTITY(1,1) NOT NULL,
                    [ID] [uniqueidentifier] NOT NULL,
	                [Naam] [nvarchar](50) NOT NULL,
                    {string.Join(",", dataRows)},
                    [UpdatedBy] [nvarchar](128) NULL,
                    [UpdatedOn] [datetime] NULL,
                    [Status] [nvarchar](30) NULL,
                    PRIMARY KEY CLUSTERED ([HistoryID] ASC))";

                    // Execute the create table query using a SqlCommand
                    using (var createTableCommand = new SqlCommand(createHistoryTableQuery, connection))
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
