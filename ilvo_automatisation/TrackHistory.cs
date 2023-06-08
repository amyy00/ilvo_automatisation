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

            try
            {
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
                Console.WriteLine("Trigger update stal created successfully!");
            }
            catch (Exception ex)
            {

                Console.WriteLine("Trigger update stal: " + ex.Message);
            }

            try
            {
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
                Console.WriteLine("Triggers delete stal created successfully!");
            }
            catch (Exception ex)
            {

                Console.WriteLine("Trigger delete stal: " + ex.Message);
            }

            try
            {
                // Trigger for pas update
                string updateTriggerQueryPas = @"
                CREATE TRIGGER [dbo].[tblPASTrigger_UPDATE] ON [dbo].[tblPAS]
                AFTER UPDATE AS
                BEGIN
                    SET NOCOUNT ON;
                    DECLARE @ID uniqueidentifier, @Naam nvarchar(50), @ReductiePercentage float, @PASStal bit, @PASVoeding bit, @PASWeide bit, @VersieID uniqueidentifier,
                    @WeideUren float, @Staltype nvarchar(10), @EFNH3Traditioneel float
                    SELECT @ID = dbo.tblPAS.ID, @Naam = dbo.tblPAS.Naam, @ReductiePercentage = dbo.tblPAS.ReductiePercentage, @PASStal = dbo.tblPAS.PASStal, 
                    @PASVoeding = dbo.tblPAS.PASVoeding, @PASWeide = dbo.tblPAS.PASWeide, @VersieID = dbo.tblPAS.VersieID--,
                    --@WeideUren =  dbo.tblPAS.WeideUren, @Staltype =  dbo.tblPAS.Staltype, @EFNH3Traditioneel =  dbo.tblPAS.EFNH3Traditioneel
                    FROM INSERTED, dbo.tblPAS

                    INSERT INTO history.tblPAS( ID, Naam, ReductiePercentage, PASStal, PASVoeding, PASWeide, VersieID, WeideUren, Staltype, EFNH3Traditioneel, UpdatedBy, UpdatedOn, status)
                    VALUES( @ID, @Naam, @ReductiePercentage, @PASStal, @PASVoeding, @PASWeide, @VersieID, @WeideUren, @Staltype, @EFNH3Traditioneel, SUSER_SNAME(), getdate(), 'Updated')
                END";

                using (SqlCommand command = new SqlCommand(updateTriggerQueryPas, connection))
                {
                    command.ExecuteNonQuery();
                }
                Console.WriteLine("Triggers update pas created successfully!");
            }
            catch (Exception ex)
            {

                Console.WriteLine("Trigger update pas: " + ex.Message);

            }

            try
            {
                // Trigger for pas delete
                string deleteTriggerQueryPas = @"
                CREATE TRIGGER [dbo].[tblPASTrigger_DELETE] ON [dbo].[tblPAS]
                AFTER DELETE AS
                BEGIN
                    SET NOCOUNT ON;
                    DECLARE @ID uniqueidentifier, @Naam nvarchar(50), @ReductiePercentage float, @PASStal bit, @PASVoeding bit, @PASWeide bit, @VersieID uniqueidentifier, 
                    @WeideUren float, @Staltype nvarchar(10), @EFNH3Traditioneel float
                    SELECT @ID = DELETED.ID, @Naam = DELETED.Naam, @ReductiePercentage = DELETED.ReductiePercentage, @PASStal = DELETED.PASStal,
                    @PASVoeding = DELETED.PASVoeding, @PASWeide = DELETED.PASWeide, @VersieID = DELETED.VersieID--,
                    --@WeideUren = DELETED.WeideUren, @Staltype = DELETED.Staltype, @EFNH3Traditioneel = DELETED.EFNH3Traditioneel
                    FROM DELETED

                    INSERT INTO history.tblPAS( ID, Naam, ReductiePercentage, PASStal, PASVoeding, PASWeide, VersieID, WeideUren, Staltype, EFNH3Traditioneel, UpdatedBy, UpdatedOn, status)
                    VALUES( @ID, @Naam, @ReductiePercentage, @PASStal, @PASVoeding, @PASWeide, @VersieID, @WeideUren, @Staltype, @EFNH3Traditioneel, SUSER_SNAME(), getdate(), 'Deleted')
                END";

                using (SqlCommand command = new SqlCommand(deleteTriggerQueryPas, connection))
                {
                    command.ExecuteNonQuery();
                }
                Console.WriteLine("Triggers delete pas created successfully!");
            }
            catch (Exception ex)
            {

                Console.WriteLine("Trigger delete pas: " + ex.Message);
            }

            try
            {
                // Trigger for pas update
                string updateTriggerQueryVersion = @"
                CREATE TRIGGER [dbo].[tblPASTrigger_UPDATE] ON [dbo].[tblPAS]
                AFTER UPDATE AS
                BEGIN
                    SET NOCOUNT ON;
                    DECLARE @ID uniqueidentifier, @Naam nvarchar(50), @ReductiePercentage float, @PASStal bit, @PASVoeding bit, @PASWeide bit, @VersieID uniqueidentifier,
                    @WeideUren float, @Staltype nvarchar(10), @EFNH3Traditioneel float
                    SELECT @ID = dbo.tblPAS.ID, @Naam = dbo.tblPAS.Naam, @ReductiePercentage = dbo.tblPAS.ReductiePercentage, @PASStal = dbo.tblPAS.PASStal, 
                    @PASVoeding = dbo.tblPAS.PASVoeding, @PASWeide = dbo.tblPAS.PASWeide, @VersieID = dbo.tblPAS.VersieID--,
                    --@WeideUren =  dbo.tblPAS.WeideUren, @Staltype =  dbo.tblPAS.Staltype, @EFNH3Traditioneel =  dbo.tblPAS.EFNH3Traditioneel
                    FROM INSERTED, dbo.tblPAS

                    INSERT INTO history.tblPAS( ID, Naam, ReductiePercentage, PASStal, PASVoeding, PASWeide, VersieID, WeideUren, Staltype, EFNH3Traditioneel, UpdatedBy, UpdatedOn, status)
                    VALUES( @ID, @Naam, @ReductiePercentage, @PASStal, @PASVoeding, @PASWeide, @VersieID, @WeideUren, @Staltype, @EFNH3Traditioneel, SUSER_SNAME(), getdate(), 'Updated')
                END";

                using (SqlCommand command = new SqlCommand(updateTriggerQueryVersion, connection))
                {
                    command.ExecuteNonQuery();
                }
                Console.WriteLine("Triggers update version created successfully!");
            }
            catch (Exception ex)
            {

                Console.WriteLine("Trigger update version: " + ex.Message);

            }

            try
            {
                // Trigger for pas delete
                string deleteTriggerQueryVersion = @"
                CREATE TRIGGER [dbo].[tblVersieTrigger_DELETE] ON [dbo].[tblVersie]
                AFTER DELETE AS
                BEGIN
                    SET NOCOUNT ON;
                    DECLARE @ID uniqueidentifier, @Naam nvarchar(50), @GebruikerID uniqueidentifier, @Publiek bit
                    SELECT @ID = DELETED.ID, @Naam = DELETED.Naam, @GebruikerID = DELETED.GebruikerID, @Publiek = DELETED.Publiek
                    FROM DELETED

                    INSERT INTO history.tblVersie( ID, Naam, GebruikerID, Publiek, UpdatedBy, UpdatedOn, status)
                    VALUES( @ID,  @Naam, @GebruikerID, @Publiek, SUSER_SNAME(), getdate(), 'Deleted')
                END";

                using (SqlCommand command = new SqlCommand(deleteTriggerQueryVersion, connection))
                {
                    command.ExecuteNonQuery();
                }
                Console.WriteLine("Triggers delete Version created successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Trigger delete Version: " + ex.Message);
            }


            try
            {
                // Trigger for pas update
                string updateTriggerQueryGewassen = @"
                CREATE TRIGGER [dbo].[lnkGewassenTrigger_DELETE] ON [dbo].[lnkGewassen]
                AFTER DELETE AS
                BEGIN
                    SET NOCOUNT ON;
                    DECLARE @ID uniqueidentifier, @CodeHoofdTeelt int, @GewasGroepID uniqueidentifier, @VersieID uniqueidentifier, @OmsHoofdTeelt nvarchar(100), @GewasGroepOogstrestID uniqueidentifier
                    SELECT @ID = DELETED.ID, @CodeHoofdTeelt = DELETED.CodeHoofdTeelt, @GewasGroepID = DELETED.GewasGroepID, @VersieID = DELETED.VersieID,
                    @OmsHoofdTeelt = DELETED.OmsHoofdTeelt, @GewasGroepOogstrestID = DELETED.GewasGroepOogstrestID
                    FROM DELETED

                    INSERT INTO history.lnkGewassen( ID, CodeHoofdTeelt, GewasGroepID, VersieID, OmsHoofdTeelt, GewasGroepOogstrestID, UpdatedBy, UpdatedOn, status)
                    VALUES( @ID, @CodeHoofdTeelt, @GewasGroepID, @VersieID, @OmsHoofdTeelt, @GewasGroepOogstrestID,SUSER_SNAME(), getdate(), 'Deleted')
                END";

                using (SqlCommand command = new SqlCommand(updateTriggerQueryGewassen, connection))
                {
                    command.ExecuteNonQuery();
                }
                Console.WriteLine("Triggers update gewassen created successfully!");
            }
            catch (Exception ex)
            {

                Console.WriteLine("Trigger update gewassen: " + ex.Message);

            }

            try
            {
                // Trigger for pas delete
                string deleteTriggerQueryGewassen = @"
                CREATE TRIGGER [dbo].[lnkGewassenTrigger_UPDATE] ON [dbo].[lnkGewassen]
                AFTER UPDATE AS
                BEGIN
                    set NOCOUNT ON;
                    DECLARE @ID uniqueidentifier, @CodeHoofdTeelt int, @GewasGroepID uniqueidentifier, @VersieID uniqueidentifier, @OmsHoofdTeelt nvarchar(100), @GewasGroepOogstrestID uniqueidentifier
                    SELECT @ID = dbo.lnkGewassen.ID, @CodeHoofdTeelt = dbo.lnkGewassen.CodeHoofdTeelt, @GewasGroepID = dbo.lnkGewassen.GewasGroepID, @VersieID = dbo.lnkGewassen.VersieID,
                    @OmsHoofdTeelt = dbo.lnkGewassen.OmsHoofdTeelt, @GewasGroepOogstrestID = dbo.lnkGewassen.GewasGroepOogstrestID
                    FROM INSERTED, dbo.lnkGewassen

                    INSERT INTO history.lnkGewassen( ID, CodeHoofdTeelt, GewasGroepID, VersieID, OmsHoofdTeelt, GewasGroepOogstrestID, UpdatedBy, UpdatedOn, status)
                    VALUES( @ID, @CodeHoofdTeelt, @GewasGroepID, @VersieID, @OmsHoofdTeelt, @GewasGroepOogstrestID, SUSER_SNAME(), getdate(), 'Updated')
                END";

                using (SqlCommand command = new SqlCommand(deleteTriggerQueryGewassen, connection))
                {
                    command.ExecuteNonQuery();
                }
                Console.WriteLine("Triggers delete gewassen created successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Trigger gewassen Version: " + ex.Message);
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
