using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.Server.Web.Api.DataObjects.Customer
{
    public class CustomerLeadTypeDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string NormalizedName { get; set; }
    }
}
