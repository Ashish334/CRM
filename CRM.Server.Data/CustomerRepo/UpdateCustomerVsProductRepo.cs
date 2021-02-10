using CRM.Server.Models.CustomerModels;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Server.Data.CustomerRepo
{
  public  class UpdateCustomerVsProductRepo
    {
        private readonly string _connectionString;
        public UpdateCustomerVsProductRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> DeletecustomervsproductAsync(long Id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                return await conn.ExecuteAsync($"Delete from CustomerVsProduct where CustomerId=@Id", new { Id }).ConfigureAwait(false);

            }
        }
        public async Task<int> UpdatecustomervsproductAsync(CustomerVsProducrAll customerproduct)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                return await conn.ExecuteAsync($"insert into CustomerVsProduct(IndexId,CustomerId,CustomerName,ProductName,Price,Qty,DiscountPer,DiscountAmt,GstPer,GstAmt,NetAmount)values(@IndexId,@CustomerId,@CustomerName,@ProductName,@Price,@Qty,@DiscountPer,@DiscountAmt,@GstPer,@GstAmt,@NetAmount)", customerproduct).ConfigureAwait(false);

            }
        }

    
    }
}
