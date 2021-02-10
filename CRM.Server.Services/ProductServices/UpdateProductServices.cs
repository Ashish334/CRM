using CRM.Server.Data.ProductRepo;
using CRM.Server.Models.ProductModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Server.Services.ProductServices
{
  public  class UpdateProductServices
    {
        private readonly UpdateProductRepo _updateProductRepo;
        public UpdateProductServices(string connectionString)
        {
            _updateProductRepo = new UpdateProductRepo(connectionString);
        }

        public async Task<int> UpdateProductByIdAsync(ProductMaster prodMaster)
        {
            return await _updateProductRepo.UpdateProductByIdAsync(prodMaster).ConfigureAwait(false);
        }
    }
}
