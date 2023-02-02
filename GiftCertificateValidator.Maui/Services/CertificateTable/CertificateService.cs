using GiftCertificateValidator.Maui.Model;
using GiftCertificateValidator.Maui.Repositories.CertificateTable;

namespace GiftCertificateValidator.Maui.Services.CertificateTable;

internal class CertificateService : ICertificateService
{
    private readonly ICertificateRepository _certificateRepository;

    public CertificateService(ICertificateRepository certificateRepository)
    {
        _certificateRepository = certificateRepository;
    }

    public async Task<GiftCertificate> GetCertificateAsync(string certificateCode)
    {
        return await _certificateRepository.GetCertificateAsync(certificateCode);
    }

    public async Task<IEnumerable<GiftCertificate>> GetCertificatesAsync()
    {
        return await _certificateRepository.GetCertificatesAsync();
    }

    public async Task<bool> AddCertificateAsync(GiftCertificate certificate)
    {
        return await _certificateRepository.AddCertificateAsync(certificate);
    }

    public async Task<bool> UpdateCertificateAsync(GiftCertificate certificate)
    {
        return await _certificateRepository.UpdateCertificateAsync(certificate);
    }

    public async Task<bool> ChangeCertificateStatusAsync(string certificateCode)
    {
        return await _certificateRepository.ChangeCertificateStatusAsync(certificateCode);
    }
}