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
  public  class CustomerLeadTypeRepo
    {
        private readonly string _connectionString;
        public CustomerLeadTypeRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<CustomerLeadType>> GetAllLeadTypeAsync()
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var result = await conn.QueryAsync<CustomerLeadType>("select * from [Cust_LeadType]").ConfigureAwait(false);
                return result.ToList();
            }
        }
    }
}
