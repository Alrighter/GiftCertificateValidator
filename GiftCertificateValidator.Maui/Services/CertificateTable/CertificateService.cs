using GiftCertificateValidator.Domain.Model;

namespace GiftCertificateValidator.Maui.Services.CertificateTable;

internal class CertificateService : ICertificateService
{
    public Task<bool> AddCertificate(GiftCertificate certificate)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ChangeCertificateStatus(string certificateCode)
    {
        throw new NotImplementedException();
    }

    public Task<GiftCertificate> GetCertificate(string certificateCode)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<GiftCertificate>> GetCertificates()
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateCertificate(GiftCertificate certificate)
    {
        throw new NotImplementedException();
    }
}