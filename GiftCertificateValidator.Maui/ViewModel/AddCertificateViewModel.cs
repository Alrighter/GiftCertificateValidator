using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GiftCertificateValidator.Maui.Model;
using GiftCertificateValidator.Maui.Services.CertificateTable;
using GiftCertificateValidator.Maui.View;

namespace GiftCertificateValidator.Maui.ViewModel;

[QueryProperty(nameof(CertificateCode), "Code")]
public partial class AddCertificateViewModel : BaseViewModel
{
    private readonly ICertificateService _certificateService;

    [ObservableProperty] private string _certificateCode;
    [ObservableProperty] private string _description;
    [ObservableProperty] private int _discount;
    [ObservableProperty] private string _name;

    public AddCertificateViewModel(ICertificateService certificateService)
    {
        _certificateService = certificateService;
        Title = "Add GiftCertificate";
    }

    [RelayCommand]
    private async Task CreateNewCertificate()
    {
        var certificate = new GiftCertificate
        {
            Code = CertificateCode,
            Name = Name,
            Description = Description,
            Discount = Discount,
            DateCreated = DateTime.Now,
            IsUsed = false
        };

        if (await _certificateService.AddCertificateAsync(certificate))
        {
            await Shell.Current.DisplayAlert("Success", "GiftCertificate added successfully", "OK");
        }
        else
        {
            await Shell.Current.DisplayAlert("Error", "Error adding certificate", "OK");
            return;
        }

        await Shell.Current.GoToAsync(nameof(CertificateListPage), true);
    }
}