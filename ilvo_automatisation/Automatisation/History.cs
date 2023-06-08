using ilvo_automatisation.Data;
using Microsoft.Data.SqlClient;
using System;

namespace ilvo_automatisation.Automatisation
{
    public class History
    {
        public static void CreateHistoryTables(Type entityType)
        {
            try
            {
                // Haal de tabelnaam op
                string tableName = entityType.Name;

                using (SqlConnection connection = new SqlConnection(Constants.connectionString))
                {
                    connection.Open();

                    string historyTableName = $"history.{tableName}";

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

                    using (SqlCommand command = new SqlCommand(createHistoryTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    Console.WriteLine($"History table {historyTableName} created successfully!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating history table: {ex.Message}");
            }
        }
    }
}
