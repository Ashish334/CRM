using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Server.Models.CustomerModels
{
   public class CustomerStatus
    {
        public int Id { get; set; }

        public string Status { get; set; }

        public string NormalizedStatus { get; set; }
    }
}
