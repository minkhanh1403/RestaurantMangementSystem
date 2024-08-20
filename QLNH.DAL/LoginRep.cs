using QLNH.Common.DAL;
using QLNH.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNH.DAL
{
    public class LoginRep : GenericRep<QuanLyNhaHangContext, User>
    {

        public User Authenticate(string username, string password)
        {
            // Tìm người dùng có username và password khớp
            return All.FirstOrDefault(u => u.Username == username && u.Password == password);
        }

        // Nếu cần, bạn có thể ghi đè phương thức Read để xử lý logic tùy chỉnh
        public override User Read(int id)
        {
            return All.FirstOrDefault(u => u.UserId == id);
        }
    }
}
