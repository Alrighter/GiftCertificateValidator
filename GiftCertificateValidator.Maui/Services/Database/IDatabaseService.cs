namespace GiftCertificateValidator.Maui.Services.Database;

internal interface IDatabaseService
{
    bool CreateDatabaseIfNotExists();
    Task<bool> CreateTableIfNotExistsAsync();
}