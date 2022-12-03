using ObjecyX.Pages.Company;

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




}

