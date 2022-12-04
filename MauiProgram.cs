using ObjecyX.Model;
using ObjecyX.Pages.Company;
//using ObjecyX.Pages.Ledger;
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
        //builder.Services.AddTransient<LedgerPage>();

        //Services
        builder.Services.AddSingleton(typeof(ApplicationDbContext));
		builder.Services.AddTransient<ICompanyServices, CompanyServices>();
        builder.Services.AddTransient(typeof(IAccountServices),typeof(AccountServices));

		//
        return builder.Build();
	}
}
