using ObjecyX.DTO.Company;
using ObjecyX.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjecyX.Services.interfaces
{
    public interface ICompanyServices
    {
          Task<Company?> CreateAsync(CreateCompanyDTO model);
          Task<Company?> UpdateAsync(Company company);
          Task<Company?> Get();
    }
}
