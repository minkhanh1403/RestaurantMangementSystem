using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLNH.BLL;
using QLNH.Common.Req;
using QLNH.Common.Rsp;
using QLNH.DAL;


namespace QLNH.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KitchenOrderController : ControllerBase
    {
        private readonly KitchenOrderSvc kitchenOrderSvc;

        public KitchenOrderController()
        {
            kitchenOrderSvc =  new KitchenOrderSvc();
        }
        [HttpGet("get-all")]
        public IActionResult getOrderAll()
        {
            var res =kitchenOrderSvc.All;
            return Ok(res);
        }
        [HttpPut("update-statusisProcessing")]
        public IActionResult UpdateStatusOfOrderIsProcessing(int orderId)
        {
            if (!AuthRep.IsUserLoggedIn(HttpContext))
            {
                return Unauthorized("User is not logged in.");
            }
            if (!AuthRep.IsUserAuthorized(HttpContext, 3) && !AuthRep.IsUserAuthorized(HttpContext, 1))
            {
                return StatusCode(StatusCodes.Status403Forbidden, "User is not authorized to access this resource.");
            }
            var res = kitchenOrderSvc.UpdateStatusOfOrderIsProcessing(orderId);
            return Ok(res);
        }
        [HttpPut("update-statusisCooked")]
        public IActionResult UpdateStatusOfOrderIsCooked(int orderId)
        {
            if (!AuthRep.IsUserLoggedIn(HttpContext))
            {
                return Unauthorized("User is not logged in.");
            }
            if (!AuthRep.IsUserAuthorized(HttpContext, 3) && !AuthRep.IsUserAuthorized(HttpContext, 1))
            {
                return StatusCode(StatusCodes.Status403Forbidden, "User is not authorized to access this resource.");
            }
            var res = kitchenOrderSvc.UpdateStatusOfOrderIsCooked(orderId);
            return Ok(res);
        }
        [HttpPut("update-statusisComplete")]
        public IActionResult UpdateStatusOfOrderIsComplete(int orderId)
        {
            if (!AuthRep.IsUserLoggedIn(HttpContext))
            {
                return Unauthorized("User is not logged in.");
            }
            if (!AuthRep.IsUserAuthorized(HttpContext, 3) && !AuthRep.IsUserAuthorized(HttpContext, 1))
            {
                return StatusCode(StatusCodes.Status403Forbidden, "User is not authorized to access this resource.");
            }
            var res = kitchenOrderSvc.UpdateStatusOfOrderIsComplete(orderId);
            return Ok(res);
        }
        [HttpPut("update-status")]
        public IActionResult UpdateOrderStatus(int orderId, string statusName)
        {
            if (!AuthRep.IsUserLoggedIn(HttpContext))
            {
                return Unauthorized("User is not logged in.");
            }
            if (!AuthRep.IsUserAuthorized(HttpContext, 3) && !AuthRep.IsUserAuthorized(HttpContext, 1))
            {
                return StatusCode(StatusCodes.Status403Forbidden, "User is not authorized to access this resource.");
            }
            var res = new SingleRsp();
            res = kitchenOrderSvc.UpdateOrderStatus(orderId,statusName);
            return Ok(res);
        }

    }
}
