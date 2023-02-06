using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GiftCertificateValidator.Maui.Model;
using GiftCertificateValidator.Maui.Services.CertificateTable;
using GiftCertificateValidator.Maui.View;

namespace GiftCertificateValidator.Maui.ViewModel;

public partial class CertificateListViewModel : BaseViewModel
{
    private readonly ICertificateService _certificateService;
    [ObservableProperty] private ObservableCollection<GiftCertificate> _certificates;

    public CertificateListViewModel(ICertificateService certificateService)
    {
        _certificateService = certificateService;
        Title = "Certificates";
    }

    [RelayCommand]
    public async Task LoadCertificates()
    {
        IsBusy = true;
        var response = await _certificateService.GetCertificatesAsync();
        if (!response.Success)
        {
            await Shell.Current.DisplayAlert("Error", "Error loading certificates", "OK");
            return;
        }
        var certificates = response.Data.Reverse();
        Certificates = new ObservableCollection<GiftCertificate>(certificates);
        IsBusy = false;
    }

    [RelayCommand]
    private async Task GoToDetailsPage(GiftCertificate certificate)
    {
        await Shell.Current.GoToAsync($"{nameof(DetailsPage)}",
            true, new Dictionary<string, object>
            {
                {"Certificate", certificate}
            });
    }
}