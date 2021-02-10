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
 public   class FindCustomerByIdRepo
    {
        private readonly string _connectionString;

        public FindCustomerByIdRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<CustomerMaster> FindCustomerByIdTypeAsync(long Id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var result = (await conn.QueryAsync<CustomerMaster>($"select * from [CustomerMaster] where Id =@Id", new { Id })).FirstOrDefault();
                return result;
            }
        }
    }
}
