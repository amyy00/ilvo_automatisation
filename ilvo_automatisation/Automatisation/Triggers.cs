using ilvo_automatisation.Data;
using Microsoft.Data.SqlClient;
using System;

namespace ilvo_automatisation.Automatisation
{
    public class Triggers
    {
        // Method to automate triggers for the specified entity type
        public static void AutomateTriggers(Type entityType)
        {
            // Get the class name based on the entity type
            string className = entityType.Name;

            try
            {
                // Get the database name based on the connection string
                string databaseName = new SqlConnectionStringBuilder(Constants.connectionString).InitialCatalog;

                // Remove existing triggers
                RemoveTriggers(databaseName, className);

                // Trigger for update
                string updateTriggerQuery = $@"
                    CREATE TRIGGER [dbo].[{databaseName}_{className}Trigger_UPDATE] ON [dbo].[{className}]
                    AFTER UPDATE AS
                    BEGIN
                        SET NOCOUNT ON;
                        DECLARE @ID uniqueidentifier

                        SELECT @ID = dbo.{className}.ID
                        FROM INSERTED, dbo.{className}

                        INSERT INTO history.{className}({string.Join(",", entityType.GetProperties().Select(p => p.Name))})
                        VALUES( @ID, SUSER_SNAME(), GETDATE(), 'Updated')
                    END";

                using (SqlConnection connection = new SqlConnection(Constants.connectionString))
                {
                    connection.Open();

                    // Execute the update trigger query using a SqlCommand
                    using (SqlCommand command = new SqlCommand(updateTriggerQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }

                // Display success message after creating the update trigger
                Console.WriteLine($"Trigger update {className.ToLower()} created successfully!");
            }
            catch (Exception ex)
            {
                // Display error message if an exception occurs during update trigger creation
                Console.WriteLine($"Trigger update {className.ToLower()}: " + ex.Message);
            }

            try
            {
                // Get the database name based on the connection string
                string databaseName = new SqlConnectionStringBuilder(Constants.connectionString).InitialCatalog;

                // Trigger for delete
                string deleteTriggerQuery = $@"
                    CREATE TRIGGER [dbo].[{databaseName}_{className}Trigger_DELETE] ON [dbo].[{className}]
                    AFTER DELETE AS
                    BEGIN
                        SET NOCOUNT ON;
                        DECLARE @ID uniqueidentifier

                        SELECT @ID = DELETED.ID
                        FROM DELETED

                        INSERT INTO history.{className}({string.Join(",", entityType.GetProperties().Select(p => p.Name))})
                        VALUES( @ID, SUSER_SNAME(), GETDATE(), 'Deleted')
                    END";

                using (SqlConnection connection = new SqlConnection(Constants.connectionString))
                {
                    connection.Open();

                    // Execute the delete trigger query using a SqlCommand
                    using (SqlCommand command = new SqlCommand(deleteTriggerQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }

                // Display success message after creating the delete trigger
                Console.WriteLine($"Trigger delete {className.ToLower()} created successfully!");
            }
            catch (Exception ex)
            {
                // Display error message if an exception occurs during delete trigger creation
                Console.WriteLine($"Trigger delete {className.ToLower()}: " + ex.Message);
            }

        }

        // Method to remove existing triggers for the specified class name
        private static void RemoveTriggers(string databaseName, string className)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Constants.connectionString))
                {
                    connection.Open();

                    // Remove update trigger if it exists
                    string removeUpdateTriggerQuery = $@"
                        IF EXISTS (SELECT * FROM sys.triggers WHERE name = '{databaseName}_{className}Trigger_UPDATE')
                        BEGIN
                            DROP TRIGGER [dbo].[{databaseName}_{className}Trigger_UPDATE]
                        END";

                    using (SqlCommand command = new SqlCommand(removeUpdateTriggerQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    // Remove delete trigger if it exists
                    string removeDeleteTriggerQuery = $@"
                        IF EXISTS (SELECT * FROM sys.triggers WHERE name = '{databaseName}_{className}Trigger_DELETE')
                        BEGIN
                            DROP TRIGGER [dbo].[{databaseName}_{className}Trigger_DELETE]
                        END";

                    using (SqlCommand command = new SqlCommand(removeDeleteTriggerQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }

                // Display success message after removing existing triggers
                Console.WriteLine($"Existing triggers for {className.ToLower()} removed successfully!");
            }
            catch (Exception ex)
            {
                // Display error message if an exception occurs during trigger removal
                Console.WriteLine($"Failed to remove existing triggers for {className.ToLower()}: " + ex.Message);
            }
        }
    }
}
