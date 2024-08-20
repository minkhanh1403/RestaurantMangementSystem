using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLNH.Common.Rsp;
using QLNH.BLL;
using QLNH.Common.Req;
using QLNH.Common.Rsp;
using System;
using QLNH.DAL;


namespace QLNH.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RevenueStatisticsController : ControllerBase
    {
        private RevenueStatisticsSvc RevenueStatisticsSvc;
        public RevenueStatisticsController() 
        {
            RevenueStatisticsSvc = new RevenueStatisticsSvc();
        }
        [HttpGet("get-day")]
        public IActionResult GetRevenueStatistics(
        [FromQuery] DateTime startDate,
        [FromQuery] DateTime endDate)
        {
            if (!AuthRep.IsUserLoggedIn(HttpContext))
            {
                return Unauthorized("User is not logged in.");
            }
            if (!AuthRep.IsUserAuthorized(HttpContext, 1))
            {
                return StatusCode(StatusCodes.Status403Forbidden, "User is not authorized to access this resource.");
            }
            var res = new SingleRsp();
            res = RevenueStatisticsSvc.GetRevenueStatistics(startDate, endDate);
            return Ok(res);
        }
        [HttpGet("get-month")]
        public IActionResult GetRevenueStatisticsByMonth(
        [FromQuery] DateTime startDate,
        [FromQuery] DateTime endDate)
        {
            if (!AuthRep.IsUserLoggedIn(HttpContext))
            {
                return Unauthorized("User is not logged in.");
            }
            if (!AuthRep.IsUserAuthorized(HttpContext, 1))
            {
                return StatusCode(StatusCodes.Status403Forbidden, "User is not authorized to access this resource.");
            }
            var res = new SingleRsp();
            res = RevenueStatisticsSvc.GetRevenueStatisticsByMonth(startDate, endDate);
            return Ok(res);
        }
        [HttpGet("get-Allday")]
        public IActionResult GetRevenueStatisticsAllday()
        
        {
            if (!AuthRep.IsUserLoggedIn(HttpContext))
            {
                return Unauthorized("User is not logged in.");
            }
            if (!AuthRep.IsUserAuthorized(HttpContext, 1))
            {
                return StatusCode(StatusCodes.Status403Forbidden, "User is not authorized to access this resource.");
            }
            var res = new SingleRsp();
            res = RevenueStatisticsSvc.GetRevenueStatisticsAllday();
            return Ok(res);
        }
        [HttpGet("get-Allmonth")]
        public IActionResult GetRevenueStatisticsAllMonth()

        {
            if (!AuthRep.IsUserLoggedIn(HttpContext))
            {
                return Unauthorized("User is not logged in.");
            }
            if (!AuthRep.IsUserAuthorized(HttpContext, 1))
            {
                return StatusCode(StatusCodes.Status403Forbidden, "User is not authorized to access this resource.");
            }
            var res = new SingleRsp();
            res = RevenueStatisticsSvc.GetRevenueStatisticsAllMonth();
            return Ok(res);
        }
    }
}
