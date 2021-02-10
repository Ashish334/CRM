using CRM.Server.Models.CustomerModels;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Server.Data.CustomerRepo
{
   public class CustomerMasterRepo
    {
        private readonly string _connectionString;
        public CustomerMasterRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> CreateCustomerAsync(CustomerMaster customer)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                return await conn.ExecuteAsync($"insert into CustomerMaster(Name,Domain,Email,ShopName,Mobile,Address1,Address2,Address3,District,City,State,PinCode,Status,InterestedProduct,LeadType,BusinessType,ReferenceName)values(@Name,@Domain,@Email,@ShopName,@Mobile,@Address1,@Address2,@Address3,@District,@City,@State,@PinCode,@Status,@InterestedProduct,@LeadType,@BusinessType,@ReferenceName)",customer).ConfigureAwait(false);
                
            }
        }
    }
}
