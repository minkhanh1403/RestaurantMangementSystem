using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  QLNH.Common.Rep
{
    public class EmployeeReq
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public int RoleId { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
