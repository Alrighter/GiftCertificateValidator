using GiftCertificateValidator.Maui.View;

namespace GiftCertificateValidator.Maui;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        Routing.RegisterRoute(nameof(ScanCertificatePage), typeof(ScanCertificatePage));
        Routing.RegisterRoute(nameof(CheckCertificatePage), typeof(CheckCertificatePage));
        Routing.RegisterRoute(nameof(CertificateListPage), typeof(CertificateListPage));
        Routing.RegisterRoute(nameof(AddCertificatePage), typeof(AddCertificatePage));
    }
}