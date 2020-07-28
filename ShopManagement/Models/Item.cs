using ShopManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeviceManagement.Models
{
    public class Item
    {
        public product product { get; set; }

        public int Quantity { get; set; }
    }
}