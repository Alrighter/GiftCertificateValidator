using System.Diagnostics;
using GiftCertificateValidator.Maui.DB;
using GiftCertificateValidator.Maui.Model;

namespace GiftCertificateValidator.Maui.Repositories.CertificateTable;

public class CertificateRepository : ICertificateRepository
{
    private readonly DatabaseConnection _databaseConnection;

    public CertificateRepository(DatabaseConnection databaseConnection)
    {
        _databaseConnection = databaseConnection;
    }

    public async Task<GiftCertificate> GetCertificateAsync(string certificateCode)
    { 
        try
        {
            var connection = await _databaseConnection.GetConnectionAsync();
            var certificate = await connection.Table<GiftCertificate>().FirstOrDefaultAsync(x => x.Code == certificateCode);
            return certificate;
        }
        catch (Exception e)
        {
            Debug.WriteLine("Error getting certificate: " + e.Message);
            return new GiftCertificate();
        }
    }

    public async Task<IEnumerable<GiftCertificate>> GetCertificatesAsync()
    {
        try
        {
            var connection = await _databaseConnection.GetConnectionAsync();
            var certificates = await connection.Table<GiftCertificate>().ToListAsync();
            return certificates;
        }
        catch (Exception e)
        {
            Debug.WriteLine("Error getting certificates: " + e.Message);
            return new List<GiftCertificate>();
        }
    }

    public async Task<bool> AddCertificateAsync(GiftCertificate certificate)
    {
        try
        {
            var connection = await _databaseConnection.GetConnectionAsync();
            var result = await connection.InsertAsync(certificate);
            return result > 0;
        }
        catch (Exception e)
        {
            Debug.WriteLine("Error adding certificate: " + e.Message);
            return false;
        }
    }

    public async Task<bool> UpdateCertificateAsync(GiftCertificate certificate)
    {
        try
        {
            var connection = await _databaseConnection.GetConnectionAsync();
            var result = await connection.UpdateAsync(certificate);
            return result > 0;
        }
        catch (Exception e)
        {
            Debug.WriteLine("Error updating certificate: " + e.Message);
            return false;
        }
    }

    public async Task<bool> ChangeCertificateStatusAsync(string certificateCode)
    {
        try
        {
            var connection = await _databaseConnection.GetConnectionAsync();
            var certificate = await connection.Table<GiftCertificate>().FirstOrDefaultAsync(x => x.Code == certificateCode);
            certificate.IsUsed = certificate.IsUsed == false;
            certificate.DateUsed = DateTime.Now;
            var result = await connection.UpdateAsync(certificate);
            return result > 0;
        }
        catch (Exception e)
        {
            Debug.WriteLine("Error changing certificate status: " + e.Message);
            return false;
        }
    }
}