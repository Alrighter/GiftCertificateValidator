using CommunityToolkit.Mvvm.Input;
using GiftCertificateValidator.Maui.View;

namespace GiftCertificateValidator.Maui.ViewModel;

public partial class ScanCertificateViewModel : BaseViewModel
{
    public ScanCertificateViewModel() => Title = "Scan Certificate";

    private string _scannedQr;

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
            _ = GoToAddCertificate();
        }
    }

    async Task GoToAddCertificate()
    {
        if (string.IsNullOrWhiteSpace(ScannedQr))
            return;

        await Shell.Current.GoToAsync($"{nameof(AddCertificatePage)}?Code={ScannedQr}");

    }
}