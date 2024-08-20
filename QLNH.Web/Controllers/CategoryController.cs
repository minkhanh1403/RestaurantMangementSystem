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
    public class CategoryController : ControllerBase
    {
        private CategorySvc categorySvc;
        public CategoryController()
        {
            categorySvc = new CategorySvc();
        }


        [HttpGet("Get-All-Category")]
        public IActionResult GetAllCategories()
        {
            var res = new SingleRsp();
            res.Data = categorySvc.All;
            return Ok(res);
        }

        [HttpGet("Get-Category-By-Name")]
        public IActionResult GetCategoryByname(string name)
        {
            var res = new SingleRsp();
            var check = categorySvc.All.Where(i => i.CategoryName.Contains(name)).FirstOrDefault();
            if (check != null)
            {
                res.Data = categorySvc.All.Where(i => i.CategoryName.Contains(name));
                return Ok(res);
            }
            else
            {
                res.SetError("Not Available Category");
            }
            return Ok(res);
        }

        [HttpGet("Create-Category")]
        public IActionResult CreateCategory(string name)
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
            res = categorySvc.CreateCategory(name);
            return Ok(res);
        }

        [HttpPut("Update-Category")]
        public IActionResult UpdateCategory(int id, string name)
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
            res = categorySvc.UpdateCategory(id,name);
            return Ok(res);
        }

        [HttpDelete("Delete-Category")]
        public IActionResult DeleteCategory(int id)
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
            res = categorySvc.DeleteCategory(id);
            return Ok(res);
        }
    }
}
