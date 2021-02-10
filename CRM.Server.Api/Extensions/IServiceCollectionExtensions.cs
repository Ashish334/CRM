using CRM.Server.Services.Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.IO.Compression;

namespace CRM.Server.Web.Api
{
    public static class IServiceCollectionExtensions
    {
        public static void AddDomainServices(this IServiceCollection services, IConfiguration configuration)
        {
            string conStr = configuration.GetConnectionString("GoGoalDbConnection");

            services.AddScoped<UserService>(s=> new UserService(conStr));
            services.AddScoped<HeadService>(s => new HeadService(conStr));
            services.AddScoped<FundFlowService>(s => new FundFlowService(conStr));
            services.AddScoped<TempTransactionService>(s => new TempTransactionService(conStr));
            services.AddScoped<TransactionService>(s => new TransactionService(conStr));
            services.AddScoped<CalenderMasterService>(s => new CalenderMasterService(conStr));
            services.AddScoped<ProjectService>(s => new ProjectService(conStr));

        }

    }
}