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

                    // Controleer of de geschiedenistabel al bestaat
                    bool historyTableExists;
                    string checkTableExistsQuery = $@"
                        IF OBJECT_ID('{historyTableName}', 'U') IS NOT NULL
                            SELECT 1
                        ELSE
                            SELECT 0";

                    using (SqlCommand checkTableExistsCommand = new SqlCommand(checkTableExistsQuery, connection))
                    {
                        historyTableExists = (int)checkTableExistsCommand.ExecuteScalar() == 1;
                    }

                    if (historyTableExists)
                    {
                        // Voer een update-query uit op de bestaande geschiedenistabel
                        string updateHistoryTableQuery = $@"
                            ALTER TABLE {historyTableName}
                            ADD [Status] [nvarchar](30) NULL";

                        using (SqlCommand updateHistoryTableCommand = new SqlCommand(updateHistoryTableQuery, connection))
                        {
                            updateHistoryTableCommand.ExecuteNonQuery();
                        }

                        Console.WriteLine($"History table {historyTableName} updated successfully!");
                    }
                    else
                    {
                        // Maak een nieuwe geschiedenistabel aan
                        string createHistoryTableQuery = $@"
                            CREATE TABLE {historyTableName}(
                                [HistoryID] [int] IDENTITY(1,1) NOT NULL,
                                [ID] [uniqueidentifier] NOT NULL,
                                [Naam] [nvarchar](50) NOT NULL,
                                [GebruikerID] [uniqueidentifier] NOT NULL,
                                [Publiek] [bit] NOT NULL,
                                [UpdatedBy] [nvarchar](128) NULL,
                                [UpdatedOn] [datetime] NULL,
                                PRIMARY KEY CLUSTERED ([HistoryID] ASC)
                            )";

                        using (SqlCommand createHistoryTableCommand = new SqlCommand(createHistoryTableQuery, connection))
                        {
                            createHistoryTableCommand.ExecuteNonQuery();
                        }

                        Console.WriteLine($"History table {historyTableName} created successfully!");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating/updating history table: {ex.Message}");
            }
        }
    }
}
