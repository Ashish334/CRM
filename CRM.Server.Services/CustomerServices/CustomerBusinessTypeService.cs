using CRM.Server.Data.CustomerRepo;
using CRM.Server.Models.CustomerModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Server.Services.CustomerServices
{
  public  class CustomerBusinessTypeService
    {
        private readonly CustomerBusinessTypeRepo _customerBusinessTypeRepo;
        public CustomerBusinessTypeService(string connectionString)
        {
            _customerBusinessTypeRepo = new CustomerBusinessTypeRepo(connectionString);
        }

        public async Task<List<CustomerBusinessType>> GetAllBusinessTypeAsync()
        {
            return await _customerBusinessTypeRepo.GetAllBusinessTypeAsync().ConfigureAwait(false);
        }
    }
}
