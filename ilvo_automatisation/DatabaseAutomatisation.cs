using Microsoft.Data.SqlClient;
using System;

namespace ilvo_automatisation
{
    public class DatabaseAutomatisation
    {
        private SqlConnection connection;

        public DatabaseAutomatisation(SqlConnection connection)
        {
            this.connection = connection;
        }

        public void CreateOrUpdateTriggers()
        {
            CreateOrUpdateTrigger("tblStal");
            CreateOrUpdateTrigger("tblPAS");
            CreateOrUpdateTrigger("tblVersie");
            CreateOrUpdateTrigger("lnkGewassen");
        }

        private void CreateOrUpdateTrigger(string tableName)
        {
            string triggerName = $"tbl{tableName}Trigger_DDL";

            try
            {
                string createTriggerQuery = $@"
                IF EXISTS (
                    SELECT *
                    FROM sys.triggers
                    WHERE name = @triggerName
                )
                BEGIN
                    -- Trigger already exists, modify it if needed
                    -- Update the trigger code here
                    ALTER TRIGGER {triggerName} ON DATABASE
                    FOR CREATE_TABLE, ALTER_TABLE, DROP_TABLE
                    AS
                    BEGIN
                        -- Trigger logic here
                        -- Example: log the DDL changes in a separate table
                        INSERT INTO DDLLogTable (EventTime, EventType, TableName)
                        VALUES (GETDATE(), EVENTDATA().value('(/EVENT_INSTANCE/EventType)[1]', 'nvarchar(100)'), EVENTDATA().value('(/EVENT_INSTANCE/ObjectName)[1]', 'nvarchar(100)'))
                    END
                END
                ELSE
                BEGIN
                    -- Trigger does not exist, create it
                    -- Create the trigger code here
                    DECLARE @createDDLTriggerQuery NVARCHAR(MAX) = N'
                    CREATE TRIGGER ' + QUOTENAME(@triggerName) + '
                    ON DATABASE
                    FOR CREATE_TABLE, ALTER_TABLE, DROP_TABLE
                    AS
                    BEGIN
                        -- Trigger logic here
                        -- Example: log the DDL changes in a separate table
                        INSERT INTO DDLLogTable (EventTime, EventType, TableName)
                        VALUES (GETDATE(), EVENTDATA().value(''(/EVENT_INSTANCE/EventType)[1]'', ''nvarchar(100)''), EVENTDATA().value(''(/EVENT_INSTANCE/ObjectName)[1]'', ''nvarchar(100)''))
                    END'

                    EXEC sp_executesql @createDDLTriggerQuery, N'@triggerName NVARCHAR(100)', @triggerName = @triggerName
                END";

                using (SqlCommand command = new SqlCommand(createTriggerQuery, connection))
                {
                    command.Parameters.AddWithValue("@triggerName", triggerName);
                    command.ExecuteNonQuery();
                }

                Console.WriteLine($"Trigger {triggerName} created or updated successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating or updating trigger {triggerName}: {ex.Message}");
            }
        }
    }
}
