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
    [ObservableProperty] private string _phoneNumber;
    [ObservableProperty] private int _discount;
    [ObservableProperty] private string _name;

    public AddCertificateViewModel(ICertificateService certificateService)
    {
        _certificateService = certificateService;
        Title = "Add certificate";
    }

    [RelayCommand]
    private async Task CreateNewCertificate()
    {
        var certificate = new GiftCertificate
        {
            Code = CertificateCode,
            Name = Name,
            Description = Description,
            PhoneNumber = PhoneNumber,
            Discount = Discount,
            DateCreated = DateTime.Now,
            DateUsed = null,
            IsUsed = false
        };

        var result = await _certificateService.AddCertificateAsync(certificate);

        if (result.Success)
        {
            await Shell.Current.DisplayAlert("Success", "GiftCertificate added successfully", "OK");
        }
        else
        {
            if (result.Message == "UNIQUE constraint failed: GiftCertificate.Code")
            {
                await Shell.Current.DisplayAlert("Error", "Certificate already exists", "OK");
                return;
            }

            await Shell.Current.DisplayAlert("Error", "Error adding certificate", "OK");
            return;
        }

        await Shell.Current.GoToAsync("///ScanCertificatePage", true);
    }
}