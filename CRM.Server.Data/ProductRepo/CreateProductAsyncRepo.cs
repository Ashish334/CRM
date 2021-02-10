using CRM.Server.Models.ProductModels;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Server.Data.ProductRepo
{
   public class CreateProductAsyncRepo
    {
        private readonly string _connectionString;
        public CreateProductAsyncRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> CreateProductAsync(ProductMaster productma)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                return await conn.ExecuteAsync($"insert into ProductMaster(Name,Price,Status,GST,HSNCODE)values(@Name,@Price,@Status,@GST,@HSNCODE)", productma).ConfigureAwait(false);

            }
        }
    }
}
