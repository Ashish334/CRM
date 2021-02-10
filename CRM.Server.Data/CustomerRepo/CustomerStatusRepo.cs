using CRM.Server.Models;
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
   public class CustomerStatusRepo
    {
        private readonly string _connectionString;
        public CustomerStatusRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<CustomerStatus>> GetAllCustStatusAsync()
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var result = await conn.QueryAsync<CustomerStatus>("select * from [CUST_STATUS]").ConfigureAwait(false);
                return result.ToList();
            }
        }
    }
}
