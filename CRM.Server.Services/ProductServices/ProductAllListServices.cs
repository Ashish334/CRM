using CRM.Server.Data.ProductRepo;
using CRM.Server.Models.ProductModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Server.Services.ProductServices
{
public    class ProductAllListServices
    {
        private readonly ProductAllListRepo _productAllListRepo;
        public ProductAllListServices(string connectionString)
        {
            _productAllListRepo = new ProductAllListRepo(connectionString);
        }

        public async Task<List<ProductMaster>> GetAllProductListTypeAsync()
        {
            return await _productAllListRepo.GetAllProductListTypeAsync().ConfigureAwait(false);
        }

    }
}
