using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNH.Common.Req
{
    public class CheckOrderStatusReq
    {
        public List<string> Food { get; set; }
        public string Status { get; set; }
    }
}
