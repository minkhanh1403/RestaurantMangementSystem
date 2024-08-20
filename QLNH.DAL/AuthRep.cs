using Microsoft.AspNetCore.Http;
using QLNH.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNH.DAL
{
    public static class AuthRep
    {
        // Kiểm tra xem người dùng có đăng nhập hay không
        public static bool IsUserLoggedIn(HttpContext httpContext)
        {
            return httpContext.Session.GetString("LoggedInUser") != null;
        }

        // Lấy thông tin người dùng đăng nhập hiện tại
        public static User GetLoggedInUser(HttpContext httpContext, QuanLyNhaHangContext context)
        {
            var userId = httpContext.Session.GetInt32("UserId");
            if (userId.HasValue)
            {
                return context.Users.FirstOrDefault(u => u.UserId == userId.Value);
            }
            return null;
        }

        // Kiểm tra xem người dùng có quyền truy cập theo role yêu cầu
        public static bool IsUserAuthorized(HttpContext httpContext, int requiredRole)
        {
            var userId = httpContext.Session.GetInt32("UserId");
            if (userId == requiredRole)
            {
                return true;
            }
            return false;
        }
    }
}