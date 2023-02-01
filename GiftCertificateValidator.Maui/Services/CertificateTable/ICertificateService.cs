using GiftCertificateValidator.Domain.Model;

namespace GiftCertificateValidator.Maui.Services.CertificateTable;

internal interface ICertificateService
{
    Task<GiftCertificate> GetCertificate(string certificateCode);
    Task<IEnumerable<GiftCertificate>> GetCertificates();
    Task<bool> AddCertificate(GiftCertificate certificate);
    Task<bool> UpdateCertificate(GiftCertificate certificate);
    Task<bool> ChangeCertificateStatus(string certificateCode);
}