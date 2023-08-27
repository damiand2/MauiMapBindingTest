using Microsoft.Extensions.Logging;
using Maui.GoogleMaps.Hosting;
namespace MauiMapBindingTest;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
#if IOS    
            .UseGoogleMaps("AIzaSyBG8ctJH_EedR9axWgV0pR-nwl42sqwZi4")            
#endif
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

