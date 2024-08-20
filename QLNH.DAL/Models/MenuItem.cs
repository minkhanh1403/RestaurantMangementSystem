using System;
using System.Collections.Generic;

#nullable disable

namespace QLNH.DAL.Models
{
    public partial class MenuItem
    {
        public MenuItem()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int MenuItemId { get; set; }
        public string MenuItemName { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int Quantity { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
