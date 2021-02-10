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
    public class CustomerController : BaseAuthorizeController
    {
        private readonly CustomerStatusService _customerStatusService;
        private readonly CustomerLeadTypeServices _customerLeadTypeServices;
        private readonly CustomerInterestedProductServices _customerInterestedProductServices;
        private readonly CustomerBusinessTypeService _customerBusinessTypeService;
        private readonly CustomerMasterServices _customerMasterServices;
        private readonly CustomerAllListServices _customerAllListServices;
        private readonly FindCustomerByIdServices _findCustomerByIdServices;
        private readonly UpdateCustomerServices _updateCustomerServices;
        private readonly CustomerVsProductServices _customerVsProductServices;
        private readonly CustomerVsProductListServices _customerVsProductListServices;
        private readonly FindCustomerVsProductbyidServices _findCustomerVsProductbyidServices;
        private readonly CustomerVsProductAllDataServices _customerVsProductAllDataServices;
        private readonly UpdateCustomerVsProductServices _updateCustomerVsProductServices;


        public CustomerController(UpdateCustomerVsProductServices updateCustomerVsProductServices, CustomerVsProductAllDataServices customerVsProductAllDataServices,FindCustomerVsProductbyidServices findCustomerVsProductbyidServices, CustomerVsProductListServices customerVsProductListServices, CustomerVsProductServices customerVsProductServices, UpdateCustomerServices updateCustomerServices, FindCustomerByIdServices findCustomerByIdServices, CustomerAllListServices customerAllListServices, CustomerStatusService customerStatusService, CustomerLeadTypeServices customerLeadTypeServices, CustomerInterestedProductServices customerInterestedProductServices, CustomerBusinessTypeService customerBusinessTypeService, CustomerMasterServices customerMasterServices)
        {
            _customerStatusService = customerStatusService;
            _customerLeadTypeServices = customerLeadTypeServices;
            _customerInterestedProductServices = customerInterestedProductServices;
            _customerBusinessTypeService = customerBusinessTypeService;
            _customerMasterServices = customerMasterServices;
            _customerAllListServices = customerAllListServices;
            _findCustomerByIdServices = findCustomerByIdServices;
            _updateCustomerServices = updateCustomerServices;
            _customerVsProductServices = customerVsProductServices;
            _customerVsProductListServices = customerVsProductListServices;
            _findCustomerVsProductbyidServices = findCustomerVsProductbyidServices;
            _customerVsProductAllDataServices = customerVsProductAllDataServices;
            _updateCustomerVsProductServices = updateCustomerVsProductServices;



        }


        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("api/Customer/Status")]
        public async Task<IActionResult> GetAllCustStatusAsync()
        {
            var cstatus = await _customerStatusService.GetAllCustStatusAsync();
            if (cstatus == null)
            {
                return NoContent();
            }
            var customerStatusList = new List<CustomerStatusDto>();
            foreach (var cstatuslist in cstatus)
            {
                customerStatusList.Add(new CustomerStatusDto
                {
                    Id = cstatuslist.Id,
                    Status = cstatuslist.Status,
                    NormalizedStatus = cstatuslist.NormalizedStatus

                });

            }

            return Ok(customerStatusList);
        }


        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("api/Customer/LeadType")]
        public async Task<IActionResult> GetAllLeadTypeAsync()
        {
            var leadType = await _customerLeadTypeServices.GetAllLeadTypeAsync();
            if (leadType == null)
            {
                return NoContent();
            }
            var customerleadTypelist = new List<CustomerLeadTypeDto>();
            foreach (var leadTypelist in leadType)
            {
                customerleadTypelist.Add(new CustomerLeadTypeDto
                {
                    Id = leadTypelist.Id,
                    Name = leadTypelist.Name,
                    NormalizedName = leadTypelist.NormalizedName

                });

            }

            return Ok(customerleadTypelist);
        }


        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("api/Customer/IntrustedProduct")]
        public async Task<IActionResult> GetAllInstProductAsync()
        {
            var InstProduct = await _customerInterestedProductServices.GetAllInstProductAsync();
            if (InstProduct == null)
            {
                return NoContent();
            }
            var customerInstProductlist = new List<ProductMasterDto>();
            foreach (var InstProductlist in InstProduct)
            {
                customerInstProductlist.Add(new ProductMasterDto
                {
                    Id = InstProductlist.Id,
                    Name = InstProductlist.Name,
                });

            }

            return Ok(customerInstProductlist);
        }


        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("api/Customer/BusinessType")]
        public async Task<IActionResult> GetAllBusinessTypeAsync()
        {
            var BusinessType = await _customerBusinessTypeService.GetAllBusinessTypeAsync();
            if (BusinessType == null)
            {
                return NoContent();
            }
            var customerBusinessTypelist = new List<CustomerBusinessTypeDto>();
            foreach (var BusinessTypelist in BusinessType)
            {
                customerBusinessTypelist.Add(new CustomerBusinessTypeDto
                {
                    Id = BusinessTypelist.Id,
                    Name = BusinessTypelist.Name,
                    NormalizedName = BusinessTypelist.NormalizedName

                });

            }

            return Ok(customerBusinessTypelist);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("/api/customer/create")]
        public async Task<IActionResult> CreateCustomerAsync(CustomerMasterDto custCredentials)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customer = new CustomerMaster
            {
                Name = custCredentials.Name,
                Domain = custCredentials.Domain,
                Email = custCredentials.Email,
                ShopName = custCredentials.ShopName,
                Mobile = custCredentials.Mobile,
                Address1 = custCredentials.Address1,
                Address2 = custCredentials.Address2,
                Address3 = custCredentials.Address3,
                District = custCredentials.District,
                City = custCredentials.City,
                State = custCredentials.State,
                PinCode = custCredentials.PinCode,
                Status = custCredentials.Status,
                InterestedProduct = custCredentials.InterestedProduct,
                LeadType = custCredentials.LeadType,
                BusinessType = custCredentials.BusinessType,
                ReferenceName = custCredentials.ReferenceName
            };

            await _customerMasterServices.CreateCustomerAsync(customer);
            return Ok();

        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("api/customer/getall")]
        public async Task<IActionResult> GetAllCustomerListTypeAsync()
        {
            var Custlist = await _customerAllListServices.GetAllCustomerListTypeAsync();
            if (Custlist == null)
            {
                return NoContent();
            }
            var customerAlllist = new List<CustomerMasterDto>();
            foreach (var customerlist in Custlist)
            {
                customerAlllist.Add(new CustomerMasterDto
                {
                    Id = customerlist.Id,
                    Name = customerlist.Name,
                    Domain = customerlist.Domain,
                    Email = customerlist.Email,
                    ShopName = customerlist.ShopName,
                    Mobile = customerlist.Mobile,
                    Address1 = customerlist.Address1,
                    Address2 = customerlist.Address2,
                    Address3 = customerlist.Address3,
                    District = customerlist.District,
                    City = customerlist.City,
                    State = customerlist.State,
                    PinCode = customerlist.PinCode,
                    Status = customerlist.Status,
                    InterestedProduct = customerlist.InterestedProduct,
                    LeadType = customerlist.LeadType,
                    BusinessType = customerlist.BusinessType,
                    ReferenceName = customerlist.ReferenceName

                });

            }

            return Ok(customerAlllist);
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("api/customer/{id}")]
        public async Task<IActionResult> FindCustomerByIdTypeAsync(long Id)
        {
            var findbyid = await _findCustomerByIdServices.FindCustomerByIdTypeAsync(Id);
            if (findbyid == null)
            {
                return NoContent();
            }
            var customerfindbyid = new CustomerMasterDto
            {
                Id = findbyid.Id,
                Name = findbyid.Name,
                Domain = findbyid.Domain,
                Email = findbyid.Email,
                ShopName = findbyid.ShopName,
                Mobile = findbyid.Mobile,
                Address1 = findbyid.Address1,
                Address2 = findbyid.Address2,
                Address3 = findbyid.Address3,
                District = findbyid.District,
                City = findbyid.City,
                State = findbyid.State,
                PinCode = findbyid.PinCode,
                Status = findbyid.Status,
                InterestedProduct = findbyid.InterestedProduct,
                LeadType = findbyid.LeadType,
                BusinessType = findbyid.BusinessType,
                ReferenceName = findbyid.ReferenceName

            };

            return Ok(customerfindbyid);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("/api/customer/update")]
        public async Task<IActionResult> UpdateCustomerByIdAsync(CustomerMasterDto requestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customer = new CustomerMaster
            {
                Id = requestDto.Id,
                Name = requestDto.Name,
                Domain = requestDto.Domain,
                Email = requestDto.Email,
                ShopName = requestDto.ShopName,
                Mobile = requestDto.Mobile,
                Address1 = requestDto.Address1,
                Address2 = requestDto.Address2,
                Address3 = requestDto.Address3,
                District = requestDto.District,
                City = requestDto.City,
                State = requestDto.State,
                PinCode = requestDto.PinCode,
                Status = requestDto.Status,
                InterestedProduct = requestDto.InterestedProduct,
                LeadType = requestDto.LeadType,
                BusinessType = requestDto.BusinessType,
                ReferenceName = requestDto.ReferenceName
            };

            await _updateCustomerServices.UpdateCustomerByIdAsync(customer);
            return Ok();

        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("/api/customervsproduct/create")]
        public async Task<IActionResult> CreatecustomervsproductAsync(List<CustomerVsProductDto> requestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            foreach (var custproduct in requestDto)
            {
                var customervsproduct = new CustomerVsProduct
                {
                    Id = custproduct.Id,
                    IndexId = custproduct.IndexId,
                    CustomerId = custproduct.CustomerId,
                    CustomerName = custproduct.CustomerName,
                    ProductName = custproduct.ProductName,
                    Price = custproduct.Price,
                    Qty = custproduct.Qty,
                    DiscountPer = custproduct.DiscountPer,
                    DiscountAmt = custproduct.DiscountAmt,
                    GstPer = custproduct.GstPer,
                    GstAmt = custproduct.GstAmt,
                    NetAmount = custproduct.netamt
                };

                await _customerVsProductServices.CreatecustomervsproductAsync(customervsproduct);
            }

            return Ok();

        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("api/customervsproduct/getall")]
        public async Task<IActionResult> GetAllcustomervsproductTypeAsync()
        {
            var Custlist = await _customerVsProductListServices.GetAllcustomervsproductTypeAsync();
            if (Custlist == null)
            {
                return NoContent();
            }
            var customerVsProductAll = new List<CustomerVsProductDto>();
            foreach (var custproduct in Custlist)
            {
                customerVsProductAll.Add(new CustomerVsProductDto
                {
                    Id = custproduct.Id,
                    IndexId = custproduct.IndexId,
                    CustomerId = custproduct.CustomerId,
                    CustomerName = custproduct.CustomerName,
                    ProductName = custproduct.ProductName,
                    Price = custproduct.Price,
                    Qty = custproduct.Qty,
                    DiscountPer = custproduct.DiscountPer,
                    DiscountAmt = custproduct.DiscountAmt,
                    GstPer = custproduct.GstPer,
                    GstAmt = custproduct.GstAmt,
                    netamt = custproduct.NetAmount

                });

            }

            return Ok(customerVsProductAll);
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("api/customervsproduct/{id}")]
        public async Task<IActionResult> FindcustomervsproductByIdTypeAsync(long Id)
        {
            var custproduct = await _findCustomerVsProductbyidServices.FindcustomervsproductByIdTypeAsync(Id);
            if (custproduct == null)
            {
                return NoContent();
            }
            var customerVsProductAllbyid = new List<CustomerVsProductDto>();
            foreach (var custproductbyid in custproduct)
            {
                customerVsProductAllbyid.Add(new CustomerVsProductDto
                {
                    Id = custproductbyid.Id,
                    IndexId = custproductbyid.IndexId,
                    CustomerId = custproductbyid.CustomerId,
                    CustomerName = custproductbyid.CustomerName,
                    ProductName = custproductbyid.ProductName,
                    Price = custproductbyid.Price,
                    Qty = custproductbyid.Qty,
                    DiscountPer = custproductbyid.DiscountPer,
                    DiscountAmt = custproductbyid.DiscountAmt,
                    GstPer = custproductbyid.GstPer,
                    GstAmt = custproductbyid.GstAmt,
                    netamt = custproductbyid.NetAmount

                });


            }
            return Ok(customerVsProductAllbyid);
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("api/customervsproductAllData/{id}")]
        public async Task<IActionResult> GetcustomervsproductData(long Id)
        {
            var Custlist = await _customerVsProductAllDataServices.GetcustomervsproductData(Id);
            if (Custlist == null)
            {
                return NoContent();
            }
            var customerVsProductAll = new List<CustomerVsProductAllDto>();
            foreach (var custproduct in Custlist)
            {
                customerVsProductAll.Add(new CustomerVsProductAllDto
                {
                    Id = custproduct.Id,
                    IndexId = custproduct.IndexId,
                    CustomerId = custproduct.CustomerId,
                    CustomerName = custproduct.CustomerName,
                    ProductName = custproduct.ProductName,
                    Price = custproduct.Price,
                    Qty = custproduct.Qty,
                    DiscountPer = custproduct.DiscountPer,
                    DiscountAmt = custproduct.DiscountAmt,
                    GstPer = custproduct.GstPer,
                    GstAmt = custproduct.GstAmt,
                    netamt = custproduct.NetAmount,
                    Domain = custproduct.Domain,
                    Email = custproduct.Email,
                    ShopName = custproduct.ShopName

                });

            }

            return Ok(customerVsProductAll);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("/api/customervsproduct/Update")]
        public async Task<IActionResult> UpdatecustomervsproductAsync(List<CustomerVsProductAllDto> requestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _updateCustomerVsProductServices.DeletecustomervsproductAsync(requestDto[0].CustomerId);
            foreach (var custproduct in requestDto)
            {
                var customervsproduct = new CustomerVsProducrAll
                {
                    Id = custproduct.Id,
                    IndexId = custproduct.IndexId,
                    CustomerId = custproduct.CustomerId,
                    CustomerName = custproduct.CustomerName,
                    ProductName = custproduct.ProductName,
                    Price = custproduct.Price,
                    Qty = custproduct.Qty,
                    DiscountPer = custproduct.DiscountPer,
                    DiscountAmt = custproduct.DiscountAmt,
                    GstPer = custproduct.GstPer,
                    GstAmt = custproduct.GstAmt,
                    NetAmount = custproduct.netamt
                };
               
                await _updateCustomerVsProductServices.UpdatecustomervsproductAsync(customervsproduct);
                
            }

            return Ok();

        }

    }

}