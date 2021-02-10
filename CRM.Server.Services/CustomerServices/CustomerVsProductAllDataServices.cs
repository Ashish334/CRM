using CRM.Server.Data.CustomerRepo;
using CRM.Server.Models.CustomerModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Server.Services.CustomerServices
{
   public class CustomerVsProductAllDataServices
    {

        private readonly CustomerVsProductAllDataRepo _customerVsProductAllDataRepo;


        public CustomerVsProductAllDataServices(string connectionString)
        {
            _customerVsProductAllDataRepo = new CustomerVsProductAllDataRepo(connectionString);
        }

        public async Task<List<CustomerVsProducrAll>> GetcustomervsproductData(long Id)
        {
            return await _customerVsProductAllDataRepo.GetcustomervsproductData(Id).ConfigureAwait(false);
        }
    }
}
