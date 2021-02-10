using CRM.Server.Data.CustomerRepo;
using CRM.Server.Models.CustomerModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Server.Services.CustomerServices
{
 public   class UpdateCustomerVsProductServices
    {
        private readonly UpdateCustomerVsProductRepo _updateCustomerVsProductRepo;

        public UpdateCustomerVsProductServices(string connectionString)
        {
            _updateCustomerVsProductRepo = new UpdateCustomerVsProductRepo(connectionString);
        }

        public async Task<int> DeletecustomervsproductAsync(long id)
        {
            return await _updateCustomerVsProductRepo.DeletecustomervsproductAsync(id).ConfigureAwait(false);
        }

        public async Task<int> UpdatecustomervsproductAsync(CustomerVsProducrAll customerproduct)
        {
            return await _updateCustomerVsProductRepo.UpdatecustomervsproductAsync(customerproduct).ConfigureAwait(false);
        }
        
    }
}
