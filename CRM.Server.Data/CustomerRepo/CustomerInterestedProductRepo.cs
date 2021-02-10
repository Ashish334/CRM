using CRM.Server.Models.CustomerModels;
using CRM.Server.Models.ProductModels;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Server.Data.CustomerRepo
{
   public class CustomerInterestedProductRepo
    {
        private readonly string _connectionString;
        public CustomerInterestedProductRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<ProductMaster>> GetAllInstProductAsync()
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var result = await conn.QueryAsync<ProductMaster>("select Id,Name from [ProductMaster]").ConfigureAwait(false);
                return result.ToList();
            }
        }
    }
}
