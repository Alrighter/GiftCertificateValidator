using GiftCertificateValidator.Domain.Model;

namespace GiftCertificateValidator.Persistence.Repositories.CertificateTable;

public interface ICertificateRepository
{
    Task<GiftCertificate> GetCertificate(string certificateCode);
    Task<IEnumerable<GiftCertificate>> GetCertificates();
    Task<bool> AddCertificate(GiftCertificate certificate);
    Task<bool> UpdateCertificate(GiftCertificate certificate);
    Task<bool> ChangeCertificateStatus(string certificateCode);
}