using CRM.Server.Data.CustomerRepo;
using CRM.Server.Models.CustomerModels;
using CRM.Server.Models.ProductModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Server.Services.CustomerServices
{
  public  class CustomerInterestedProductServices
    {
        private readonly CustomerInterestedProductRepo _customerInterestedProductRepo;
        public CustomerInterestedProductServices(string connectionString)
        {
            _customerInterestedProductRepo = new CustomerInterestedProductRepo(connectionString);
        }

        public async Task<List<ProductMaster>> GetAllInstProductAsync()
        {
            return await _customerInterestedProductRepo.GetAllInstProductAsync().ConfigureAwait(false);
        }
    }
}
