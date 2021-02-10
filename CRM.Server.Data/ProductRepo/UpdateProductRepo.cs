using CRM.Server.Models.ProductModels;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Server.Data.ProductRepo
{
  public  class UpdateProductRepo
    {
        private readonly string _connectionString;
        public UpdateProductRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> UpdateProductByIdAsync(ProductMaster prodMaster)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                return await conn.ExecuteAsync("Update ProductMaster set Name=@Name,Price=@Price,Status=@Status,GST=@GST,HSNCODE=@HSNCODE where Id=@id", prodMaster).ConfigureAwait(false);


            }
        }
    }
}
