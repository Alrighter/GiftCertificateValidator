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

    public async Task<BaseResponse<GiftCertificate>> GetCertificateAsync(string certificateCode)
    { 
        try
        {
            var connection = await _databaseConnection.GetConnectionAsync();
            var certificate = await connection.Table<GiftCertificate>().FirstOrDefaultAsync(x => x.Code == certificateCode);
            return new BaseResponse<GiftCertificate>
            {
                Data = certificate,
                Success = true,
                Message = "Success"
            };
        }
        catch (Exception e)
        {
            Debug.WriteLine("Error getting certificate: " + e.Message);
            return new BaseResponse<GiftCertificate>
            {
                Data = new GiftCertificate(),
                Success = false,
                Message = "Error getting certificate"
            };
        }
    }

    public async Task<BaseResponse<IEnumerable<GiftCertificate>>> GetCertificatesAsync()
    {
        try
        {
            var connection = await _databaseConnection.GetConnectionAsync();
            var certificates = await connection.Table<GiftCertificate>().ToListAsync();
            return new BaseResponse<IEnumerable<GiftCertificate>>
            {
                Data = certificates,
                Success = true,
                Message = "Success"
            };
        }
        catch (Exception e)
        {
            Debug.WriteLine("Error getting certificates: " + e.Message);
            return new BaseResponse<IEnumerable<GiftCertificate>>
            {
            Data = new List<GiftCertificate>(),
            Success = false,
            Message = "Error getting certificates"
            };
        }
    }

    public async Task<BaseResponse<bool>> AddCertificateAsync(GiftCertificate certificate)
    {
        try
        {
            var connection = await _databaseConnection.GetConnectionAsync();
            var result = await connection.InsertAsync(certificate);
            return new BaseResponse<bool>
            {
                Data = result > 0,
                Success = true,
                Message = "Success"
            };
        }
        catch (Exception e)
        {
            Debug.WriteLine("Error adding certificate: " + e.Message);
            return new BaseResponse<bool>
            {
                Data = false,
                Success = false,
                Message = e.Message
            };
        }
    }

    public async Task<BaseResponse<bool>> UpdateCertificateAsync(GiftCertificate certificate)
    {
        try
        {
            var connection = await _databaseConnection.GetConnectionAsync();
            var result = await connection.UpdateAsync(certificate);
            return new BaseResponse<bool>
            {
                Data = result > 0,
                Success = true,
                Message = "Success"
            };
        }
        catch (Exception e)
        {
            Debug.WriteLine("Error updating certificate: " + e.Message);
            return new BaseResponse<bool>
            {
                Data = false,
                Success = false,
                Message = e.Message
            };
        }
    }

    public async Task<BaseResponse<bool>> ChangeCertificateStatusAsync(string certificateCode)
    {
        try
        {
            var connection = await _databaseConnection.GetConnectionAsync();
            var certificate = await connection.Table<GiftCertificate>().FirstOrDefaultAsync(x => x.Code == certificateCode);
            certificate.IsUsed = true;
            certificate.DateUsed = DateTime.Now;
            var result = await connection.UpdateAsync(certificate);
            return new BaseResponse<bool>
            {
                Data = result > 0,
                Success = true,
                Message = "Success"
            };
        }
        catch (Exception e)
        {
            Debug.WriteLine("Error changing certificate status: " + e.Message);
            return new BaseResponse<bool>
            {
                Data = false,
                Success = false,
                Message = e.Message
            };
        }
    }
}