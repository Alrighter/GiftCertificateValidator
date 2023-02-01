using CommunityToolkit.Mvvm.Input;
using GiftCertificateValidator.Maui.View;

namespace GiftCertificateValidator.Maui.ViewModel;

public partial class MainPageViewModel : BaseViewModel
{
    public MainPageViewModel()
    {
        Title = "Gift Certificate Validator";
    }

    [RelayCommand]
    async Task GoToAddCertificate()
    {
        await Shell.Current.GoToAsync(nameof(ScanCertificatePage));
    }

    [RelayCommand]
    async Task GoToCheckCertificate()
    {
        await Shell.Current.GoToAsync(nameof(CheckCertificatePage));
    }

    [RelayCommand]
    async Task GoToCertificateList()
    {
        await Shell.Current.GoToAsync(nameof(CertificateListPage));
    }
}