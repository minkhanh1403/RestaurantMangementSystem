using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLNH.BLL;
using QLNH.Common.Rep;
using QLNH.Common.Req;
using QLNH.Common.Rsp;
using QLNH.DAL;



namespace QuanLyNhaHang.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private EmployeesSvc EmployeesSvc;
        public EmployeesController()
        {
            EmployeesSvc = new EmployeesSvc();
        }
        [HttpGet("get-by-id")]
        public IActionResult getEmployeeById(int Id)
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
            res = EmployeesSvc.GetEmployeeById(Id);
            return Ok(res);
        }
        [HttpGet("get-all")]
        public IActionResult getEmployeAll()
        {
            if (!AuthRep.IsUserLoggedIn(HttpContext))
            {
                return Unauthorized("User is not logged in.");
            }
            if (!AuthRep.IsUserAuthorized(HttpContext, 1))
            {
                return StatusCode(StatusCodes.Status403Forbidden, "User is not authorized to access this resource.");
            }
            var res = EmployeesSvc.All;
            return Ok(res);
        }
        [HttpPost("create-employee")]
        public IActionResult CreateEmployee([FromBody] CreateEmployeeReq reqEmployee)
        {
            var res = EmployeesSvc.CreateEmployee(reqEmployee);
            return Ok(res);
        }

        [HttpPut("update-employee")]
        public IActionResult UpdateEmployee([FromBody] EmployeeReq reqEmployee)
        {
            if (!AuthRep.IsUserLoggedIn(HttpContext))
            {
                return Unauthorized("User is not logged in.");
            }
            if (!AuthRep.IsUserAuthorized(HttpContext, 1))
            {
                return StatusCode(StatusCodes.Status403Forbidden, "User is not authorized to access this resource.");
            }
            var res = EmployeesSvc.UpdateEmployee(reqEmployee);
            return Ok(res);
        }
        [HttpDelete("delete-employee")]
        public IActionResult deleteMenu(int id )
        {
            if (!AuthRep.IsUserLoggedIn(HttpContext))
            {
                return Unauthorized("User is not logged in.");
            }
            if (!AuthRep.IsUserAuthorized(HttpContext, 1))
            {
                return StatusCode(StatusCodes.Status403Forbidden, "User is not authorized to access this resource.");
            }
            var res = EmployeesSvc.DeleteEmployee(id);
            return Ok(res);
        }
        [HttpPost("search-employee")]
        public IActionResult SearchEmployee([FromBody] SearchEmployeeReq searchEmployeeReq)
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
            var employees = EmployeesSvc.SearchEmployee(searchEmployeeReq);
            res.Data = employees;
            return Ok(res);
        }

    }
}
