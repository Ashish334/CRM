using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.Server.Web.Api.DataObjects.Product
{
    public class ProductMasterDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string NormalizedName { get; set; }

        public decimal Price { get; set; }

        public string Status { get; set; }

        public int GST { get; set; }

        public string HSNCode { get; set; }
    }
}
