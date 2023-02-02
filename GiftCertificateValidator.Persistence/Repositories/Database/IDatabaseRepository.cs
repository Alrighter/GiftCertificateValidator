namespace GiftCertificateValidator.Persistence.Repositories.Database;

public interface IDatabaseRepository
{
    bool CreateDatabaseIfNotExists();
    bool CreateGiftCertificateTable();
}