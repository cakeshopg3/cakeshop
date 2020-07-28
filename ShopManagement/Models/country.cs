namespace ShopManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("country")]
    public partial class country
    {
        public long id { get; set; }

        [Required]
        [StringLength(255)]
        public string country_name { get; set; }

    }
}
