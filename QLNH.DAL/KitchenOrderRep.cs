using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using QLNH.Common.DAL;
using QLNH.Common.Rsp;
using QLNH.DAL.Models;
using QLNH.Common.Req;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNH.DAL
{
    public class KitchenOrderRep : GenericRep<QuanLyNhaHangContext, OrderDetail>
    {
        public KitchenOrderRep() { }
        public SingleRsp UpdateStatusOfOrderIsProcessing(int orderId)
        {



            return UpdateOrderStatus(orderId, "Processing");

        }
        public SingleRsp UpdateStatusOfOrderIsCooked(int orderId)
        {




            return UpdateOrderStatus(orderId, "Cooked");

        }
        public SingleRsp UpdateStatusOfOrderIsComplete(int orderId)
        {
            return UpdateOrderStatus(orderId, "Complete");
        }
        //thêm ràng buộc 
        public SingleRsp UpdateOrderStatus(int orderId, string statusName)
        {
            var res = new SingleRsp();

            using (var context = new QuanLyNhaHangContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {

                        // Lấy tất cả các đơn hàng có orderId tương ứng
                        var orders = context.OrderDetails
                            .Where(o => o.OrderId == orderId)
                            .ToList();

                        // Kiểm tra xem có đơn hàng nào không


                        if (orders.Count == 0)
                        {
                            res.SetError("Mã Đơn hàng không hợp lệ: Không tìm thấy đơn hàng với mã đơn hàng cung cấp trong cơ sở dữ liệu.");
                            return res;
                        }

                        // Lấy statusId từ tên trạng thái
                        var statusId = context.Statuses
                        .Where(s => s.StatusName == statusName)
                        .Select(s => s.StatusId)
                        .FirstOrDefault();
                        //Kiểm tra xem tên trạng thái có hợp lệ không

                        if (statusId == 0)
                        {
                            res.SetError("Tên Trạng thái không hợp lệ: Tên Trạng thái được cung cấp không tồn tại trong cơ sở dữ liệu.");
                            return res;
                        }
                        // Kiểm tra xem trạng thái đã được cập nhật trước đó hay chưa
                        var currentStatusId = orders.FirstOrDefault().StatusId;
                        if (currentStatusId == statusId)
                        {
                            res.SetError("Trạng thái hiện tại của đơn hàng đã là '" + statusName + "' .Không thể cập nhật");
                            return res;
                        }
                        // Cập nhật trạng thái cho từng đơn hàng
                        foreach (var order in orders)
                        {
                            order.StatusId = statusId;
                        }

                        // Lưu các thay đổi vào cơ sở dữ liệu và commit transaction
                        context.SaveChanges();
                        tran.Commit();



                    }
                    catch (Exception ex)
                    {
                        // Xử lý lỗi
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }

                }
            }
            return res;
        }




    }
}




