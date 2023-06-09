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
            // Get the class name based on the entity type
            string className = entityType.Name;

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
                DataRow idColumn = schemaTable.Rows.Cast<DataRow>()
                    .FirstOrDefault(row => row["COLUMN_NAME"].ToString().Equals("ID", StringComparison.OrdinalIgnoreCase));

                if (idColumn == null)
                {
                    throw new Exception($"ID column not found in the table: {tableName}");
                }

                // Get the data type of the ID column
                string idDataType = idColumn["DATA_TYPE"].ToString();

                try
                {
                    // Remove existing triggers
                    RemoveTriggers(tableName, connection);

                    // Trigger for update
                    string updateTriggerQuery = $@"
                    CREATE TRIGGER [dbo].[{tableName}Trigger_UPDATE] ON [dbo].[{tableName}]
                    AFTER UPDATE AS
                    BEGIN
                        SET NOCOUNT ON;
                        DECLARE @ID {idDataType}

                        SELECT @ID = dbo.{tableName}.ID
                        FROM INSERTED, dbo.{tableName}

                        INSERT INTO history.{tableName}({string.Join(",", entityType.GetProperties().Select(p => $"[{p.Name}]"))})
                        VALUES(({string.Join(",", entityType.GetProperties().Select(p => $"INSERTED.[{p.Name}]"))}), SUSER_SNAME(), GETDATE(), 'Updated')
                    END";

                    // Execute the update trigger query using a SqlCommand
                    using (SqlCommand command = new SqlCommand(updateTriggerQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    // Display success message after creating the update trigger
                    Console.WriteLine($"Trigger update {tableName.ToLower()} created successfully!");
                }
                catch (Exception ex)
                {
                    // Display error message if an exception occurs during update trigger creation
                    Console.WriteLine($"Trigger update {className.ToLower()}: " + ex.Message);
                }

                try
                {
                    // Trigger for delete
                    string deleteTriggerQuery = $@"
                    CREATE TRIGGER [dbo].[{tableName}Trigger_DELETE] ON [dbo].[{tableName}]
                    AFTER DELETE AS
                    BEGIN
                        SET NOCOUNT ON;
                        DECLARE @ID {idDataType}

                        SELECT @ID = DELETED.ID
                        FROM DELETED

                        INSERT INTO history.{tableName}({string.Join(",", entityType.GetProperties().Select(p => $"[{p.Name}]"))})
                        VALUES({string.Join(",", entityType.GetProperties().Select(p => $"DELETED.[{p.Name}]"))}, SUSER_SNAME(), GETDATE(), 'Deleted')
                    END";

                    // Execute the delete trigger query using a SqlCommand
                    using (SqlCommand command = new SqlCommand(deleteTriggerQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    // Display success message after creating the delete trigger
                    Console.WriteLine($"Trigger delete {tableName.ToLower()} created successfully!");
                }
                catch (Exception ex)
                {
                    // Display error message if an exception occurs during delete trigger creation
                    Console.WriteLine($"Trigger delete {className.ToLower()}: " + ex.Message);
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
                Console.WriteLine($"Existing triggers for {tableName.ToLower()} removed successfully!");
            }
            catch (Exception ex)
            {
                // Display error message if an exception occurs during trigger removal
                Console.WriteLine($"Failed to remove existing triggers for {tableName.ToLower()}: " + ex.Message);
            }
        }
    }
}