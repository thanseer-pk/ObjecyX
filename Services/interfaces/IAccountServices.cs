using ObjecyX.DTO.Account;
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

        Task<LedgerAccount> Get(int Id);


    }
}
