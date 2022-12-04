//using AndroidX.Navigation;
using ObjecyX.Pages.Company;
using ObjecyX.Pages.Ledger;
//using ObjecyX.Pages.Ledger;

namespace ObjecyX;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
        InitializeComponent();

	}
	

	private async void GotoCompanyPage(object sender, EventArgs e)
    {
	 await	Shell.Current.GoToAsync(nameof(CompanyPage));
	}

	private async void AccountButton_Clicked(object sender, EventArgs e)
	{
        await Shell.Current.GoToAsync(nameof(LedgerAccounts));
    }
}

