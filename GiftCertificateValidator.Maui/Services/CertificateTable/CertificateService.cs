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

    public async Task<BaseResponse<GiftCertificate>> GetCertificateAsync(string certificateCode)
    {
        return await _certificateRepository.GetCertificateAsync(certificateCode);
    }

    public async Task<BaseResponse<IEnumerable<GiftCertificate>>> GetCertificatesAsync()
    {
        return await _certificateRepository.GetCertificatesAsync();
    }

    public async Task<BaseResponse<bool>> AddCertificateAsync(GiftCertificate certificate)
    {
        return await _certificateRepository.AddCertificateAsync(certificate);
    }

    public async Task<BaseResponse<bool>> UpdateCertificateAsync(GiftCertificate certificate)
    {
        return await _certificateRepository.UpdateCertificateAsync(certificate);
    }

    public async Task<BaseResponse<bool>> ChangeCertificateStatusAsync(string certificateCode)
    {
        return await _certificateRepository.ChangeCertificateStatusAsync(certificateCode);
    }
}