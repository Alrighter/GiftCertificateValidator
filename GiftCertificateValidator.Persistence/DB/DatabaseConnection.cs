using Microsoft.VisualBasic.FileIO;
using SQLite;

namespace GiftCertificateValidator.Persistence.DB;

public class DatabaseConnection
{
    public const string DatabaseFilename = "GiftCertificateValidator.db3";

    public const SQLiteOpenFlags Flags =
        // open the database in read/write mode
        SQLiteOpenFlags.ReadWrite |
        // create the database if it doesn't exist
        SQLiteOpenFlags.Create |
        // enable multi-threaded database access
        SQLiteOpenFlags.SharedCache;

    private static string DatabasePath =>
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "GiftCertificateValidator.db");

    //Create databaseConnection
    public SQLiteConnection GetConnection()
    {
        var databasePath = DatabasePath;
        var connection = new SQLiteConnection(databasePath);
        return connection;
    }
}