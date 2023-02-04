using CommunityToolkit.Mvvm.ComponentModel;
using GiftCertificateValidator.Maui.Model;
using GiftCertificateValidator.Maui.Services.CertificateTable;
using GiftCertificateValidator.Maui.View;

namespace GiftCertificateValidator.Maui.ViewModel;

public partial class CheckCertificateViewModel : BaseViewModel
{
    private string _scannedQr;
    [ObservableProperty] GiftCertificate _certificate;
    private readonly ICertificateService _certificateService;

    public CheckCertificateViewModel(ICertificateService certificateService)
    {
        _certificateService = certificateService;
        Title = "Scan GiftCertificate";
    }

    public string ScannedQr
    {
        get => _scannedQr;
        set
        {
            if (_scannedQr == value)
                return;

            _scannedQr = value;
            OnPropertyChanged();
            _ = GoToDetailsPage();
        }
    }

    private async Task GoToDetailsPage()
    {
        if (string.IsNullOrWhiteSpace(ScannedQr))
            return;

        Certificate = await _certificateService.GetCertificateAsync(ScannedQr);

        await Shell.Current.GoToAsync($"{nameof(DetailsPage)}",
            true, new Dictionary<string, object>
            {
                {"Certificate", Certificate}
            });
    }

}