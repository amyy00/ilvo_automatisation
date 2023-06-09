using ilvo_automatisation.Data;
using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace ilvo_automatisation.Automatisation
{
    public class Triggers
    {
        // Method to automate triggers for the specified entity type
        public static void AutomateTriggers(Type entityType, string databaseName)
        {
            // Get the table schema and column information
            using (SqlConnection connection = new SqlConnection(Constants.connectionString))
            {
                // Get the table name based on the entity type
                string tableName = entityType.GetCustomAttributesData()
                    .FirstOrDefault(x => x.AttributeType == typeof(TableAttribute))
                    ?.ConstructorArguments
                    .FirstOrDefault()
                    .Value
                    .ToString();

                connection.Open();

                DataTable schemaTable = connection.GetSchema("Columns", new[] { databaseName, null, tableName });

                // Find the ID column information
                DataRow? idColumn = schemaTable.Rows.Cast<DataRow>()
                    .FirstOrDefault(row => row["COLUMN_NAME"].ToString()!.Equals("ID", StringComparison.OrdinalIgnoreCase));

                if (idColumn == null)
                {
                    throw new Exception($"ID column not found in the table: {tableName}");
                }

                // Get the data type of the ID column
                string idDataType = idColumn["DATA_TYPE"].ToString();

                var dataRows = schemaTable.Rows.Cast<DataRow>()
                    .Select(row => $"[{row["COLUMN_NAME"]}]")
                    .Distinct()
                    .Where(s => !new[] { "[HistoryID]", "[UpdatedBy]", "[UpdatedOn]", "[Status]" }.Contains(s))
                    .ToList();

                try
                {
                    // Remove existing triggers
                    RemoveTriggers(tableName, connection);

                    // Trigger for update
                    string updateTriggerQuery = $@"
                    CREATE TRIGGER [dbo].[{tableName}rigger_UPDATE] ON [dbo].[{tableName}]
                    AFTER UPDATE AS
                    BEGIN
                        SET NOCOUNT ON;
                        DECLARE @ID {idDataType}

                        SELECT @ID = dbo.{tableName}.ID
                        FROM INSERTED, dbo.{tableName}

                        INSERT INTO history.{tableName}({string.Join(",", dataRows)},[UpdatedBy],[UpdatedOn],[Status])
                        SELECT {string.Join(",", dataRows)},USER_NAME(),GETDATE(),'INSERTED' FROM INSERTED
                    END";

                    // Execute the update trigger query using a SqlCommand
                    using (SqlCommand command = new SqlCommand(updateTriggerQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    // Display success message after creating the update trigger
                    Console.WriteLine($"Trigger update {tableName} created successfully!");
                }
                catch (Exception ex)
                {
                    // Display error message if an exception occurs during update trigger creation
                    Console.WriteLine($"Trigger update {tableName}: " + ex.Message);
                }
            }
        }

        // Method to remove existing triggers for the specified table name
        private static void RemoveTriggers(string tableName, SqlConnection connection)
        {
            try
            {
                // Remove update trigger if it exists
                string removeUpdateTriggerQuery = $@"
                    IF EXISTS (SELECT * FROM sys.triggers WHERE name = '{tableName}Trigger_UPDATE')
                    BEGIN
                        DROP TRIGGER [dbo].[{tableName}Trigger_UPDATE]
                    END";

                using (SqlCommand command = new SqlCommand(removeUpdateTriggerQuery, connection))
                {
                    command.ExecuteNonQuery();
                }

                // Remove delete trigger if it exists
                string removeDeleteTriggerQuery = $@"
                    IF EXISTS (SELECT * FROM sys.triggers WHERE name = '{tableName}Trigger_DELETE')
                    BEGIN
                        DROP TRIGGER [dbo].[{tableName}Trigger_DELETE]
                    END";

                using (SqlCommand command = new SqlCommand(removeDeleteTriggerQuery, connection))
                {
                    command.ExecuteNonQuery();
                }

                // Display success message after removing existing triggers
                Console.WriteLine($"Existing triggers for {tableName} removed successfully!");
            }
            catch (Exception ex)
            {
                // Display error message if an exception occurs during trigger removal
                Console.WriteLine($"Failed to remove existing triggers for {tableName}: " + ex.Message);
            }
        }
    }
}
