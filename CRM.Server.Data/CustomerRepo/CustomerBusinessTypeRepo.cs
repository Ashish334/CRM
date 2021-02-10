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
  public  class CustomerBusinessTypeRepo
    {
        private readonly string _connectionString;
        public CustomerBusinessTypeRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<CustomerBusinessType>> GetAllBusinessTypeAsync()
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var result = await conn.QueryAsync<CustomerBusinessType>("select * from [Cust_BusinessType]").ConfigureAwait(false);
                return result.ToList();
            }
        }
    }
}
