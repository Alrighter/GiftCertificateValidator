using System.Diagnostics;
using GiftCertificateValidator.Persistence.DB;

namespace GiftCertificateValidator.Persistence.Repositories.Database;

public class DatabaseRepository : IDatabaseRepository
{
    private readonly DatabaseConnection _dbConnection;

    public DatabaseRepository(DatabaseConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    //Create database if not exists
    public bool CreateDatabaseIfNotExists()
    {
        try
        {
            var databasePath = _dbConnection.GetDatabasePath("GiftCertificateValidator.db3");

            if (!File.Exists(databasePath))
                File.WriteAllBytes(databasePath, Array.Empty<byte>());

            return File.Exists(databasePath);
        }
        catch (Exception e)
        {
            Debug.WriteLine("Error creating database: " + e.Message);
            throw;
        }
    }

    //Create table if not exists
    public bool CreateTableIfNotExistsAsync()
    {
        try
        {
             using var connection =  _dbConnection.GetConnection();
             connection.OpenAsync();
             using var command = connection.CreateCommand();
            command.CommandText = @"CREATE TABLE GiftCertificates (
                                                Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                                                Code TEXT NULL,
                                                Name TEXT NULL,
                                                Description TEXT NULL,
                                                Image TEXT NULL,
                                                Discount TEXT NULL,
                                                DateCreated DATETIME NULL,
                                                DateUsed DATETIME NULL,
                                                IsUsed INTEGER NULL);";
            var result = command.ExecuteNonQuery();

            return result > 0;
        }
        catch (Exception e)
        {
            Debug.WriteLine("Error creating table: " + e.Message);
            return false;
        }
    }
}