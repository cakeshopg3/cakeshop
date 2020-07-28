namespace ShopManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("colors")]
    public partial class color
    {
        public long id { get; set; }

        [Required]
        [StringLength(255)]
        public string color_name { get; set; }

    }
}
