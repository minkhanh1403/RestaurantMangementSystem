using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLNH.BLL;
using QLNH.Common.Req;
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
    public class MenuController : ControllerBase
    {
        private MenuSvc menuSvc;
        public MenuController()
        {
            menuSvc = new MenuSvc();
        }

        [HttpGet("get-All-menu")]
        public IActionResult GetMenu()
        {

            var res = new SingleRsp();
            res.Data = menuSvc.All;
            return Ok(res);
        }

        [HttpGet("get-by-id")]
        public IActionResult GetMenuByID(int id)
        {
            var res = new SingleRsp();
            res = menuSvc.Read(id);
            return Ok(res);
        }

        [HttpGet("get-menu-by-name")]
        public IActionResult TakeOder(string name)
        {
            var res = menuSvc.All.Where(i => i.MenuItemName.Contains(name));
            return Ok(res);
        }


        [HttpGet("Available-Food")]
        public IActionResult AvailableFood()
        {
            var res = menuSvc.All.Where(i => i.Quantity > 4);
            return Ok(res);
        }

        [HttpGet("Not-Available-Food")]
        public IActionResult NotAvailableFood()
        {
            var res = menuSvc.All.Where(i => i.Quantity == 0);
            return Ok(res);
        }
        

        [HttpPost("create-menu")]
        public IActionResult CreateMenu([FromBody] MenuReq menuReq )
        {
            if (!AuthRep.IsUserLoggedIn(HttpContext))
            {
                return Unauthorized("User is not logged in.");
            }
            if (!AuthRep.IsUserAuthorized(HttpContext, 1) && !AuthRep.IsUserAuthorized(HttpContext, 3))
            {
                return StatusCode(StatusCodes.Status403Forbidden, "User is not authorized to access this resource.");
            }
         
                var res = menuSvc.CreateMenu(menuReq);
                return Ok(res);
            
          
        }

        [HttpDelete("delete-menu")]
        public IActionResult deleteMenu(int id )
        {
            if (!AuthRep.IsUserLoggedIn(HttpContext))
            {
                return Unauthorized("User is not logged in.");
            }
            if (!AuthRep.IsUserAuthorized(HttpContext, 1) && !AuthRep.IsUserAuthorized(HttpContext, 3))
            {
                return StatusCode(StatusCodes.Status403Forbidden, "User is not authorized to access this resource.");
            }
            var res = menuSvc.DeleteMenu(id);
            return Ok(res);
        }


        [HttpPut("update-product")]
        public IActionResult UpdateProduct([FromBody] MenuReq menuReq)
        {
            if (!AuthRep.IsUserLoggedIn(HttpContext))
            {
                return Unauthorized("User is not logged in.");
            }
            if (!AuthRep.IsUserAuthorized(HttpContext, 1) && !AuthRep.IsUserAuthorized(HttpContext, 3))
            {
                return StatusCode(StatusCodes.Status403Forbidden, "User is not authorized to access this resource.");
            }
            var res = menuSvc.UpdateMenu(menuReq);
            return Ok(res);
        }
    }
}
