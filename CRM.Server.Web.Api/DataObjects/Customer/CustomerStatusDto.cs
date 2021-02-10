using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.Server.Web.Api.DataObjects.Customer
{
    public class CustomerStatusDto
    {
        public int Id { get; set; }

        public string Status { get; set; }

        public string NormalizedStatus { get; set; }
    }
}
