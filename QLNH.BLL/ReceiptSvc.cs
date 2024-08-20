using QLNH.Common.BLL;
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
    public class ReceiptSvc : GenericSvc<ReceiptRep, Receipt>
    {
        private ReceiptRep receiptRep;
        private OrderDetailRep orderDetailRep;
        private MenuRep menuRep;
        private OrderRep orderRep;
        public ReceiptSvc()
        {
            receiptRep = new ReceiptRep();
            orderDetailRep = new OrderDetailRep();
            menuRep = new MenuRep();
            orderRep = new OrderRep();
        }


        public SingleRsp CreateReceipt(int id)
        {
           var res = new SingleRsp();
           var checkOrder = orderRep.All.Where(i => i.OrderId == id).FirstOrDefault();
            if (checkOrder != null)
            {
                List<int> menuid = orderDetailRep.All.Where(i => i.OrderId == id).Select(i => i.MenuItemId).ToList(); // lấy id món ăn được đặt        
                List<string> ReceiptFood = menuRep.GetFoodName(menuid);// lấy tên món ăn được đặt

                var details = orderDetailRep.All
                    .Where(i => i.OrderId == id)
                    .GroupBy(i => i.OrderId)
                    .Select(g => new ReceiptDetailReq
                    {
                        Food = ReceiptFood,
                        Total = orderDetailRep.All.Where(i => i.OrderId == id).Sum(i => i.Subtotal),
                        Time = DateTime.Now
                    }).ToList();

                res.Data = details;
            }
            else
            {
                res.SetError("Invalid Order ID");
                
            }
               
                return res;
                     
        }

        public SingleRsp PayReceipt(int id)
        {
            var checkOrder = orderRep.All.Where(i => i.OrderId == id).FirstOrDefault();
            var res = new SingleRsp();
            if (checkOrder != null)
            {
                if (orderRep.All.First(i => i.OrderId == id).StatusId == 12)
                {
                   ;
                    Receipt receipt = new Receipt();
                    receipt.OrderId = id;
                    receipt.PaymentDate = DateTime.Now;
                    decimal Total = orderDetailRep.All.Where(i => i.OrderId == id).Sum(i => i.Subtotal);
                    receipt.TotalAmount = Total;
                    res = receiptRep.CreateReceipt(receipt);

                    //update order
                    Order order = new Order();
                    order.OrderId = id;
                    order.TableId = orderRep.All.First(i => i.OrderId == id).TableId;
                    order.EmployeeId = orderRep.All.First(i => i.OrderId == id).EmployeeId;
                    order.OrderDate = orderRep.All.First(i => i.OrderId == id).OrderDate;
                    order.StatusId = 13;
                    orderRep.UpdateOrder(order);
                    return res;
                }
                else
                {
                   
                    res.SetError("Your Receipt Had Been Paid Before");
                }
            }
            else
            {
                res.SetError("Invalid Order ID");
                   
            }
            return res;

        }
    }
}
