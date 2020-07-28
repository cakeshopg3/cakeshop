using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopManagement.DTO.Response
{
    public class CityResponseDTO
    {
        public long id { get; set; }

        public string country_name { get; set; }

        public string city_name { get; set; }
    }
}