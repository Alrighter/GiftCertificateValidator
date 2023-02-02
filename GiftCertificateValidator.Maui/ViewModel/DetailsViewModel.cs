using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GiftCertificateValidator.Maui.Model;
using GiftCertificateValidator.Maui.Services.CertificateTable;

namespace GiftCertificateValidator.Maui.ViewModel;

[QueryProperty(nameof(CertificateCode), "Code")]
public partial class DetailsViewModel : BaseViewModel
{
    private readonly ICertificateService _certificateService;
    [ObservableProperty] private string _certificateCode;
    [ObservableProperty] private GiftCertificate _giftCertificate;

    public DetailsViewModel(ICertificateService certificateService)
    {
        _certificateService = certificateService;
        Title = "Details page";
    }

    private void GetCertificate()
    {
        Task.Run(() => _certificateService.GetCertificateAsync(CertificateCode)).Wait();
    }

    [RelayCommand]
    private async Task ChangeStatus()
    {
        await _certificateService.ChangeCertificateStatusAsync(CertificateCode);
    }

    [RelayCommand]
    private async Task UpdateCertificate()
    {
        await _certificateService.UpdateCertificateAsync(GiftCertificate);
    }
}