using CommunityToolkit.Mvvm.ComponentModel;
using GiftCertificateValidator.Maui.Model;
using Xamarin.Google.Crypto.Tink.Mac;

namespace GiftCertificateValidator.Maui.ViewModel;

[QueryProperty(nameof(CertificateCode), "Code")]
public partial class AddCertificateViewModel : BaseViewModel
{
    public AddCertificateViewModel()
    {
        Title = "Add Certificate";
    }

    [ObservableProperty] private string _certificateCode;
    [ObservableProperty] private Certificate _newCertificate;

    //Create new certificate command
    async Task CreateNewCertificate()
    {
        if (string.IsNullOrWhiteSpace(CertificateCode))
            return;

        NewCertificate.Code = CertificateCode;
        NewCertificate.ValidFrom = DateTime.Now;
        NewCertificate.Status = true;
        

        await Shell.Current.GoToAsync("..");
    }
}