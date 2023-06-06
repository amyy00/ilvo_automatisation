using ilvo_automatisation;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main(string[] args)
    {
        GenerateMockData generateMockData;
        string connectionString = Constants.connectionString; // Replace with your database connection string
        string outputPath = GetDefaultOutputPath(); // Get the default output path
        generateMockData = new GenerateMockData();
        GenerateClasses(connectionString, outputPath);
    }

    private static string GetDefaultOutputPath()
    {
        string homeDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        string defaultOutputPath = Path.Combine(homeDirectory, "DatabaseClasses");
        Directory.CreateDirectory(defaultOutputPath);
        return defaultOutputPath;
    }

    private static void GenerateClasses(string connectionString, string outputPath)
    {
        using (var dbContext = IlvoDbContext.CreateDbContext(connectionString))
        {
            var classGenerator = new ClassGenerator(dbContext);
            classGenerator.GenerateClasses(outputPath);
        }
    }

    public static void TriggerAutomatiseren(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<IlvoDbContext>();
        optionsBuilder.UseSqlServer(Constants.connectionString);
        var dbContextOptions = optionsBuilder.Options;

        using (var dbContext = new IlvoDbContext(dbContextOptions))
        {
            dbContext.Database.ExecuteSqlRaw("CREATE TRIGGER [dbo].[lnkGewassenTrigger_DELETE] ON [dbo].[lnkGewassen]\r\n" +
                "AFTER DELETE AS\r\n" +
                "BEGIN\r\n\t" +
                "SET NOCOUNT ON;\r\n\t" +
                "DECLARE @ID uniqueidentifier, @CodeHoofdTeelt int, @GewasGroepID uniqueidentifier, @VersieID uniqueidentifier, @OmsHoofdTeelt nvarchar(100), " +
                "@GewasGroepOogstrestID uniqueidentifier\r\n\t" +
                "SELECT @ID = DELETED.ID, @CodeHoofdTeelt = DELETED.CodeHoofdTeelt, @GewasGroepID = DELETED.GewasGroepID, @VersieID = DELETED.VersieID\r\n\t" +
                "FROM DELETED\r\n\t\r\n\t" +
                "INSERT INTO history.lnkGewassen( ID, CodeHoofdTeelt, GewasGroepID, VersieID, OmsHoofdTeelt, GewasGroepOogstrestID, UpdatedBy, UpdatedOn, status)\t\r\n\t" +
                "VALUES( @ID, @CodeHoofdTeelt, @GewasGroepID, @VersieID, @OmsHoofdTeelt, @GewasGroepOogstrestID,SUSER_SNAME(), getdate(), 'Deleted')\t\r\n" +
                "END");
            dbContext.Database.ExecuteSqlRaw("create TRIGGER [dbo].[lnkGewassenTrigger_UPDATE] on [dbo].[lnkGewassen]\r\n" +
                "after UPDATE AS\r\n" +
                "begin\r\n\t" +
                "set NOCOUNT ON;\r\n\t" +
                "DECLARE @ID uniqueidentifier, @CodeHoofdTeelt int, @GewasGroepID uniqueidentifier, @VersieID uniqueidentifier, @OmsHoofdTeelt nvarchar(100)," +
                " @GewasGroepOogstrestID uniqueidentifier\r\n\t" +
                "SELECT @ID = dbo.lnkGewassen.ID, @CodeHoofdTeelt = dbo.lnkGewassen.CodeHoofdTeelt, @GewasGroepID = dbo.lnkGewassen.GewasGroepID, " +
                "@VersieID = dbo.lnkGewassen.VersieID\r\n\t" +
                "FROM INSERTED, dbo.lnkGewassen\r\n\t\r\n\t" +
                "INSERT INTO history.lnkGewassen( ID, CodeHoofdTeelt, GewasGroepID, VersieID, OmsHoofdTeelt, GewasGroepOogstrestID, UpdatedBy, UpdatedOn, status)\t\r\n\t" +
                "VALUES( @ID, @CodeHoofdTeelt, @GewasGroepID, @VersieID, @OmsHoofdTeelt, @GewasGroepOogstrestID, SUSER_SNAME(), getdate(), 'Updated')\t\r\n" +
                "END");
        }
    }
}
