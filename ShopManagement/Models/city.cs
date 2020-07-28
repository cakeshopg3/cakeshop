namespace ShopManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("city")]
    public partial class city
    {
        public long id { get; set; }

        public int? country_id { get; set; }

        [Required]
        [StringLength(255)]
        public string city_name { get; set; }

    }
}
