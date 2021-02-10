using CRM.Server.Models.CustomerModels;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Server.Data.CustomerRepo
{
   public class UpdateCustomerRepo
    {
        private readonly string _connectionString;
        public UpdateCustomerRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> UpdateCustomerByIdAsync(CustomerMaster customer)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                return await conn.ExecuteAsync($"Update CustomerMaster set Name=@Name,Domain=@Domain,Email=@Email,ShopName=@ShopName,Mobile=@Mobile,Address1=@Address1,Address2=@Address2,Address3=@Address3,District=@District,City=@City,State=@State,PinCode=@PinCode,Status=@Status,InterestedProduct=@InterestedProduct,LeadType=@LeadType,BusinessType=@BusinessType,ReferenceName=@ReferenceName where Id=@id", customer).ConfigureAwait(false);


            }
        }
    }
}
