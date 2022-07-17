using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResturantSystem.Models
{
    public class OrderModel
    {
        public string UserId { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductPrice { get; set; }
        public string Quantity { get; set; }
        public string image { get; set; }
        public string discount { get; set; }
    }
}