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
    public class RevenueStatisticsSvc : GenericSvc<RevenueStatisticsRep, RevenueStatistics>
    {
        RevenueStatisticsRep rep = new RevenueStatisticsRep();
        private RevenueStatisticsRep revenuestatisticsRep;
        public RevenueStatisticsSvc() 
        {
            revenuestatisticsRep = new RevenueStatisticsRep();
        }
        public SingleRsp GetRevenueStatistics(DateTime startDate, DateTime endDate)
        {
            var res = new SingleRsp();

            res.Data= _rep.GetRevenueStatistics(startDate, endDate);

          


            return res;
        }
        public SingleRsp GetRevenueStatisticsByMonth(DateTime startDate, DateTime endDate)
        {
            var res = new SingleRsp();

         
            res.Data = _rep.GetRevenueStatisticsByMonth(startDate, endDate);

          


            return res;
        }
        public SingleRsp GetRevenueStatisticsAllday()
        {
            var res = new SingleRsp();
            res.Data = _rep.GetRevenueStatisticsAllday();
            return res;
        }
        public SingleRsp GetRevenueStatisticsAllMonth()
        {
            var res = new SingleRsp();

            // 1. Lấy dữ liệu thống kê doanh thu
            res.Data = _rep.GetRevenueStatisticsAllMonth();

            // 2. Kiểm tra dữ liệu có rỗng hay không


            return res;
        }
    }
}
