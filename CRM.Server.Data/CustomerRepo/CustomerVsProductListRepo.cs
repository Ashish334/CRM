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
   public class CustomerVsProductListRepo
    {
        private readonly string _connectionString;
        public CustomerVsProductListRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<CustomerVsProduct>> GetAllcustomervsproductTypeAsync()
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var result = await conn.QueryAsync<CustomerVsProduct>("select * from [CustomerVsProduct]").ConfigureAwait(false);
                return result.ToList();
            }
        }
    }
}
