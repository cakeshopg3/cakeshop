using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopManagement.DTO.Response
{
    public class ProductResponseDTO
    {
        public long id { get; set; }

        public string product_name { get; set; }

        public string category_name { get; set; }

        public decimal? origin_price { get; set; }
        public decimal? price { get; set; }

        public string image_url { get; set; }

        public string description { get; set; }

        public bool isPopular { get; set; }
        public string color_name { get; set; }
        public string size_name { get; set; }
    }
}