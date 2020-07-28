namespace ShopManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ward")]
    public partial class ward
    {
        public long id { get; set; }

        public int? country_id { get; set; }

        public int? city_id { get; set; }

        public int? district_id { get; set; }

        [Required]
        [StringLength(255)]
        public string ward_name { get; set; }

    }
}
