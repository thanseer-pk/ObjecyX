using ObjecyX.Model;
using ObjecyX.Pages.Company;
using ObjecyX.Pages.Ledger;
//using ObjecyX.Pages.Ledger;
using ObjecyX.Services;
using ObjecyX.Services.interfaces;
using ObjecyX.ViewModels.LedgerAccount;

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
        builder.Services.AddSingleton<LedgerAccountsPage>();


        //vm
        builder.Services.AddSingleton(typeof(LedgerAccountsVM));

        //Services
        builder.Services.AddSingleton(typeof(ApplicationDbContext));
		builder.Services.AddTransient<ICompanyServices, CompanyServices>();
        builder.Services.AddTransient<IAccountServices,AccountServices>();

		//
        return builder.Build();
	}
}
