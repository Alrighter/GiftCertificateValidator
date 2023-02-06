using GiftCertificateValidator.Maui.Model;

namespace GiftCertificateValidator.Maui.Repositories.CertificateTable;

public interface ICertificateRepository
{
    Task<BaseResponse<GiftCertificate>> GetCertificateAsync(string certificateCode);
    Task<BaseResponse<IEnumerable<GiftCertificate>>> GetCertificatesAsync();
    Task<BaseResponse<bool>> AddCertificateAsync(GiftCertificate certificate);
    Task<BaseResponse<bool>> UpdateCertificateAsync(GiftCertificate certificate);
    Task<BaseResponse<bool>> ChangeCertificateStatusAsync(string certificateCode);
}