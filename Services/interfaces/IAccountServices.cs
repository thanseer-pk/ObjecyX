using ObjecyX.DTO.Account;
using ObjecyX.DTO.Search;
using ObjecyX.Model.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjecyX.Services.interfaces
{
    public interface IAccountServices
    {
        Task<LedgerAccount?> CreateAsync(CreateLedgerAccountDTO model);
        Task<LedgerAccount> Get();
        Task<LedgerAccount?> Get(List<int> AccountIds);
        Task<List<LedgerAccount>?> Get(SearchAccountDTO model);
        Task<LedgerAccount> Get(int Id);
    }
}
