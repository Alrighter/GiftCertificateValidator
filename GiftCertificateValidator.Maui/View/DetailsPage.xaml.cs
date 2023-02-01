using GiftCertificateValidator.Maui.ViewModel;

namespace GiftCertificateValidator.Maui.View;

public partial class DetailsPage : ContentPage
{
    public DetailsPage(DetailsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}