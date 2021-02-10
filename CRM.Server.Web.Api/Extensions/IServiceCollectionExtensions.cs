using CRM.Server.Services.CustomerServices;
using CRM.Server.Services.Domain;
using CRM.Server.Services.ProductServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CRM.Server.Web.Api.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddDomainServices(this IServiceCollection services, IConfiguration configuration)
        {
            string conStr = configuration.GetConnectionString("CRMDbConnection");

            services.AddScoped<UserService>(s=> new UserService(conStr));
            services.AddScoped<RoleServices>(s => new RoleServices(conStr));
            services.AddScoped<CustomerStatusService>(s => new CustomerStatusService(conStr));
            services.AddScoped<CustomerInterestedProductServices>(s => new CustomerInterestedProductServices(conStr));
            services.AddScoped<CustomerLeadTypeServices>(s => new CustomerLeadTypeServices(conStr));
            services.AddScoped<CustomerBusinessTypeService>(s => new CustomerBusinessTypeService(conStr));
            services.AddScoped<CustomerMasterServices>(s => new CustomerMasterServices(conStr));
            services.AddScoped<CustomerAllListServices>(s => new CustomerAllListServices(conStr));
            services.AddScoped<FindCustomerByIdServices>(s => new FindCustomerByIdServices(conStr));
            services.AddScoped<UpdateCustomerServices>(s => new UpdateCustomerServices(conStr));
            services.AddScoped<ProductByIdServices>(s => new ProductByIdServices(conStr));
            services.AddScoped<CreateProductAsyncServices>(s => new CreateProductAsyncServices(conStr));
            services.AddScoped<ProductAllListServices>(s => new ProductAllListServices(conStr));
            services.AddScoped<UpdateProductServices>(s => new UpdateProductServices(conStr));
            services.AddScoped<CustomerVsProductServices>(s => new CustomerVsProductServices(conStr));
            services.AddScoped<CustomerVsProductListServices>(s => new CustomerVsProductListServices(conStr));
            services.AddScoped<FindCustomerVsProductbyidServices>(s => new FindCustomerVsProductbyidServices(conStr));
            services.AddScoped<CustomerVsProductAllDataServices>(s => new CustomerVsProductAllDataServices(conStr));
            services.AddScoped<UpdateCustomerVsProductServices>(s => new UpdateCustomerVsProductServices(conStr));


            




















        }

    }
}