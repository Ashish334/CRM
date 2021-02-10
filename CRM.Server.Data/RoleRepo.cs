using CRM.Server.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Server.Data
{
  public  class RoleRepo
    {
        private readonly string _connectionString;
        public RoleRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<ApplicationRole>> GetAllRoleAsync()
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var result = await conn.QueryAsync<ApplicationRole>("select * from [ApplicationRole]").ConfigureAwait(false);
                return result.ToList();
            }
        }
    }
}
