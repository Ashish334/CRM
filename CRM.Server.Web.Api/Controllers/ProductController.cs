using CRM.Server.Models.CustomerModels;
using CRM.Server.Models.ProductModels;
using CRM.Server.Services;
using CRM.Server.Services.CustomerServices;
using CRM.Server.Services.Domain;
using CRM.Server.Services.ProductServices;
using CRM.Server.Web.Api.DataObjects.Customer;
using CRM.Server.Web.Api.DataObjects.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CRM.Server.Web.Api.Controllers
{
    [ApiController]
    public class ProductController : BaseAuthorizeController
    {
        private readonly ProductByIdServices _productByIdServices;
        private readonly CreateProductAsyncServices _createProductAsyncServices;
        private readonly ProductAllListServices _productAllListServices;
        private readonly UpdateProductServices _updateProductServices;

        public ProductController(UpdateProductServices updateProductServices,ProductAllListServices productAllListServices, CreateProductAsyncServices createProductAsyncServices, ProductByIdServices productByIdServices)
        {
            _productByIdServices = productByIdServices;
            _createProductAsyncServices = createProductAsyncServices;
            _productAllListServices = productAllListServices;
            _updateProductServices = updateProductServices;
        }



        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("api/ProductDetails/{Id}")]
        public async Task<IActionResult> GetProductDetailsByIdAsync(long Id)
        {
            var InstProduct = await _productByIdServices.GetProductDetailsByIdAsync(Id);
            if (InstProduct == null)
            {
                return NoContent();
            }

            var ProductlistbyId = new ProductMasterDto
            {
                Id = InstProduct.Id,
                Name = InstProduct.Name,
                Status= InstProduct.Status,
                Price = InstProduct.Price,
                GST = InstProduct.GST,
                HSNCode = InstProduct.HSNCode

            };
            return Ok(ProductlistbyId);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("/api/product/create")]
        public async Task<IActionResult> CreateProductAsync(ProductMasterDto proCredentials)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productma = new ProductMaster
            {
                Name = proCredentials.Name,
                Price = proCredentials.Price,
                Status = proCredentials.Status,
                GST = proCredentials.GST,
                HSNCode = proCredentials.HSNCode,
            };

            await _createProductAsyncServices.CreateProductAsync(productma);
            return Ok();

        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("api/Product/getall")]
        public async Task<IActionResult> GetAllProductListTypeAsync()
        {
            var productlist = await _productAllListServices.GetAllProductListTypeAsync();
            if (productlist == null)
            {
                return NoContent();
            }
            var productAlllist = new List<ProductMasterDto>();
            foreach (var prolist in productlist)
            {
                productAlllist.Add(new ProductMasterDto
                {
                    Id = prolist.Id,
                    Name = prolist.Name,
                    Price = prolist.Price,
                    Status = prolist.Status,
                    GST = prolist.GST,
                    HSNCode = prolist.HSNCode

                });

            }

            return Ok(productAlllist);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("/api/product/update")]
        public async Task<IActionResult> UpdateProductByIdAsync(ProductMasterDto requestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = new ProductMaster
            {
                Id = requestDto.Id,
                Name = requestDto.Name,
                Price = requestDto.Price,
                Status = requestDto.Status,
                GST = requestDto.GST,
                HSNCode = requestDto.HSNCode

            };

            await _updateProductServices.UpdateProductByIdAsync(product);
            return Ok();

        }
    }

}