using System;
using System.Collections.Generic;

#nullable disable

namespace QLNH.DAL.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }

        public virtual Role Role { get; set; }
    }
}
