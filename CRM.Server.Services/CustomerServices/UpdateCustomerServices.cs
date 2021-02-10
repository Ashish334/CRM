using CRM.Server.Data.CustomerRepo;
using CRM.Server.Models.CustomerModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Server.Services.CustomerServices
{
  public  class UpdateCustomerServices
    {
        private readonly UpdateCustomerRepo _updateCustomerRepo;
        public UpdateCustomerServices(string connectionString)
        {
            _updateCustomerRepo = new UpdateCustomerRepo(connectionString);
        }

        public async Task<int> UpdateCustomerByIdAsync(CustomerMaster customer)
        {
            return await _updateCustomerRepo.UpdateCustomerByIdAsync(customer).ConfigureAwait(false);
        }
    }
}
