//using Java.Net;
using Microsoft.Data.SqlClient;
using Microsoft.Maui.Controls;
using ObjecyX.DTO.Company;
using ObjecyX.Model;
using ObjecyX.Services.interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjecyX.Services
{
    public class CompanyServices : ICompanyServices
    {
        public ApplicationDbContext DbContext { get; }
        public CompanyServices(ApplicationDbContext _dbContext)
        {
            DbContext = _dbContext;
        }

      

        public async Task<Company?> CreateAsync(CreateCompanyDTO model)
        {

            string queryString ="spinsertIntoCompany";


            using (var connection = new SqlConnection( DbContext.connectionString))
            {
                
                SqlCommand command = new SqlCommand(queryString, connection);
                 //Stored Procedure
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@name", model.Name);
                command.Parameters.AddWithValue("@taxnumber", model.TaxNumber);
                command.Parameters.AddWithValue("@addr1", model.Addr1);
                command.Parameters.AddWithValue("@addr2", model.Addr2);
                command.Parameters.AddWithValue("@city", model.City);
                command.Parameters.AddWithValue("@country", model.Country);

                try
                {
                   await  connection.OpenAsync();
                    var readerCounr =await command.ExecuteNonQueryAsync();
                  
                  await  connection.CloseAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


            }

            return new();
        }

        public  async Task<Company?> UpdateAsync(CreateCompanyDTO model)
        {

            try
            {
                using (var conn=new SqlConnection(DbContext.connectionString))
                {
                    String commandText = "spUpdateCompany";
                    SqlCommand cmd = new SqlCommand(commandText,conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //
                    await conn.OpenAsync();
                    cmd.Parameters.AddWithValue("@name", model.Name);
                    cmd.Parameters.AddWithValue("@taxnumber", model.TaxNumber);
                    cmd.Parameters.AddWithValue("@addr1", model.Addr1);
                    cmd.Parameters.AddWithValue("@addr2", model.Addr2);
                    cmd.Parameters.AddWithValue("@city", model.City);
                    cmd.Parameters.AddWithValue("@country", model.Country);

                    var status=await cmd.ExecuteNonQueryAsync();
                    await conn.CloseAsync();
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
          
        
        }



        public async Task<Company?> Get()
        {
            try
            {
                using (var conn = new SqlConnection(DbContext.connectionString))
                {
                    var cmdText = "spGetCompanyData";
                    SqlCommand cmd = new SqlCommand(cmdText, conn);

                  await  conn.OpenAsync();

                    SqlDataReader reader =await cmd.ExecuteReaderAsync();

                     Company company = new Company();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                           
                            company.Id = reader.GetInt32("id");
                            company.Name = reader.GetString("name");
                            company.TaxNumber = reader.GetString("taxnumber");
                            company.Address1 = reader.GetString("addr1");
                            company.Address2 = reader.GetString("addr2");
                            company.City = reader.GetString("city");
                            company.Country = reader.GetString("country");
                        }
                        await conn.CloseAsync();
                        return company;
                    }

                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}
