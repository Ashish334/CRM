using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Server.Models.CustomerModels
{
  public  class CustomerVsProducrAll
    {
        public int Id { get; set; }
        public int IndexId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Qty { get; set; }
        public int DiscountPer { get; set; }
        public decimal DiscountAmt { get; set; }
        public int GstPer { get; set; }
        public decimal GstAmt { get; set; }
        public decimal NetAmount { get; set; }
        public string Domain { get;  set; }
        public string Email { get; set; }
        public string ShopName { get; set; }
    }
}
