using CRM.Server.Data.CustomerRepo;
using CRM.Server.Models.CustomerModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Server.Services.CustomerServices
{
  public  class CustomerVsProductServices
    {
        private readonly CustomerVsProductRepo _customerVsProductRepo;

        public CustomerVsProductServices(string connectionString)
        {
            _customerVsProductRepo = new CustomerVsProductRepo(connectionString);
        }
        public async Task<int> CreatecustomervsproductAsync(CustomerVsProduct customerproduct)
        {
            return await _customerVsProductRepo.CreatecustomervsproductAsync(customerproduct).ConfigureAwait(false);
        }
    }
}
