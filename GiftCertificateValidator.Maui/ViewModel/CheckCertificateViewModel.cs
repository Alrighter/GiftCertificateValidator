using GiftCertificateValidator.Maui.View;

namespace GiftCertificateValidator.Maui.ViewModel;

public class CheckCertificateViewModel : BaseViewModel
{
    private string _scannedQr;

    public CheckCertificateViewModel()
    {
        Title = "Scan GiftCertificate";
    }

    //call async method when scannedQr changed
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

        await Shell.Current.GoToAsync($"{nameof(DetailsPage)}?Code={ScannedQr}");
    }
}