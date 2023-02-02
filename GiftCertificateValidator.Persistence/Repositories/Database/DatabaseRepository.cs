using System.Diagnostics;
using GiftCertificateValidator.Domain.Model;
using GiftCertificateValidator.Persistence.DB;
using SQLite;

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
            var conn = _dbConnection.GetConnection();
            var result = conn.CreateTable<GiftCertificate>();
            return result.Equals(CreateTableResult.Created);

        }
        catch (Exception e)
        {
            Debug.WriteLine("Error creating database: " + e.Message);
            throw;
        }
    }

    public bool CreateGiftCertificateTable()
    {
        try
        {
            var connection = _dbConnection.GetConnection();
            var result = connection.CreateTable<GiftCertificate>();

            return result == CreateTableResult.Created;
        }
        catch (Exception e)
        {
            Debug.WriteLine("Error creating GiftCertificate table: " + e.Message);
            return false;
        }
    }
}