namespace ShopManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sizes")]
    public partial class size
    {
        public long id { get; set; }

        [Required]
        [StringLength(255)]
        public string size_name { get; set; }

    }
}
