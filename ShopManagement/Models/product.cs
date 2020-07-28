namespace ShopManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class product
    {
        public long id { get; set; }

        [StringLength(50)]
        public string product_name { get; set; }

        public int? category { get; set; }

        [Column(TypeName = "money")]
        public decimal? price { get; set; }

        public string image_url { get; set; }

        public string description { get; set; }
        public bool isPopular { get; set; }

        [Column(TypeName = "money")]
        public decimal? origin_price { get; set; }

        public int? size_id { get; set; }

        public int? color_id { get; set; }

    }
}
