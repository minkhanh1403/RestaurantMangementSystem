using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNH.Common.Req
{
    public class SearchEmployeeReq
    {
        public int Page { get; set; }
        public int Size { get; set; }
        //public int ID { get; set; }
        //public int Type { get; set; }
        public string Keyword { get; set; }
    }
}
