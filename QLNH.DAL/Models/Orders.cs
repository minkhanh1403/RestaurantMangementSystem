using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace QLNH.DAL.Models
{
    public partial class Orders
    {
        public Orders()
        {
            OrderDetails = new HashSet<OrderDetail>();
            Receipts = new HashSet<Receipt>();
        }
        [Key]
        public int OrderId { get; set; }
        public int TableId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime? OrderDate { get; set; }
        public int StatusId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Status Status { get; set; }
        public virtual Table Table { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<Receipt> Receipts { get; set; }
    }
}
