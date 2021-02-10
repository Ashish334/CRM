using CRM.Server.Models.CustomerModels;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Server.Data.CustomerRepo
{
   public class CustomerAllListRepo
    {
        private readonly string _connectionString;
        public CustomerAllListRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<CustomerMaster>> GetAllCustomerListTypeAsync()
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var result = await conn.QueryAsync<CustomerMaster>("select * from [CustomerMaster]").ConfigureAwait(false);
                return result.ToList();
            }
        }
    }
}
