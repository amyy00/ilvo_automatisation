using Microsoft.Data.SqlClient;


namespace ilvo_automatisation;

public class DatabaseAutomatisation
{
    private const string ConnectionString = "YourConnectionString";

    public void UpdateHistoryTables()
    {
        // Connect to the database
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            connection.Open();

            // Check if the history table exists
            bool isHistoryTableExists = CheckIfTableExists(connection, "TblStal1");

            if (!isHistoryTableExists)
            {
                // Create the history table if it doesn't exist
                string createHistoryTableQuery = "CREATE TABLE TblStal1 (HistoryId INT IDENTITY(1,1) PRIMARY KEY, Id UNIQUEIDENTIFIER, Naam NVARCHAR(MAX) NOT NULL, Omschrijving NVARCHAR(MAX), FractieVloeibaar FLOAT NOT NULL, ReductiePercentage FLOAT, MestTypeId UNIQUEIDENTIFIER NOT NULL, StalTypeId UNIQUEIDENTIFIER NOT NULL, VersieId UNIQUEIDENTIFIER NOT NULL, UpdatedBy NVARCHAR(MAX), UpdatedOn DATETIME, Status NVARCHAR(MAX))";

                using (SqlCommand command = new SqlCommand(createHistoryTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }

            // Get the differences between the current and history tables
            var tableDifferences = GetTableDifferences(connection, "TblStal", "TblStal1");

            // Generate and execute SQL queries to update the history table
            foreach (var difference in tableDifferences)
            {
                string updateQuery = $"UPDATE TblStal1 SET {difference.ColumnName} = (SELECT {difference.ColumnName} FROM TblStal WHERE Id = TblStal1.Id)";

                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }

            // Disconnect from the database
            connection.Close();
        }
    }

    private bool CheckIfTableExists(SqlConnection connection, string tableName)
    {
        string query = $"SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '{tableName}'";

        using (SqlCommand command = new SqlCommand(query, connection))
        {
            int count = Convert.ToInt32(command.ExecuteScalar());
            return count > 0;
        }
    }

    private class TableDifference
    {
        public string ColumnName { get; set; }
    }

    private List<TableDifference> GetTableDifferences(SqlConnection connection, string tableName1, string tableName2)
    {
        string query = $"SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{tableName1}' AND COLUMN_NAME NOT IN (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{tableName2}')";

        using (SqlCommand command = new SqlCommand(query, connection))
        using (SqlDataReader reader = command.ExecuteReader())
        {
            List<TableDifference> differences = new List<TableDifference>();

            while (reader.Read())
            {
                TableDifference difference = new TableDifference
                {
                    ColumnName = reader.GetString(0)
                };

                differences.Add(difference);
            }

            return differences;
        }
    }
}