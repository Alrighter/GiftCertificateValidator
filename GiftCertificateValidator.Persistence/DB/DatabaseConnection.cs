using Microsoft.Data.Sqlite;

namespace GiftCertificateValidator.Persistence.DB;

public class DatabaseConnection
{
    public string GetDatabasePath(string filename)
    {
        var libraryPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        var path = Path.Combine(libraryPath, filename);
        return path;
    }

    //Create databaseConnection
    public Task<SqliteConnection> GetConnection()
    {
        var databasePath = GetDatabasePath("GiftCertificateValidator.db3");
        var connection = new SqliteConnection(databasePath);
        return Task.FromResult(connection);
    }
}