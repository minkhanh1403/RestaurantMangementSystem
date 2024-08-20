using System;
using System.Collections.Generic;

#nullable disable

namespace QLNH.DAL.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Orders = new HashSet<Order>();
        }

        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public int RoleId { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
