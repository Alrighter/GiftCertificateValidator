using GiftCertificateValidator.Maui.Model;
using SQLite;

namespace GiftCertificateValidator.Maui.DB;

public class DatabaseConnection
{
    private bool _isCreated;
    
    public async Task<SQLiteAsyncConnection> GetConnectionAsync()
    {
        var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "GiftCertificate.db");
        if (_isCreated) return new SQLiteAsyncConnection(databasePath,
            SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache);
        var connection = new SQLiteAsyncConnection(databasePath,
            SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache);
        await connection.CreateTableAsync<GiftCertificate>();
        _isCreated = true;

        return connection;
    }
}