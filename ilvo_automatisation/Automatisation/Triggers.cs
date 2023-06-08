﻿using ilvo_automatisation.Data;
using Microsoft.Data.SqlClient;

namespace ilvo_automatisation.Automatisation;

public class Triggers
{
    // Method to automate triggers for the specified entity type
    // TODO: Add check for update or create trigger
    public static void AutomateTriggers(Type entityType)
    {
        // Get the class name based on the entity type
        string className = entityType.Name;

        try
        {
            // Trigger for update
            string updateTriggerQuery = $@"
                Create TRIGGER [dbo].[{className}Trigger_UPDATE] ON [dbo].[{className}]
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
            // Trigger for delete
            string deleteTriggerQuery = $@"
                CREATE TRIGGER [dbo].[{className}Trigger_DELETE] ON [dbo].[{className}]
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
            Console.WriteLine($"Triggers delete {className.ToLower()} created successfully!");
        }
        catch (Exception ex)
        {
            // Display error message if an exception occurs during delete trigger creation
            Console.WriteLine($"Trigger delete {className.ToLower()}: " + ex.Message);
        }
    }
}