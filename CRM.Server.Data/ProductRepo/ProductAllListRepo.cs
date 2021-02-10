using CRM.Server.Models.ProductModels;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Server.Data.ProductRepo
{
   public class ProductAllListRepo
    {
        private readonly string _connectionString;
        public ProductAllListRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<ProductMaster>> GetAllProductListTypeAsync()
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var result = await conn.QueryAsync<ProductMaster>("select * from [ProductMaster]").ConfigureAwait(false);
                return result.ToList();
            }
        }
    }
}
