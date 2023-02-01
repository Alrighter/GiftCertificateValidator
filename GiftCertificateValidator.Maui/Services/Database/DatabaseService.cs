using GiftCertificateValidator.Persistence.Repositories.Database;

namespace GiftCertificateValidator.Maui.Services.Database;

internal class DatabaseService : IDatabaseService
{
    private readonly IDatabaseRepository _databaseRepository;

    public DatabaseService(IDatabaseRepository databaseRepository)
    {
        _databaseRepository = databaseRepository;
    }

    public bool CreateDatabaseIfNotExists()
    {
        return _databaseRepository.CreateDatabaseIfNotExists();
    }

    public bool CreateTableIfNotExistsAsync()
    {
        return _databaseRepository.CreateTableIfNotExistsAsync();
    }
}