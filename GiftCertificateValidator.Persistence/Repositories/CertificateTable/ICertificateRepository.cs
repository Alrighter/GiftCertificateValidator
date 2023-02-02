using GiftCertificateValidator.Domain.Model;

namespace GiftCertificateValidator.Persistence.Repositories.CertificateTable;

public interface ICertificateRepository
{
    GiftCertificate GetCertificate(string certificateCode);
    IEnumerable<GiftCertificate> GetCertificates();
    bool AddCertificate(GiftCertificate certificate);
    bool UpdateCertificate(GiftCertificate certificate);
    bool ChangeCertificateStatus(string certificateCode);
}