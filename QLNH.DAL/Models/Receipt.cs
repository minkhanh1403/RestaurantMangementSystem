using System;
using System.Collections.Generic;

#nullable disable

namespace QLNH.DAL.Models
{
    public partial class Receipt
    {
        public int ReceiptId { get; set; }
        public int OrderId { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal TotalAmount { get; set; }

        public virtual Order Order { get; set; }
    }
}
