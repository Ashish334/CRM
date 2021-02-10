using CRM.Server.Data;
using CRM.Server.Data.CustomerRepo;
using CRM.Server.Models;
using CRM.Server.Models.CustomerModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Server.Services.CustomerServices
{
   public class CustomerStatusService
    {
        private readonly CustomerStatusRepo _customerStatusRepo;
        public CustomerStatusService(string connectionString)
        {
            _customerStatusRepo = new CustomerStatusRepo(connectionString);
        }

        public async Task<List<CustomerStatus>> GetAllCustStatusAsync()
        {
            return await _customerStatusRepo.GetAllCustStatusAsync().ConfigureAwait(false);
        }
    }
}
