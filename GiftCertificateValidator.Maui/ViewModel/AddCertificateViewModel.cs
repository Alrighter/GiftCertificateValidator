using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GiftCertificateValidator.Domain.Model;
using GiftCertificateValidator.Persistence.Repositories.CertificateTable;

namespace GiftCertificateValidator.Maui.ViewModel;

[QueryProperty(nameof(CertificateCode), "Code")]
public partial class AddCertificateViewModel : BaseViewModel
{
    private readonly ICertificateRepository _certificateRepository;

    [ObservableProperty] private string _certificateCode;
    [ObservableProperty] private string _description;
    [ObservableProperty] private string _discount;
    [ObservableProperty] private string _name;
    [ObservableProperty] private DateTime _validTo = DateTime.Now.AddYears(1);

    public AddCertificateViewModel(ICertificateRepository certificateRepository)
    {
        _certificateRepository = certificateRepository;
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
            IsUsed = true
        };

        if (await _certificateRepository.AddCertificate(certificate))
            await Shell.Current.DisplayAlert("Success", "GiftCertificate added successfully", "OK");
        else
            await Shell.Current.DisplayAlert("Error", "Error adding certificate", "OK");


        await Shell.Current.GoToAsync("//MainPage", true);
    }
}