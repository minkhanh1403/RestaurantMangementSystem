using QLNH.Common.BLL;
using QLNH.DAL;
using QLNH.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNH.BLL
{
    public class StatusSvc : GenericSvc<StatusRep, Status>
    {
        private StatusRep statusRep;
        public StatusSvc()
        {
            statusRep = new StatusRep();
        }
    }
}
