using GiftCertificateValidator.Maui.View;
using GiftCertificateValidator.Maui.ViewModel;
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

        builder.Services.AddScoped<ScanCertificatePage>();
        builder.Services.AddScoped<ScanCertificateViewModel>();

        builder.Services.AddScoped<AddCertificatePage>();
        builder.Services.AddScoped<AddCertificateViewModel>();

        builder.Services.AddScoped<CheckCertificatePage>();

        builder.Services.AddScoped<CertificateListPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
