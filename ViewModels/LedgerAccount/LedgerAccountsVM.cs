using CommunityToolkit.Mvvm.ComponentModel;
using ObjecyX.DTO.Search;
using ObjecyX.Services;
using ObjecyX.Services.interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjecyX.ViewModels.LedgerAccount
{
    public partial class LedgerAccountsVM : ObservableObject
    {

        [ObservableProperty]
        ObservableCollection<ObjecyX.Model.Account.LedgerAccount> ledgers = new();

        public LedgerAccountsVM(IAccountServices _accoutServices)
        {
          this._accoutServices = _accoutServices;
            ReadData();
        }
        
        private readonly IAccountServices _accoutServices;

         void ReadData()
        {
          


        }



    }
}
