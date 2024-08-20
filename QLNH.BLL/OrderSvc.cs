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
    public class OrderSvc : GenericSvc<OrderRep, Order>
    {
        private OrderRep orderRep;
        private MenuRep menuRep;
        private TableRep tableRep;
        
        public OrderSvc()
        {
            orderRep = new OrderRep();
            menuRep = new MenuRep();
            tableRep = new TableRep();
        }

     
        public SingleRsp TakeOrder(CreateOrderReq createOrderReq)
        {
            var res = new SingleRsp();
            Order order = new Order();
            Table table = new Table();

            //Kiểm tra bàn còn trống không 
            var checkTable = tableRep.All.Where(i => i.TableId == createOrderReq.TableId).FirstOrDefault();
            if ((checkTable != null)
                && (tableRep.All.First(i => i.TableId == createOrderReq.TableId).StatusId == 1)) // nếu bàn không sai điều kiện và status là Empty thì cho đặt hàng
            {
                //update status của table
                table.TableId = createOrderReq.TableId;
                table.TableName = tableRep.All.First(i => i.TableId == createOrderReq.TableId).TableName;
                table.StatusId = 3;
                tableRep.UpdateTableStatus(table);

                //lấy dữ liệu cho bảng order
                order.TableId = createOrderReq.TableId;
                order.EmployeeId = createOrderReq.EmployeeId;
                order.OrderDate = DateTime.Now;
                order.StatusId = 12;
                res = orderRep.CreateOrder(order);//lưu vô database 


            }
            else
            {
                res.SetError("Not Available Table");
            }
            return res;
        }

        public SingleRsp OrderFood (OrderFoodReq orderFoodReq)
        {
            var res = new SingleRsp();
            OrderDetail orderDetail = new OrderDetail();
            Order order = new Order();
            MenuItem menuItem = new MenuItem();

            //kiểm tra có món không 
            var checkFood = menuRep.All.Where(i => i.MenuItemId == orderFoodReq.MenuItemId).FirstOrDefault();

            if ((checkFood != null)
                && ( orderFoodReq.Quantity <= menuRep.All.First(i => i.MenuItemId == orderFoodReq.MenuItemId).Quantity) )//Nếu đồ ăn không sai điều kiện và số lượng món ăn không vượt quá số lượng tồn kho trong dữ liệu thfi chạy
            {
                //lấy dữ liệu cho bảng orderDetails  
                orderDetail.OrderId = orderRep.All.OrderBy(i => i.OrderId).Last().OrderId; // lấy orderID là Order cuối cùng được tạo
                orderDetail.MenuItemId = int.Parse(orderFoodReq.MenuItemId.ToString());
                orderDetail.Quantity = orderFoodReq.Quantity;
                decimal price = menuRep.All.First(i => i.MenuItemId == orderFoodReq.MenuItemId).Price; // lấy giá trong menu ra
                orderDetail.Subtotal = price * orderFoodReq.Quantity; // lấy giá nhân với quantity ra được subtotal 
                orderDetail.StatusId = 7;
                orderDetail.OrderId = orderRep.All.OrderBy(i => i.OrderId).Last().OrderId;// ở trên đã lưu order rồi, nên orderID bên orderdetail sẽ lấy đơn hàng cuối cùng được tạo.
                res = orderRep.OrderFood(orderDetail);//lưu vô database 

                //Update số lượng cho món ăn    
                menuItem.MenuItemId = orderFoodReq.MenuItemId;
                menuItem.MenuItemName = menuRep.All.First(i => i.MenuItemId == orderFoodReq.MenuItemId).MenuItemName;
                menuItem.Price = menuRep.All.First(i => i.MenuItemId == orderFoodReq.MenuItemId).Price;
                menuItem.CategoryId = menuRep.All.First(i => i.MenuItemId == orderFoodReq.MenuItemId).CategoryId;
                menuItem.Quantity = menuRep.All.First(i => i.MenuItemId == orderFoodReq.MenuItemId).Quantity - orderFoodReq.Quantity;
                menuRep.UpdateMenu(menuItem);
            }
            else
            {
                res.SetError("Not Available Food");
                
            }
         return res;
        }

       
    }
}
