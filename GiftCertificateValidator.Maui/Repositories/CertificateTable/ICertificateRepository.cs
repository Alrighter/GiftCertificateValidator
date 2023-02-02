using GiftCertificateValidator.Maui.Model;

namespace GiftCertificateValidator.Maui.Repositories.CertificateTable;

public interface ICertificateRepository
{
    Task<GiftCertificate> GetCertificateAsync(string certificateCode);
    Task<IEnumerable<GiftCertificate>> GetCertificatesAsync();
    Task<bool> AddCertificateAsync(GiftCertificate certificate);
    Task<bool> UpdateCertificateAsync(GiftCertificate certificate);
    Task<bool> ChangeCertificateStatusAsync(string certificateCode);
}