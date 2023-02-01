using GiftCertificateValidator.Maui.Services.CertificateTable;
using GiftCertificateValidator.Maui.Services.Database;
using GiftCertificateValidator.Maui.View;
using GiftCertificateValidator.Maui.ViewModel;
using GiftCertificateValidator.Persistence.DB;
using GiftCertificateValidator.Persistence.Repositories.CertificateTable;
using GiftCertificateValidator.Persistence.Repositories.Database;
using Microsoft.Extensions.Logging;
using ZXing.Net.Maui.Controls;

namespace GiftCertificateValidator.Maui;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseBarcodeReader()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddSingleton<MainPageViewModel>();
        builder.Services.AddSingleton<MainPage>();

        builder.Services.AddTransient<ScanCertificatePage>();
        builder.Services.AddTransient<ScanCertificateViewModel>();

        builder.Services.AddTransient<AddCertificatePage>();
        builder.Services.AddTransient<AddCertificateViewModel>();

        builder.Services.AddTransient<CheckCertificatePage>();
        builder.Services.AddTransient<CheckCertificateViewModel>();

        builder.Services.AddTransient<CertificateListPage>();
        builder.Services.AddTransient<CertificateListViewModel>();

        builder.Services.AddTransient<DetailsPage>();
        builder.Services.AddTransient<DetailsViewModel>();


        builder.Services.AddTransient<DatabaseConnection>();

        builder.Services.AddTransient<IDatabaseRepository, DatabaseRepository>();
        builder.Services.AddTransient<IDatabaseService, DatabaseService>();

        builder.Services.AddTransient<ICertificateRepository, CertificateRepository>();
        builder.Services.AddTransient<ICertificateService, CertificateService>();

       
        

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}