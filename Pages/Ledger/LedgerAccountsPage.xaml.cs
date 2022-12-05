using ObjecyX.DTO.Search;
using ObjecyX.Model.Account;
using ObjecyX.Services.interfaces;
using ObjecyX.ViewModels.LedgerAccount;

namespace ObjecyX.Pages.Ledger;

public partial class LedgerAccountsPage : ContentPage
{
    private readonly LedgerAccountsVM ledgerVm;
    private readonly IAccountServices _accoutServices;

    public List<LedgerAccount> AccountList { get; set; } = new();

    public LedgerAccountsPage(LedgerAccountsVM _ledgerVm,IAccountServices _accoutServices)
    {
        InitializeComponent();
        BindingContext= _ledgerVm;
        ledgerVm = _ledgerVm;
        this._accoutServices = _accoutServices;
    }

    protected override async void OnAppearing()
    {
        try
        {
           

             var data = await _accoutServices.Get(new SearchAccountDTO()
            {
                SearchKey = "cash",
                TakeCount = 10,
                SkipCount = 0
            });
            if (data != null)
            {
            
                ledgerVm.Ledgers = new System.Collections.ObjectModel.ObservableCollection<LedgerAccount>(data);

            }
        }
        catch (Exception)
        {
           
            throw;
        }

    }

}