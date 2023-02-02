using CommunityToolkit.Mvvm.Input;
using GiftCertificateValidator.Maui.View;

namespace GiftCertificateValidator.Maui.ViewModel;

public partial class MainPageViewModel : BaseViewModel
{
    private bool _isInitialized;

    public MainPageViewModel()
    {
        Title = "Gift GiftCertificate Validator";
        Initialize();
    }

    private void Initialize()
    {
        if (_isInitialized)
            return;

        _isInitialized = true;
    }

    [RelayCommand]
    private async Task GoToAddCertificate()
    {
        await Shell.Current.GoToAsync(nameof(ScanCertificatePage));
    }

    [RelayCommand]
    private async Task GoToCheckCertificate()
    {
        await Shell.Current.GoToAsync(nameof(CheckCertificatePage));
    }

    [RelayCommand]
    private async Task GoToCertificateList()
    {
        await Shell.Current.GoToAsync(nameof(CertificateListPage));
    }
}