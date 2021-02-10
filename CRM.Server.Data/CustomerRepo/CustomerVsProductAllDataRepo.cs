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
  public  class CustomerVsProductAllDataRepo
    {
        private readonly string _connectionString;
        public CustomerVsProductAllDataRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<CustomerVsProducrAll>> GetcustomervsproductData(long Id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var result = await conn.QueryAsync<CustomerVsProducrAll>("select cp.*,Domain,Email,ShopName from CustomerMaster C inner join CustomerVsProduct CP on c.Id = CP.CustomerId where CP.CustomerId=@Id", new { Id });
                return result.ToList();
            }
        }
    }
}
