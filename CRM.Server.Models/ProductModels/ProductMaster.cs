using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Server.Models.ProductModels
{
  public  class ProductMaster
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
