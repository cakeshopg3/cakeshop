namespace ShopManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class order
    {
        public long id { get; set; }

        [Required]
        [StringLength(255)]
        public string customer_name { get; set; }

        [StringLength(255)]
        public string phone_number { get; set; }

        [StringLength(255)]
        public string address_shipping { get; set; }

        public string note { get; set; }

        public int? country_id { get; set; }
        public int? city_id { get; set; }
        public int? district_id { get; set; }
        public int? ward_id { get; set; }
    }
}
