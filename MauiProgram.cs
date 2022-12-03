using ObjecyX.Model;
using ObjecyX.Pages.Company;
using ObjecyX.Services;
using ObjecyX.Services.interfaces;

namespace ObjecyX;

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


		//Pages
		builder.Services.AddSingleton<CompanyPage>();

		//Services
		builder.Services.AddSingleton(typeof(ApplicationDbContext));
		builder.Services.AddTransient<ICompanyServices, CompanyServices>();


		return builder.Build();
	}
}
