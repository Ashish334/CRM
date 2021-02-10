using CRM.Server.Data;
using CRM.Server.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Server.Services.Domain
{
    public class UserService
    {
        private readonly UserRepo _userRepo;
        public UserService(string connectionString)
        {
            _userRepo = new UserRepo(connectionString);
        }

        public async Task<List<ApplicationUser>> GetAllUserAsync()
        {
            return await _userRepo.GetAllUsersAsync().ConfigureAwait(false);
        }
    }
}
