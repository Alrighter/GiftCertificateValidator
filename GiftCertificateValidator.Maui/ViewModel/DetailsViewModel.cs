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
    [ObservableProperty] private bool _isEditable = false;

    public DetailsViewModel(ICertificateService certificateService)
    {
        _certificateService = certificateService;
        Title = "Details";
    }

    [RelayCommand]
    private async Task ChangeStatus()
    {
        var answer = await Shell.Current.DisplayAlert("Change status", "Are you sure you want to change the status?", "Yes", "No");
        if (!answer)
            return;

        var changeResponse = await _certificateService.ChangeCertificateStatusAsync(GiftCertificate.Code);

        if (!changeResponse.Success)
        {
            await Shell.Current.DisplayAlert("Error", "Error changing status", "OK");
            return;
        }

        var response = await _certificateService.GetCertificateAsync(GiftCertificate.Code);

        if (response.Success)
            GiftCertificate = response.Data;
    }

    [RelayCommand]
    private async Task UpdateCertificate()
    {
        if (!IsEditable)
        {
            IsEditable = true;
            return;
        }

        var answer = await Shell.Current.DisplayAlert("Update", "Are you sure you want to update the certificate?", "Yes", "No");
        if (answer)
        {
            var updateResponse = await _certificateService.UpdateCertificateAsync(GiftCertificate);
            if (!updateResponse.Success)
            {
                await Shell.Current.DisplayAlert("Error", "Error updating certificate", "OK");
                return;
            }

            await Shell.Current.DisplayAlert("Success", "Certificate updated", "OK");
        }

        IsEditable = false;
        var response = await _certificateService.GetCertificateAsync(GiftCertificate.Code);

        if (response.Success)
            GiftCertificate = response.Data;

        else
            await Shell.Current.DisplayAlert("Error", "Error refreshing certificate", "OK");
    }
}