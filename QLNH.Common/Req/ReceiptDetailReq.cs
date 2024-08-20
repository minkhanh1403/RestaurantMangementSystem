using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNH.Common.Req
{
    public class ReceiptDetailReq
    {
        public List<string> Food { get; set; }
        public decimal Total { get; set; }
        public DateTime Time { get; set; }
    }
}
