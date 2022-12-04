using Microsoft.Data.SqlClient;
using ObjecyX.DTO.Account;
using ObjecyX.Model;
using ObjecyX.Model.Account;
using ObjecyX.Services.interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjecyX.Services
{
    public class AccountServices : IAccountServices
    {

        public AccountServices(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public ApplicationDbContext DbContext { get; }

        public async Task<LedgerAccount?> CreateAsync(CreateLedgerAccountDTO model)
        {
            try
            {
                LedgerAccount? account = null;

                using (var connection = new SqlConnection(DbContext.connectionString))
                {
                    string commandText = "spCreateLedger";
                    SqlCommand cmd = new SqlCommand(commandText, connection);

                    cmd.Parameters.AddWithValue("@name", $"{model.Name.Trim()}");
                    cmd.Parameters.AddWithValue("@date", model.Date);
                    await connection.OpenAsync();

                    SqlDataReader reader = await cmd.ExecuteReaderAsync();
                    if (reader.HasRows)
                    {
                        await connection.CloseAsync();

                        while (reader.Read())
                        {
                            account = new LedgerAccount()
                            {
                                Name = reader.GetString("name"),
                                Balance = reader.GetInt32("balance"),
                                CustomerId = reader.GetInt32("customerid"),
                                Id = reader.GetInt32("id"),
                                StaffId = reader.GetInt32("staffid"),
                                VendorId = reader.GetInt32("vendorid"),
                            };

                        }
                        return account;

                    }
                    else
                    {
                        await connection.CloseAsync();
                        return account;
                    }


                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<LedgerAccount> Get()
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<LedgerAccount> Get(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
