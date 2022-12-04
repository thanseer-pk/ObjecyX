using ObjecyX.Pages.Company;
using ObjecyX.Pages.Ledger;

namespace ObjecyX;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();

        Routing.RegisterRoute(nameof(CompanyPage), typeof(CompanyPage));
        Routing.RegisterRoute(nameof(LedgerAccounts), typeof(LedgerAccounts));
    }
}
