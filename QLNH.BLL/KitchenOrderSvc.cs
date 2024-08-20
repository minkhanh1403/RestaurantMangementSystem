using QLNH.Common.BLL;
using QLNH.Common.DAL;
using QLNH.Common.Req;
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
    public class KitchenOrderSvc : GenericSvc<KitchenOrderRep, OrderDetail>
    {
        private readonly KitchenOrderRep kitchenOrderRep;
        KitchenOrderRep rep = new KitchenOrderRep();
        public KitchenOrderSvc()
        {
            kitchenOrderRep = new KitchenOrderRep();
        }

        public SingleRsp UpdateOrderStatus(int orderId, string statusName)
        {
            var res = new SingleRsp();


            res = _rep.UpdateOrderStatus(orderId, statusName);
            return res;


        }
        public SingleRsp UpdateStatusOfOrderIsProcessing(int orderId)
        {
            var res = new SingleRsp();


            res = _rep.UpdateStatusOfOrderIsProcessing(orderId);
            return res;

        }
        public SingleRsp UpdateStatusOfOrderIsCooked(int orderId)
        {
            var res = new SingleRsp();



            res = _rep.UpdateStatusOfOrderIsCooked(orderId);
            return res;
        }
        public SingleRsp UpdateStatusOfOrderIsComplete(int orderId)
        {
            var res = new SingleRsp();
            res = _rep.UpdateStatusOfOrderIsComplete(orderId);
            return res;
        }
    }

}
