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
    public class RevenueStatisticsRep : GenericRep<QuanLyNhaHangContext, RevenueStatistics>
    {
        public RevenueStatisticsRep() { }

        public SingleRsp GetRevenueStatistics(DateTime startDate, DateTime endDate)
        {
            var res = new SingleRsp();


            using (var context = new QuanLyNhaHangContext())
            {
                // Truy vấn dữ liệu thống kê doanh thu theo startDate và endDate
                var statisticsData = context.OrderDetails
                  .Where(d => d.Order.OrderDate >= startDate && d.Order.OrderDate <= endDate)
                  .GroupBy(d => d.Order.OrderDate.Date) 
                  .Select(g => new RevenueStatistics
                  {
                      Date = g.Key,
                      TotalRevenue = g.Sum(d => d.Subtotal)
                  })
                  .ToList();


            
                res.Data = statisticsData;
            }



            return res;
        }

        public SingleRsp GetRevenueStatisticsByMonth(DateTime startDate, DateTime endDate)
        {
            var res = new SingleRsp();

            using (var context = new QuanLyNhaHangContext())
            {
                // Truy vấn dữ liệu thống kê doanh thu theo tháng (Month)
                var statisticsData = context.OrderDetails
                  .Where(d => d.Order.OrderDate >= startDate && d.Order.OrderDate <= endDate)
                  .GroupBy(d => new { Year = d.Order.OrderDate.Year, Month = d.Order.OrderDate.Month }) 
                  .Select(g => new RevenueStatistics
                  {
                      Date = new DateTime(g.Key.Year, g.Key.Month, 1),
                      TotalRevenue = g.Sum(d => d.Subtotal)
                  })
                  .ToList();

           
                res.Data = statisticsData;
            }

            return res;
        }
        public SingleRsp GetRevenueStatisticsAllday()
        {
            var res = new SingleRsp();

            using (var context = new QuanLyNhaHangContext())
            {
                // Truy vấn dữ liệu thống kê doanh thu tất cả các ngày
                var statisticsData = context.OrderDetails
                  .GroupBy(d => d.Order.OrderDate.Date) 
                  .Select(g => new RevenueStatistics
                  {
                      Date = g.Key,
                      TotalRevenue = g.Sum(d => d.Subtotal)
                  })
                  .ToList();

              
                res.Data = statisticsData;
            }

            return res;
        }
        public SingleRsp GetRevenueStatisticsAllMonth()
        {
            var res = new SingleRsp();

            using (var context = new QuanLyNhaHangContext())
            {
                // Truy vấn dữ liệu thống kê doanh thu theo tất cả các tháng
                var statisticsData = context.OrderDetails
                  .GroupBy(d => new { Year = d.Order.OrderDate.Year, Month = d.Order.OrderDate.Month }) 
                  .Select(g => new RevenueStatistics
                  {
                      Date = new DateTime(g.Key.Year, g.Key.Month, 1), 
                      TotalRevenue = g.Sum(d => d.Subtotal)
                  })
                  .ToList();

                res.Data = statisticsData;
            }

            return res;
        }

    }

}

