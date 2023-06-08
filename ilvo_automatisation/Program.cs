using System.Data;
using System.Globalization;
using ilvo_automatisation.Data;
using ilvo_automatisation.Data.Test;
using ilvo_automatisation.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.FileIO;

namespace ilvo_automatisation;

public class Program
{
    public static void Main(string[] args)
    {
        // Get the default output path
        string outputPath = GetDefaultOutputPath();

        string connectionString = Constants.connectionString;

        // Create the DbContext using the provided connection string
        using var dbContext =
            new EmavContext(new DbContextOptionsBuilder<EmavContext>().UseSqlServer(connectionString).Options);

        // Generate classes and CSV files
        GenerateCSV.GenerateFile(dbContext, outputPath);

        //To fill the database with mock data
        // GenerateMockData.GenerateData();
        string filePath = @"C:\\\Users\\steven\\DatabaseClasses\DatabaseClasses_20230607_100956.csv";
        // var dataTabletFromCsvFile = GetDataTableFromCSVFile(filePath);
        //
        // DataSet ds = new DataSet();
        // ds.Locale = CultureInfo.InvariantCulture;
        // FillDataSet(ds);
        // var foundTable = GetDataTableFromCSVFile(filePath);
        // DataTable stallen = ds.Tables["TblStal"];
        //
        // var query =
        //     from stal in stallen.AsEnumerable()
        //     where stal.Field<string>("Naam") == "kiwi"
        //     select new
        //     {
        //         ID = stal.Field<Guid>("ID"),
        //         Omschrijving = stal.Field<string>("Omschrijving"),
        //         FractieVloeibaar = stal.Field<double>("FractieVloeibaar"),
        //         ReductiePercentage = stal.Field<double>("ReductiePercentage"),
        //         MestTypeId = stal.Field<Guid>("MestTypeId"),
        //         StalTypeId = stal.Field<Guid>("StalTypeId"),
        //         VersieId = stal.Field<Guid>("VersieId"),
        //     };
        // foreach (var stal in query)
        // {
        //     Console.WriteLine(" ID: {0} Omschrijving: {1} FractieVloeibaar: {2} ReductiePercentage: {3}  MestTypeId: {4} StalTypeId: {5}  VersieId: {6} ",
        //         stal.ID,                   
        //         stal.Omschrijving,
        //         stal.FractieVloeibaar, 
        //         stal.ReductiePercentage, 
        //         stal.MestTypeId,  
        //         stal.StalTypeId,
        //         stal.VersieId
        //     );
        // }


        //     StreamReader reader = null;
        //     if (File.Exists(filePath))
        //     {
        //         reader = new StreamReader(File.OpenRead(filePath));
        //         List<TblStal> stals = new List<TblStal>();
        //         List<string> listA = new List<string>();
        //         while (!reader.EndOfStream)
        //         {
        //             var readLine = reader.ReadLine();
        //             var values = readLine.Split(',');
        //             foreach (var item in values)
        //             {
        //                 listA.Add(item);
        //             }
        //             Console.WriteLine(readLine);
        //             foreach (var column in listA)
        //             {
        //                 Console.WriteLine(column);
        //             }
        //         }
        //     }
        //     else
        //     {
        //         Console.WriteLine("file doesnt exist");
        //     }
        //
        //     Console.ReadLine();
        // }

        static string GetDefaultOutputPath()
        {
            string homeDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string defaultOutputPath = Path.Combine(homeDirectory, "DatabaseClasses");
            Directory.CreateDirectory(defaultOutputPath);
            return defaultOutputPath;
        }

        static DataTable GetDataTableFromCSVFile(string csv_file_path)
        {
            DataTable csvData = new DataTable();
            try
            {

                using (TextFieldParser csvReader = new TextFieldParser(csv_file_path))
                {
                    csvReader.SetDelimiters(new string[] {";"});
                    csvReader.HasFieldsEnclosedInQuotes = true;
                    string[] colFields = csvReader.ReadFields();
                    foreach (string column in colFields)
                    {
                        DataColumn datecolumn = new DataColumn(column);
                        datecolumn.AllowDBNull = true;
                        csvData.Columns.Add(datecolumn);
                    }

                    while (!csvReader.EndOfData)
                    {
                        string[] fieldData = csvReader.ReadFields();
                        //Making empty value as null
                        for (int i = 0; i < fieldData.Length; i++)
                        {
                            if (fieldData[i] == "")
                            {
                                fieldData[i] = null;
                            }
                        }

                        csvData.Rows.Add(fieldData);
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return csvData;
        }
    }
}

//  static void FillDataSet(DataSet ds)
    // {
    //     var csvDataSet = new DataSet();
    //     string filePath1 = @"C:\\\Users\\steven\\DatabaseClasses\DatabaseClasses_20230607_100956.csv";
    //     try
    //     {
    //
    //         using (TextFieldParser csvReader = new TextFieldParser(filePath1))
    //         {
    //             csvReader.SetDelimiters(new string[] {";"});
    //             csvReader.HasFieldsEnclosedInQuotes = true;
    //             string[] colFields = csvReader.ReadFields();
    //             foreach (string column in colFields)
    //             {
    //                 DataColumn datecolumn = new DataColumn(column);
    //                 datecolumn.AllowDBNull = true;
    //                 csvDataSet.Columns.Add(datecolumn);
    //             }
    //
    //             while (!csvReader.EndOfData)
    //             {
    //                 string[] fieldData = csvReader.ReadFields();
    //                 //Making empty value as null
    //                 for (int i = 0; i < fieldData.Length; i++)
    //                 {
    //                     if (fieldData[i] == "")
    //                     {
    //                         fieldData[i] = null;
    //                     }
    //                 }
    //
    //                 csvData.Rows.Add(fieldData);
    //             }
    //         }
    //     }
    //     catch (Exception ex)
    //     {
    //     }
    //
    //     return csvDataSet;
    // }
//     }
// }