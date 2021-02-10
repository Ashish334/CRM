using CRM.Server.Data.ProductRepo;
using CRM.Server.Models.ProductModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Server.Services.ProductServices
{
   public class CreateProductAsyncServices
    
         {
        private readonly CreateProductAsyncRepo _createProductAsyncRepo;
        public CreateProductAsyncServices(string connectionString)
        {
            _createProductAsyncRepo = new CreateProductAsyncRepo(connectionString);
        }

        public async Task<int> CreateProductAsync(ProductMaster productma)
        {
            return await _createProductAsyncRepo.CreateProductAsync(productma).ConfigureAwait(false);
        }
    
}
}
