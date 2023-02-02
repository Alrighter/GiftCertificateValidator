using System.Diagnostics;
using GiftCertificateValidator.Domain.Model;
using GiftCertificateValidator.Persistence.DB;
using SQLite;

namespace GiftCertificateValidator.Persistence.Repositories.CertificateTable;

public class CertificateRepository : ICertificateRepository
{
    private readonly DatabaseConnection _dbConnection;

    public CertificateRepository(DatabaseConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public GiftCertificate GetCertificate(string certificateCode)
    {
        try
        {
            var connection = _dbConnection.GetConnection();
            var certificate = connection.Table<GiftCertificate>().FirstOrDefault(x => x.Code == certificateCode);
            return certificate;
        }
        catch (Exception e)
        {
            Debug.WriteLine("Error getting certificate: " + e.Message);
            return new GiftCertificate();
        }
    }

    public IEnumerable<GiftCertificate> GetCertificates()
    {
        try
        {
            var connection = _dbConnection.GetConnection();
            var certificates = connection.Table<GiftCertificate>().AsEnumerable();
            return certificates;
        }
        catch (Exception e)
        {
            Debug.WriteLine("Error getting certificates: " + e.Message);
            return new List<GiftCertificate>();
        }
    }

    public bool AddCertificate(GiftCertificate certificate)
    {
        try
        {
            using var connection = _dbConnection.GetConnection();
            var result = connection.Insert(certificate);
            return result > 0;
        }
        catch (Exception e)
        {
            Debug.WriteLine("Error adding new certificate: " + e.Message);
            return false;
        }
    }

    public bool UpdateCertificate(GiftCertificate certificate)
    {
        try
        {
            var connection = _dbConnection.GetConnection();
            var result = connection.Update(certificate);
            return result > 0;
        }
        catch (Exception e)
        {
            Debug.WriteLine("Error updating certificate: " + e.Message);
            return false;
        }
    }

    public bool ChangeCertificateStatus(string certificateCode)
    {
        try
        {
            var connection = _dbConnection.GetConnection();
            var certificate = connection.Table<GiftCertificate>().FirstOrDefault(x => x.Code == certificateCode);
            certificate.IsUsed = !certificate.IsUsed;
            certificate.DateUsed = DateTime.Now;
            var result = connection.Update(certificate);
            return result > 0;
        }
        catch (Exception e)
        {
            Debug.WriteLine("Error changing certificate status: " + e.Message);
            return false;
        }
    }
}