using QLNH.Common.BLL;
using QLNH.Common.Rsp;
using QLNH.DAL;
using QLNH.DAL.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNH.BLL
{
    public class MenuItemsStatisticsSvc : GenericSvc<MenuItemsStatisticsRep, MenuItemsStatistics>
    {
        MenuItemsStatisticsRep rep = new MenuItemsStatisticsRep();
        private MenuItemsStatisticsRep menuItemsstatisticsRep;
        public MenuItemsStatisticsSvc()
        {
            menuItemsstatisticsRep = new MenuItemsStatisticsRep();
        }
        public SingleRsp GetMenuItemsStatistics()
        {
            var res = new SingleRsp();
            res.Data = _rep.GetMenuItemsStatistics();
            return res;
        }
    }
}
