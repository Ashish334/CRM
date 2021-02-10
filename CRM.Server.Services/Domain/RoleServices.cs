using CRM.Server.Data;
using CRM.Server.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Server.Services.Domain
{
   public class RoleServices
    {
        private readonly RoleRepo _roleRepo;
        public RoleServices(string connectionString)
        {
            _roleRepo = new RoleRepo(connectionString);
        }

        public async Task<List<ApplicationRole>> GetAllRoleAsync()
        {
            return await _roleRepo.GetAllRoleAsync().ConfigureAwait(false);
        }
    }
}
