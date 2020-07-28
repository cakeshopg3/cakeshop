using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopManagement.Models
{
    public class OrderItemDetail
    {
        public long id { get; set; }

        public long order_id { get; set; }

        public long product_id { get; set; }

        public string product_name { get; set; }
        public string size_name { get; set; }
        public string color_name { get; set; }

        public int quantity { get; set; }

        public decimal price { get; set; }
    }
}