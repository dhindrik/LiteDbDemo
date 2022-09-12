namespace LiteDbDemo;

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
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});


		builder.Services.AddSingleton<ISecureStorageService, SecureStorageService>();
        builder.Services.AddSingleton<IDataService, DataService>();

        builder.Services.AddSingleton<MainViewModel>();
        builder.Services.AddSingleton<PersonListViewModel>();

        builder.Services.AddSingleton<MainPage>();
		builder.Services.AddSingleton<PersonListView>();

		return builder.Build();
	}
}

