using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GiftCertificateValidator.Maui.Model;
using GiftCertificateValidator.Maui.Services.CertificateTable;

namespace GiftCertificateValidator.Maui.ViewModel;

[QueryProperty(nameof(GiftCertificate), "Certificate")]
public partial class DetailsViewModel : BaseViewModel
{
    private readonly ICertificateService _certificateService;
    [ObservableProperty] private GiftCertificate _giftCertificate;

    public DetailsViewModel(ICertificateService certificateService)
    {
        _certificateService = certificateService;
        Title = "Details page";
    }

    [RelayCommand]
    private async Task ChangeStatus()
    {
        await _certificateService.ChangeCertificateStatusAsync(GiftCertificate.Code);
    }

    [RelayCommand]
    private async Task UpdateCertificate()
    {
        await _certificateService.UpdateCertificateAsync(GiftCertificate);
    }
}