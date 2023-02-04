using GiftCertificateValidator.Maui.ViewModel;

namespace GiftCertificateValidator.Maui.View;

public partial class CertificateListPage : ContentPage
{
    private readonly CertificateListViewModel _viewModel;

    public CertificateListPage(CertificateListViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        Task.Run(async () => await _viewModel.LoadCertificates());
    }
}