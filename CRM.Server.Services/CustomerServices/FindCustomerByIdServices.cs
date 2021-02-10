using CRM.Server.Data.CustomerRepo;
using CRM.Server.Models.CustomerModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Server.Services.CustomerServices
{
  public  class FindCustomerByIdServices
    {
        private readonly FindCustomerByIdRepo _findCustomerByIdRepo;
        public FindCustomerByIdServices(string connectionString)
        {
            _findCustomerByIdRepo = new FindCustomerByIdRepo(connectionString);
        }

        public async Task<CustomerMaster> FindCustomerByIdTypeAsync(long Id)
        {
            return await _findCustomerByIdRepo.FindCustomerByIdTypeAsync(Id).ConfigureAwait(false);
        }
    }
}
