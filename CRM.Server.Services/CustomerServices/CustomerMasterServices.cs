using CRM.Server.Data.CustomerRepo;
using CRM.Server.Models.CustomerModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Server.Services.CustomerServices
{
  public  class CustomerMasterServices
    {
        private readonly CustomerMasterRepo _customerMasterRepo;

        public CustomerMasterServices(string connectionString)
        {
            _customerMasterRepo = new CustomerMasterRepo(connectionString);
        }
         public async Task<int> CreateCustomerAsync(CustomerMaster customer)
            {
                return await _customerMasterRepo.CreateCustomerAsync(customer).ConfigureAwait(false);
             }
    }
}
