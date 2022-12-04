using Microsoft.Data.SqlClient;
using ObjecyX.DTO.Account;
using ObjecyX.DTO.Search;
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
                    cmd.Parameters.AddWithValue("@balance", model.Balance);
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

        public Task<LedgerAccount?> Get(List<int> AccountIds)
        {
            throw new NotImplementedException();
        }

        public async Task<List<LedgerAccount>?> Get(SearchAccountDTO model)
        {
            try
            {
                List<LedgerAccount> accountList = new List<LedgerAccount>();
                using (var connection=new SqlConnection(DbContext.connectionString))
                {
                    var commandText = "spGetLedgerBySearch";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText=commandText;
                    cmd.CommandType=CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@searchkey", model.SearchKey);
                    cmd.Parameters.AddWithValue("@takecount",model.TakeCount);
                    cmd.Parameters.AddWithValue("@skipcount", model.SkipCount);
                    await connection.OpenAsync();
                    var reader=await cmd.ExecuteReaderAsync();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //var customerId = reader.GetString("customerid");
                            //var staffId = reader.GetString("staffid");
                            //var vendorId = reader.GetString("vendorid");
                            accountList.Add(new LedgerAccount()
                            {
                                Balance = reader.GetDouble("balance"),
                                Id=reader.GetInt32("id"),
                                Name=reader.GetString("name"),
                                //CustomerId= customerId == null?null:int.Parse(customerId), 
                                //StaffId= staffId == null ? null : int.Parse(staffId),
                                //VendorId = staffId == null ? null : int.Parse(staffId),
                            });
                        }
                    }                    
                   await connection.CloseAsync();
                }
                return  accountList;
            
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
