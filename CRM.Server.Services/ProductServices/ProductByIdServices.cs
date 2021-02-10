using CRM.Server.Data.ProductRepo;
using CRM.Server.Models.CustomerModels;
using CRM.Server.Models.ProductModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Server.Services.ProductServices
{
  public  class ProductByIdServices
    {
        private readonly ProductByIdRepo _productByIdRepo;
        public ProductByIdServices(string connectionString)
        {
            _productByIdRepo = new ProductByIdRepo(connectionString);
        }

        public async Task<ProductMaster> GetProductDetailsByIdAsync(long Id)
        {
            return await _productByIdRepo.GetProductDetailsByIdAsync(Id).ConfigureAwait(false);
        }
    }
}
