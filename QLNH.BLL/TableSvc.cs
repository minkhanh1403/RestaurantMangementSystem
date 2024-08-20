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
    public class TableSvc : GenericSvc<TableRep, Table>
    {
        private TableRep tableRep;
        public TableSvc()
        {
            tableRep = new TableRep();
        }
            
    }
}
