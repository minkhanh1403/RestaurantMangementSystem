using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLNH.Common.Rsp;
using QLNH.BLL;
using QLNH.DAL;


namespace QLNH.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemsStatisticsController : ControllerBase
    {
        private MenuItemsStatisticsSvc MenuItemsStatisticsSvc;
        public MenuItemsStatisticsController()
        {
            MenuItemsStatisticsSvc = new MenuItemsStatisticsSvc();
        }
        [HttpGet("get-All")]
        public IActionResult GetMenuItemsStatistics()

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
            res = MenuItemsStatisticsSvc.GetMenuItemsStatistics();
            return Ok(res);
        }

    }
}
