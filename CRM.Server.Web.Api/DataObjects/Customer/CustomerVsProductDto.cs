using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.Server.Web.Api.DataObjects.Customer
{
    public class CustomerVsProductDto
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
        public decimal netamt { get; set; }
    }
}
