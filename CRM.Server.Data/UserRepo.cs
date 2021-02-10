using CRM.Server.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Server.Data
{
    public class UserRepo
    {
        private readonly string _connectionString;
        public UserRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<ApplicationUser>> GetAllUsersAsync()
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var result = await conn.QueryAsync<ApplicationUser>("select * from [ApplicationUser]").ConfigureAwait(false);
                return result.ToList();
            }
        }
    }
}
