using ObjecyX.DTO.Search;
using ObjecyX.Model.Account;
using ObjecyX.Services.interfaces;

namespace ObjecyX.Pages.Ledger;

public partial class LedgerAccounts : ContentPage
{
	private readonly IAccountServices _accoutServices;

	public List<LedgerAccount> AccountList { get; set; } = new();

	public LedgerAccounts(IAccountServices _accoutServices)
	{
		InitializeComponent();
		this._accoutServices = _accoutServices;
	}

	protected override async void OnAppearing()
	{
		try
		{
			var data = await _accoutServices.Get(new SearchAccountDTO()
			{
				SearchKey="cash",
				TakeCount=10,
				SkipCount=0
			});
			if (data!=null)
			{
				//AccountList = data;
			}
		}
		catch (Exception)
		{

			throw;
		}

	}

}