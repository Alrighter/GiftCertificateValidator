using System.Diagnostics;
using Dapper;
using GiftCertificateValidator.Domain.Model;
using GiftCertificateValidator.Persistence.DB;

namespace GiftCertificateValidator.Persistence.Repositories.CertificateTable;

public class CertificateRepository : ICertificateRepository
{
    private readonly DatabaseConnection _dbConnection;

    public CertificateRepository(DatabaseConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<GiftCertificate> GetCertificate(string certificateCode)
    {
        try
        {
            var connection = await _dbConnection.GetConnection();
            var certificate = await connection
                .QueryFirstOrDefaultAsync<GiftCertificate>("SELECT * FROM GiftCertificate WHERE Code = @Code",
                    new { Code = certificateCode });
            return certificate;
        }
        catch (Exception e)
        {
            Debug.WriteLine("Error getting certificate: " + e.Message);
            return new GiftCertificate();
        }
    }

    public async Task<IEnumerable<GiftCertificate>> GetCertificates()
    {
        try
        {
            var connection = await _dbConnection.GetConnection();
            var certificates = await connection.QueryAsync<GiftCertificate>("SELECT * FROM GiftCertificate");
            return certificates;
        }
        catch (Exception e)
        {
            Debug.WriteLine("Error getting certificates: " + e.Message);
            return new List<GiftCertificate>();
        }
    }

    public async Task<bool> AddCertificate(GiftCertificate certificate)
    {
        try
        {
            var connection = await _dbConnection.GetConnection();
            var result = await connection
                .ExecuteAsync(@"INSERT INTO GiftCertificate (
                                        Code, 
                                        Name, 
                                        Description, 
                                        Discount, 
                                        DateCreated, 
                                        IsUsed) 
                                        VALUES (
                                        @Code, 
                                        @Name, 
                                        @Description, 
                                        @Discount, 
                                        @DateCreated, 
                                        @IsUsed)",
                    certificate);
            return result > 0;
        }
        catch (Exception e)
        {
            Debug.WriteLine("Error adding new certificate: " + e.Message);
            return false;
        }
    }

    public async Task<bool> UpdateCertificate(GiftCertificate certificate)
    {
        try
        {
            var connection = await _dbConnection.GetConnection();
            var result = await connection
                .ExecuteAsync(@"UPDATE GiftCertificate SET 
                                        Name = @Name, 
                                        Description = @Description, 
                                        Discount = @Discount, 
                                        DateCreated = @DateCreated, 
                                        IsUsed = @IsUsed 
                                        WHERE Code = @Code",
                    certificate);

            return result > 0;
        }
        catch (Exception e)
        {
            Debug.WriteLine("Error updating certificate: " + e.Message);
            return false;
        }
    }

    public async Task<bool> ChangeCertificateStatus(string certificateCode)
    {
        try
        {
            var connection = await _dbConnection.GetConnection();
            var result = await connection
                .ExecuteAsync(@"UPDATE GiftCertificate SET 
                                        IsUsed = 1, 
                                        DateUsed = @DateUsed 
                                        WHERE Code = @Code",
                    new { Code = certificateCode, DateUsed = DateTime.Now });

            return result > 0;
        }
        catch (Exception e)
        {
            Debug.WriteLine("Error changing certificate status: " + e.Message);
            return false;
        }
    }
}