using GiftCertificateValidator.Maui.Services.CertificateTable;
using GiftCertificateValidator.Maui.View;

namespace GiftCertificateValidator.Maui.ViewModel;

public class ScanCertificateViewModel : BaseViewModel
{
    private readonly ICertificateService _certificateService;
    private string _scannedQr;

    public ScanCertificateViewModel(ICertificateService certificateService)
    {
        _certificateService = certificateService;
        Title = "Add certificate";
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
            _ = GoToAddCertificate();
        }
    }

    private async Task GoToAddCertificate()
    {
        var response = await _certificateService.GetCertificateAsync(ScannedQr);

        if (response.Data != null)
        {
            await Shell.Current.DisplayAlert("Error", "Certificate is already exists", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(ScannedQr))
            return;

        await Shell.Current.GoToAsync($"{nameof(AddCertificatePage)}?Code={ScannedQr}");
    }
}