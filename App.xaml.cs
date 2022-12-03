using ObjecyX.Pages.Company;

namespace ObjecyX;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();

        Routing.RegisterRoute(nameof(CompanyPage), typeof(CompanyPage));

    }
}
