using CRM.Server.Data.CustomerRepo;
using CRM.Server.Models.CustomerModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Server.Services.CustomerServices
{
  public  class CustomerLeadTypeServices
    {
        private readonly CustomerLeadTypeRepo _customerLeadTypeRepo;
        public CustomerLeadTypeServices(string connectionString)
        {
            _customerLeadTypeRepo = new CustomerLeadTypeRepo(connectionString);
        }

        public async Task<List<CustomerLeadType>> GetAllLeadTypeAsync()
        {
            return await _customerLeadTypeRepo.GetAllLeadTypeAsync().ConfigureAwait(false);
        }
    }
}
