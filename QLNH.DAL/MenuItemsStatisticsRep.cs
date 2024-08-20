using Microsoft.EntityFrameworkCore;
using QLNH.Common.DAL;
using QLNH.Common.Rsp;
using QLNH.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNH.DAL
{
    public class MenuItemsStatisticsRep : GenericRep<QuanLyNhaHangContext, MenuItemsStatistics>
    {
        public MenuItemsStatisticsRep() { }
        public SingleRsp GetMenuItemsStatistics()
        {
            var res = new SingleRsp();

            using (var context = new QuanLyNhaHangContext())
            {
                // Truy vấn dữ liệu thống kê doanh thu theo món ăn
                var statisticsData = context.MenuItems
                    .Join(context.OrderDetails,
                        mi => mi.MenuItemId,
                        od => od.MenuItemId,
                        (mi, od) => new { MenuItem = mi, OrderDetail = od })
                    .GroupBy(x => new { x.MenuItem.MenuItemId, x.MenuItem.MenuItemName })
                    .Select(g => new MenuItemsStatistics
                    {
                        MenuItemId = g.Key.MenuItemId,
                        TotalQuantitySold = g.Sum(x => x.OrderDetail.Quantity),
                        TotalRevenue = g.Sum(x => x.OrderDetail.Subtotal)
                    })
                    //thêm giảm dần
                    .OrderByDescending(x => x.TotalRevenue)
                    .ToList();

                res.Data = statisticsData;
            }

            return res;
        }

    }
}
