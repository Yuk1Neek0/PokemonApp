using Microsoft.Extensions.Logging;
using PokemonApp.Services;

namespace PokemonApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

		// Register HttpClient for API service
		builder.Services.AddHttpClient<IPokemonApiService, PokemonApiService>();

		// Register Repository as singleton
		builder.Services.AddSingleton<IPokemonRepository, PokemonRepository>();

		return builder.Build();
	}
}
