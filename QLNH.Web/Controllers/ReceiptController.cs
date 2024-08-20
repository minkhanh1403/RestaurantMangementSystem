using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLNH.BLL;
using QLNH.Common.Rsp;
using QLNH.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLNH.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiptController : ControllerBase
    {
        private OrderSvc orderSvc;
        private ReceiptSvc receiptSvc;
        public ReceiptController()
        {
            orderSvc = new OrderSvc();
            receiptSvc = new ReceiptSvc();
        }



        [HttpPost("Create-Receipt")]
        public IActionResult CreateReceipt(int id)
        {
            if (!AuthRep.IsUserLoggedIn(HttpContext))
            {
                return Unauthorized("User is not logged in.");
            }
            if (!AuthRep.IsUserAuthorized(HttpContext, 1) && !AuthRep.IsUserAuthorized(HttpContext, 4))
            {
                return StatusCode(StatusCodes.Status403Forbidden, "User is not authorized to access this resource.");
            }
            var res = new SingleRsp();
            res = receiptSvc.CreateReceipt(id);
            return Ok(res);
        }

        [HttpPost("Pay-Receipt")]
        public IActionResult PayReceipt(int id)
        {
            if (!AuthRep.IsUserLoggedIn(HttpContext))
            {
                return Unauthorized("User is not logged in.");
            }
            if (!AuthRep.IsUserAuthorized(HttpContext, 1) && !AuthRep.IsUserAuthorized(HttpContext, 4))
            {
                return StatusCode(StatusCodes.Status403Forbidden, "User is not authorized to access this resource.");
            }
            var res = new SingleRsp();
            res = receiptSvc.PayReceipt(id);
            return Ok(res);
        }


        [HttpGet("All-Receipt")]
        public IActionResult AllReceipt()
        {
            if (!AuthRep.IsUserLoggedIn(HttpContext))
            {
                return Unauthorized("User is not logged in.");
            }
            if (!AuthRep.IsUserAuthorized(HttpContext, 1) && !AuthRep.IsUserAuthorized(HttpContext, 4))
            {
                return StatusCode(StatusCodes.Status403Forbidden, "User is not authorized to access this resource.");
            }
            var res = new SingleRsp();
            res.Data = receiptSvc.All;
            return Ok(res);
        }
    }
}
