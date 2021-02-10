using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Server.Models.CustomerModels
{
  public  class CustomerMaster
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Domain { get; set; }
        public string Email { get; set; }
        public string ShopName { get; set; }
        public string Mobile { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PinCode { get; set; }
        public int Status { get; set; }
        public int InterestedProduct { get; set; }
        public int LeadType { get; set; }
        public int BusinessType { get; set; }
        public string ReferenceName { get; set; }

    }
}
