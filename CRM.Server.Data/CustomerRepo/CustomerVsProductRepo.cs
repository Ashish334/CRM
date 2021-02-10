using CRM.Server.Models.CustomerModels;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Server.Data.CustomerRepo
{
   public class CustomerVsProductRepo
    {
        private readonly string _connectionString;
        public CustomerVsProductRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> CreatecustomervsproductAsync(CustomerVsProduct customerproduct)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                return await conn.ExecuteAsync($"insert into CustomerVsProduct(IndexId,CustomerId,CustomerName,ProductName,Price,Qty,DiscountPer,DiscountAmt,GstPer,GstAmt,NetAmount)values(@IndexId,@CustomerId,@CustomerName,@ProductName,@Price,@Qty,@DiscountPer,@DiscountAmt,@GstPer,@GstAmt,@NetAmount)", customerproduct).ConfigureAwait(false);

            }
        }
    }
}
