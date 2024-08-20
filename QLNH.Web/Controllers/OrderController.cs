using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLNH.BLL;
using QLNH.Common.Req;
using QLNH.Common.Rsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLNH.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private OrderSvc orderSvc;
        private MenuSvc menuSvc;
        private OrderDetailSvc orderDetailSvc;
        private TableSvc tableSvc;
        public OrderController()
        {
            orderSvc = new OrderSvc();
            menuSvc = new MenuSvc();
            orderDetailSvc = new OrderDetailSvc();
            tableSvc = new TableSvc();
        }


        [HttpGet("All-Order")]
        public IActionResult AllOrder()
        {
            var res = new SingleRsp();
            res.Data = orderSvc.All;
            return Ok(res);
        }


        [HttpGet("All-Table")]
        public IActionResult AllTable()
        {
            var res = new SingleRsp();
            res.Data = tableSvc.All;
            return Ok(res);
        }


        [HttpPost("Create-Order")]
        public IActionResult CreateOrder(CreateOrderReq createOrderReq)
        {
            var res = new SingleRsp();
            res = orderSvc.TakeOrder(createOrderReq);
            return Ok(res);
        }

        [HttpPost("Order-Food")]
        public IActionResult OrderFood(OrderFoodReq orderFoodReq)
        {
            var res = new SingleRsp();
            res = orderSvc.OrderFood(orderFoodReq);
            return Ok(res);
        }

    }
}
