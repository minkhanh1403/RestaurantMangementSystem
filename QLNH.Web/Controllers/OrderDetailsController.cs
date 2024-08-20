using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLNH.BLL;
using QLNH.Common.Rsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLNH.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {

        private OrderDetailSvc orderDetailSvc;

        public OrderDetailsController()
        {
            orderDetailSvc = new OrderDetailSvc();
        }

        [HttpGet("All-Order-Details")]
        public IActionResult AllOrderDetails()
        {
            var res = new SingleRsp();
            res.Data = orderDetailSvc.All;
            return Ok(res);
        }

        [HttpGet("Get-Status-Order")]
        public IActionResult GetStatusOrder(int id)
        {
            var res = new SingleRsp();
            res.Data = orderDetailSvc.CheckOrderStatus(id);
            return Ok(res);
        }
    }
}
