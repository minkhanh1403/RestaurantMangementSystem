using QLNH.Common.DAL;
using QLNH.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNH.DAL
{
    public class OrderDetailRep : GenericRep<QuanLyNhaHangContext, OrderDetail>
    {
        public OrderDetailRep()
        {            
         }
        #region -- Overrides --
        public override OrderDetail Read(int id)
        {
            var res = All.FirstOrDefault(c => c.MenuItemId == id);
            return res;
        }


        #endregion
    }
}
