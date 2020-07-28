using ShopManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopManagement.DTO.Response
{
    public class ProductCreateModel
    {
        public long id { get; set; }

        public string product_name { get; set; }

        public int? category { get; set; }

        public decimal? price { get; set; }

        public string image_url { get; set; }

        public string description { get; set; }

        public IEnumerable<category> categories { get; set; }
    }
}