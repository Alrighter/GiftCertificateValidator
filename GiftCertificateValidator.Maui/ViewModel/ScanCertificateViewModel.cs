using GiftCertificateValidator.Maui.View;

namespace GiftCertificateValidator.Maui.ViewModel;

public class ScanCertificateViewModel : BaseViewModel
{
    private string _scannedQr;

    public ScanCertificateViewModel()
    {
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
            _ = GoToAddCertificate();
        }
    }

    private async Task GoToAddCertificate()
    {
        if (string.IsNullOrWhiteSpace(ScannedQr))
            return;

        await Shell.Current.GoToAsync($"{nameof(AddCertificatePage)}?Code={ScannedQr}");
    }
}