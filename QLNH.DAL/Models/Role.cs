using System;
using System.Collections.Generic;

#nullable disable

namespace QLNH.DAL.Models
{
    public partial class Role
    {
        public Role()
        {
            Employees = new HashSet<Employee>();
            Users = new HashSet<User>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
