using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLNH.BLL;
using QLNH.Common.Req;
using QLNH.DAL.Models;

namespace QLNH.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginSvc loginSvc;

        public LoginController()
        {
            loginSvc = new LoginSvc();
        }

        [HttpPost("auth")]
        public IActionResult Login([FromBody] LoginReq loginReq)
        {
            var res = loginSvc.Authenticate(loginReq.Username, loginReq.Password);

            if (res.Success)
            {
                var user = (User)res.Data;
                HttpContext.Session.SetInt32("UserId", user.UserId);
                HttpContext.Session.SetString("LoggedInUser", user.Username);
                HttpContext.Session.SetInt32("UserRole", user.RoleId);
                

                return Ok(res);
            }
            else
            {
                return BadRequest(res);
            }
        }
    }
}
