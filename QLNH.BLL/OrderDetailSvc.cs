using QLNH.Common.BLL;
using QLNH.Common.Rsp;
using QLNH.Common.Req;
using QLNH.DAL;
using QLNH.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNH.BLL
{
    public class OrderDetailSvc : GenericSvc<OrderDetailRep, OrderDetail>
    {
        private OrderDetailRep orderDetailRep;
        private MenuRep menuRep;
        private StatusRep statusRep;
        public OrderDetailSvc()
        {
            orderDetailRep = new OrderDetailRep();
            menuRep = new MenuRep();
            statusRep = new StatusRep();
        }
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            res.Data = _rep.Read(id); //_rep: đại diện cho database 
            return res;
        }

        public SingleRsp CheckOrderStatus(int id)
        {           
            var res = new SingleRsp();
            List<int> menuid = orderDetailRep.All.Where(i => i.OrderId == id).Select(i => i.MenuItemId).ToList();
            List<string> FoodName = menuRep.GetFoodName(menuid);// lấy tên món ăn được đặt 
            if(orderDetailRep.All.Where(i => i.OrderId == id ).FirstOrDefault() != null)
            {
                int StatusId = orderDetailRep.All.First(i => i.OrderId == id).StatusId;
                string StatusName = statusRep.All.First(i => i.StatusId == StatusId).StatusName;

                var status = orderDetailRep.All.Where(i => i.OrderId == id)
                    .GroupBy(i => i.OrderId)
                    .Select(i => new CheckOrderStatusReq
                    {
                        Food = FoodName,
                        Status = StatusName
                    }).ToList();
                res.Data = status;
            }
            else
            {
                res.SetError("Invalid Order Id");
            }
            return res;
        }
    }
}
 