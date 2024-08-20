using System;
using System.Collections.Generic;

#nullable disable

namespace QLNH.DAL.Models
{
    public partial class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int MenuItemId { get; set; }
        public int Quantity { get; set; }
        public decimal Subtotal { get; set; }
        public int StatusId { get; set; }

        public virtual MenuItem MenuItem { get; set; }
        public virtual Order Order { get; set; }
        public virtual Status Status { get; set; }
    }
}
