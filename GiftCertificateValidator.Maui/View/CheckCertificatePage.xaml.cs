using GiftCertificateValidator.Maui.ViewModel;
using ZXing.Net.Maui;

namespace GiftCertificateValidator.Maui.View;

public partial class CheckCertificatePage : ContentPage
{
    private readonly CheckCertificateViewModel _viewModel;

    public CheckCertificatePage(CheckCertificateViewModel viewmodel)
    {
        InitializeComponent();
        _viewModel = viewmodel;
        BindingContext = _viewModel;

        barcodeReader.Options = new BarcodeReaderOptions
        {
            AutoRotate = true,
            Formats = BarcodeFormat.QrCode,
            Multiple = false
        };
    }

    private void Scanner(object sender, BarcodeDetectionEventArgs e)
    {
        Dispatcher.Dispatch(() => { _viewModel.ScannedQr = $"{e.Results[0].Value} {e.Results[0].Format}"; });
    }

    protected override void OnAppearing()
    {
        barcodeReader.IsDetecting = true;
        barcodeReader.CameraLocation = CameraLocation.Front;
        barcodeReader.CameraLocation = CameraLocation.Rear;
        base.OnAppearing();
    }

    protected override void OnDisappearing()
    {
        barcodeReader.IsDetecting = false;
        base.OnDisappearing();
    }
}