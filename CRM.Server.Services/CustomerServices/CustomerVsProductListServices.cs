using CRM.Server.Data.CustomerRepo;
using CRM.Server.Models.CustomerModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Server.Services.CustomerServices
{
    public class CustomerVsProductListServices
    {

        private readonly CustomerVsProductListRepo _customerVsProductListRepo;


        public CustomerVsProductListServices(string connectionString)
        {
            _customerVsProductListRepo = new CustomerVsProductListRepo(connectionString);
        }

        public async Task<List<CustomerVsProduct>> GetAllcustomervsproductTypeAsync()
        {
            return await _customerVsProductListRepo.GetAllcustomervsproductTypeAsync().ConfigureAwait(false);
        }
    }
}
