using CRM.Server.Models.CustomerModels;
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
   public class ProductByIdRepo
    {
        private readonly string _connectionString;
        public ProductByIdRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<ProductMaster> GetProductDetailsByIdAsync(long Id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var result = (await conn.QueryAsync<ProductMaster>($"select * from [ProductMaster] where Id =@Id", new { Id })).FirstOrDefault();
                return result;
            }
        }
    }
}
