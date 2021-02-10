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
   public class FindCustomerVsProductbyidRepo
    {
        private readonly string _connectionString;

        public FindCustomerVsProductbyidRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<CustomerVsProduct>> FindcustomervsproductByIdTypeAsync(long Id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var result = (await conn.QueryAsync<CustomerVsProduct>($"select * from [CustomerVsProduct] where CustomerId =@Id", new { Id }));
                return result.ToList();
            }
        }
    }
}
