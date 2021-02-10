using CRM.Server.Data.CustomerRepo;
using CRM.Server.Models.CustomerModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Server.Services.CustomerServices
{
 public   class CustomerAllListServices
    {
        private readonly CustomerAllListRepo _customerAllListRepo;
        public CustomerAllListServices(string connectionString)
        {
            _customerAllListRepo = new CustomerAllListRepo(connectionString);
        }

        public async Task<List<CustomerMaster>> GetAllCustomerListTypeAsync()
        {
            return await _customerAllListRepo.GetAllCustomerListTypeAsync().ConfigureAwait(false);
        }
    }
}
