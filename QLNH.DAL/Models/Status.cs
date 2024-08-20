using System;
using System.Collections.Generic;

#nullable disable

namespace QLNH.DAL.Models
{
    public partial class Status
    {
        public Status()
        {
            OrderDetails = new HashSet<OrderDetail>();
            Orders = new HashSet<Order>();
            Tables = new HashSet<Table>();
        }

        public int StatusId { get; set; }
        public string StatusName { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Table> Tables { get; set; }
    }
}
