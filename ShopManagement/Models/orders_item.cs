namespace ShopManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class orders_item
    {
        public long id { get; set; }

        public long order_id { get; set; }

        public long book_id { get; set; }

        public int quantity { get; set; }

        [Column(TypeName = "money")]
        public decimal price { get; set; }
    }
}
