using ilvo_automatisation.Data;
using Microsoft.Data.SqlClient;
using System;

namespace ilvo_automatisation
{
    public class TrackHistory
    {
        public static void CreateTriggers(SqlConnection connection)
        {
            // Register triggers for update and delete operations on the tables

            // Trigger for stal update
            string updateTriggerQueryStal = @"
                Create TRIGGER [dbo].[tblStalTrigger_UPDATE] ON [dbo].[tblStal]
                AFTER UPDATE AS
                BEGIN
                    SET NOCOUNT ON;
                    DECLARE @ID uniqueidentifier, @Naam nvarchar(100), @Omschrijving nvarchar(250), @FractieVloeibaar float, @ReductiePercentage float, 
                    @MestTypeID uniqueidentifier, @StalTypeID uniqueidentifier, @VersieID uniqueidentifier
                    SELECT @ID = dbo.tblStal.ID, @Naam = dbo.tblStal.Naam, @Omschrijving = dbo.tblStal.Omschrijving, @FractieVloeibaar = dbo.tblStal.FractieVloeibaar, 
                    @ReductiePercentage = dbo.tblStal.ReductiePercentage, @MestTypeID = dbo.tblStal.MestTypeID, @StalTypeID = dbo.tblStal.StalTypeID, @VersieID = dbo.tblStal.VersieID
                    FROM INSERTED, dbo.tblStal

                    INSERT INTO history.tblStal( ID, Naam, Omschrijving, FractieVloeibaar, ReductiePercentage, MestTypeID, StalTypeID, VersieID, UpdatedBy, UpdatedOn, status)
                    VALUES( @ID, @Naam, @Omschrijving, @FractieVloeibaar, @ReductiePercentage, @MestTypeID, @StalTypeID, @VersieID, SUSER_SNAME(), getdate(), 'Updated')
                END";

            using (SqlCommand command = new SqlCommand(updateTriggerQueryStal, connection))
            {
                command.ExecuteNonQuery();
            }

            // Trigger for stal delete
            string deleteTriggerQueryStal = @"
                CREATE TRIGGER [dbo].[tblStalTrigger_DELETE] ON [dbo].[tblStal]
                AFTER DELETE AS
                BEGIN
                    SET NOCOUNT ON;
                    DECLARE @ID uniqueidentifier, @Naam nvarchar(100), @Omschrijving nvarchar(250), @FractieVloeibaar float, @ReductiePercentage float, 
                    @MestTypeID uniqueidentifier, @StalTypeID uniqueidentifier, @VersieID uniqueidentifier
                    SELECT @ID = DELETED.ID, @Naam = DELETED.Naam, @Omschrijving = DELETED.Omschrijving, @FractieVloeibaar = DELETED.FractieVloeibaar, 
                    @ReductiePercentage = DELETED.ReductiePercentage, @MestTypeID = DELETED.MestTypeID, @StalTypeID = DELETED.StalTypeID, @VersieID = DELETED.VersieID
                    FROM DELETED

                    INSERT INTO history.tblStal( ID, Naam, Omschrijving, FractieVloeibaar, ReductiePercentage, MestTypeID, StalTypeID, VersieID, UpdatedBy, UpdatedOn, status)
                    VALUES( @ID, @Naam, @Omschrijving, @FractieVloeibaar, @ReductiePercentage, @MestTypeID, @StalTypeID, @VersieID, SUSER_SNAME(), getdate(), 'Deleted')
                END";

            using (SqlCommand command = new SqlCommand(deleteTriggerQueryStal, connection))
            {
                command.ExecuteNonQuery();
            }

          
        }

        public static void TestTrackHistory()
        {
            string connectionString = Constants.connectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                CreateTriggers(connection);
            }

            Console.WriteLine("Triggers created successfully!");
        }
    }
}
