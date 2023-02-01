namespace GiftCertificateValidator.Maui.Services.Database;

internal interface IDatabaseService
{
    bool CreateDatabaseIfNotExists();
    bool CreateTableIfNotExistsAsync();
}