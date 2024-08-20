using System;
using System.Collections.Generic;

#nullable disable

namespace QLNH.DAL.Models
{
    public partial class Table
    {
        public Table()
        {
            Orders = new HashSet<Order>();
        }

        public int TableId { get; set; }
        public string TableName { get; set; }
        public int StatusId { get; set; }

        public virtual Status Status { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
