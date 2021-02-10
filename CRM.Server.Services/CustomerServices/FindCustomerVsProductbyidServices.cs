using CRM.Server.Data.CustomerRepo;
using CRM.Server.Models.CustomerModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Server.Services.CustomerServices
{
  public  class FindCustomerVsProductbyidServices
    {
        private readonly FindCustomerVsProductbyidRepo _findCustomerVsProductbyidRepo;

        public FindCustomerVsProductbyidServices (string connectionString)
        {
            _findCustomerVsProductbyidRepo = new FindCustomerVsProductbyidRepo(connectionString);
        }
        public async Task<List<CustomerVsProduct>> FindcustomervsproductByIdTypeAsync(long Id)
        {
            return await _findCustomerVsProductbyidRepo.FindcustomervsproductByIdTypeAsync(Id).ConfigureAwait(false);
        }
    }
}
