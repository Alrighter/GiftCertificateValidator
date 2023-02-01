using GiftCertificateValidator.Maui.ViewModel;

namespace GiftCertificateValidator.Maui.View;

public partial class MainPage : ContentPage
{
    public MainPage(MainPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}

