using CommunityToolkit.Mvvm.ComponentModel;
using GiftCertificateValidator.Domain.Model;

namespace GiftCertificateValidator.Maui.ViewModel;

[QueryProperty(nameof(CertificateCode), "Code")]
public partial class DetailsViewModel : BaseViewModel
{
    [ObservableProperty] private string _certificateCode;
    [ObservableProperty] private GiftCertificate _giftGiftCertificate;

    public DetailsViewModel()
    {
        Title = "Details page";
    }

    //get certificate by code
    private void GetCertificate()
    {
    }
}