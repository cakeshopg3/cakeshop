using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopManagement.DTO.Response
{
    public class OrderResponseDTO
    {
        public long id { get; set; }

        public string customer_name { get; set; }

        public string phone_number { get; set; }

        public string address_shipping { get; set; }

        public string note { get; set; }

        public string country_name { get; set; }
        public string city_name { get; set; }
        public string district_name { get; set; }
        public string ward_name { get; set; }
    }
}