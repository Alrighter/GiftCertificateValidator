using GiftCertificateValidator.Maui.ViewModel;

namespace GiftCertificateValidator.Maui.View;

public partial class AddCertificatePage : ContentPage
{
    public AddCertificatePage(AddCertificateViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}