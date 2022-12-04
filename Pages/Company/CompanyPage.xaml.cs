using ObjecyX.DTO.Company;
using ObjecyX.Services.interfaces;
using ObjecyX.Model;
//using static Android.Provider.Telephony.Mms;
using System.Diagnostics.Metrics;


namespace ObjecyX.Pages.Company;

public partial class CompanyPage : ContentPage
{
	private readonly ICompanyServices companyServices;

	public ObjecyX.Model.Company? company { get; set; }

	public CompanyPage(ICompanyServices companyServices)
	{
		InitializeComponent();
		this.companyServices = companyServices;
	}

    protected override async void OnAppearing()
	{
        base.OnAppearing();
		var data=await companyServices.Get();
		if (data!=null)
		{
			company = data;
			companyName.Text = company.Name;
			CompanyAddress1.Text = company.Address1;
			CompanyAddress2.Text = company.Address2;
			CompanyCity.Text = company.City;
			CompanyCountry.Text = company.Country;

			CreateOrUpdateButton.Text = "Update";
        }
    }
    private async void CreatecompanyCuttonClick(object sender, EventArgs e)
	{

		var model = new CreateCompanyDTO()
		{
			Name= companyName.Text,
			TaxNumber=companyTax.Text??"",
			Addr1= CompanyAddress1.Text??"",
			Addr2=CompanyAddress2.Text??"",
			City=CompanyCity.Text??"",
			Country=CompanyCountry.Text??""
        };
		try
		{

			if (company==null)
			{
                await companyServices.CreateAsync(model);
			}
			else
			{
				await companyServices.UpdateAsync(model);
            }
			Console.WriteLine(company);
             await Shell.Current.GoToAsync("..");

        }
        catch (Exception)
		{

			throw;
		}
	}

	private void AccountButton_Clicked(object sender, EventArgs e)
	{

	}
}