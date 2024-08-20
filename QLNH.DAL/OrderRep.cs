using QLNH.Common.DAL;
using QLNH.Common.Req;
using QLNH.Common.Rsp;
using QLNH.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNH.DAL
{
    public class OrderRep : GenericRep<QuanLyNhaHangContext, Order>
    {
        public OrderRep()
        {
       
    }
        #region -- Overrides --
        public override Order Read(int id)
        {
            var res = All.FirstOrDefault(c => c.OrderId == id);
            return res;
        }
        #endregion

        #region -- Methods --
        public SingleRsp CreateOrder(Order order)
        {
            var res = new SingleRsp();
            using (var context = new QuanLyNhaHangContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    var p = context.Orders.Add(order);                  
                    context.SaveChanges();
                    tran.Commit();
                }
            }
            return res;
        }

        public SingleRsp OrderFood(OrderDetail orderDetail)
        {
            var res = new SingleRsp();
            using (var context = new QuanLyNhaHangContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    var p = context.OrderDetails.Add(orderDetail);
                    context.SaveChanges();
                    tran.Commit();
                }
            }
            return res;
        }
        #endregion

        public SingleRsp UpdateOrder(Order order)
        {
            var res = new SingleRsp();
            using (var context = new QuanLyNhaHangContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Orders.Update(order);
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }

  
    }
}
