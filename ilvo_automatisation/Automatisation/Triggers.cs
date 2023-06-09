using ilvo_automatisation.Data;
using Microsoft.Data.SqlClient;
using System;
using System.ComponentModel.DataAnnotations.Schema;

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
                // Get the table name based on the entity type
                string tableName = entityType.GetCustomAttributesData()
                    .FirstOrDefault(x => x.AttributeType == typeof(TableAttribute))
                    ?.ConstructorArguments
                    .FirstOrDefault()
                    .Value
                    .ToString();

                // Remove existing triggers
                RemoveTriggers(tableName);

                // Trigger for update
                string updateTriggerQuery = $@"
                    CREATE TRIGGER [dbo].[{tableName}Trigger_UPDATE] ON [dbo].[{tableName}]
                    AFTER UPDATE AS
                    BEGIN
                        SET NOCOUNT ON;
                        DECLARE @ID uniqueidentifier

                        SELECT @ID = dbo.{tableName}.ID
                        FROM INSERTED, dbo.{tableName}

                        INSERT INTO history.{tableName}({string.Join(",", entityType.GetProperties().Select(p => p.Name))})
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
                Console.WriteLine($"Trigger update {tableName.ToLower()} created successfully!");
            }
            catch (Exception ex)
            {
                // Display error message if an exception occurs during update trigger creation
                Console.WriteLine($"Trigger update {className.ToLower()}: " + ex.Message);
            }

            try
            {
                // Get the table name based on the entity type
                string tableName = entityType.GetCustomAttributesData()
                    .FirstOrDefault(x => x.AttributeType == typeof(TableAttribute))
                    ?.ConstructorArguments
                    .FirstOrDefault()
                    .Value
                    .ToString();

                // Trigger for delete
                string deleteTriggerQuery = $@"
                    CREATE TRIGGER [dbo].[{tableName}Trigger_DELETE] ON [dbo].[{tableName}]
                    AFTER DELETE AS
                    BEGIN
                        SET NOCOUNT ON;
                        DECLARE @ID uniqueidentifier

                        SELECT @ID = DELETED.ID
                        FROM DELETED

                        INSERT INTO history.{tableName}({string.Join(",", entityType.GetProperties().Select(p => p.Name))})
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
                Console.WriteLine($"Trigger delete {tableName.ToLower()} created successfully!");
            }
            catch (Exception ex)
            {
                // Display error message if an exception occurs during delete trigger creation
                Console.WriteLine($"Trigger delete {className.ToLower()}: " + ex.Message);
            }

        }

        // Method to remove existing triggers for the specified table name
        private static void RemoveTriggers(string tableName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Constants.connectionString))
                {
                    connection.Open();

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