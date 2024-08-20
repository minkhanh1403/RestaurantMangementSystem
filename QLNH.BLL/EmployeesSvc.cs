using QLNH.Common.BLL;
using QLNH.Common.Rep;
using QLNH.Common.Req;
using QLNH.Common.Rsp;
using QLNH.DAL;
using QLNH.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNH.BLL
{
    public class EmployeesSvc : GenericSvc<EmployeesRep, Employee>
    {
        EmployeesRep req = new EmployeesRep();
        private EmployeesRep employeesRep;
        public EmployeesSvc()
        {
            employeesRep = new EmployeesRep();
        }
        public SingleRsp GetEmployeeById(int id)
        {
            var res = new SingleRsp();
            res.Data = _rep.GetEmployeeById(id);
            return res;
        }
        public override SingleRsp Update(Employee m)
        {
            var res = new SingleRsp();

            var m1 = m.RoleId > 0 ? _rep.Read(m.EmployeeId) : _rep.Read(m.EmployeeId);
            if (m1 == null)
            {
                res.SetError("EZ103", "No data.");
            }
            else
            {
                res = base.Update(m);
                res.Data = m;
            }

            return res;
        }


        #region -- Methods --
        public SingleRsp CreateEmployee(CreateEmployeeReq employeeReq)
        {
            var res = new SingleRsp();
            Employee employee = new Employee();
            employee.FirstName = employeeReq.FirstName;
            employee.RoleId = employeeReq.RoleId;
            employee.LastName = employeeReq.LastName;
            employee.BirthDate = employeeReq.BirthDate;
            res = req.CreateEmployee(employee);
            return res;
        }
        public SingleRsp UpdateEmployee(EmployeeReq employeeReq)
        {
            var res = new SingleRsp();
            Employee employee = new Employee();
            var check = base.All.Where(i => i.EmployeeId == employeeReq.EmployeeId).FirstOrDefault();
            if (check != null)
            {
                employee.EmployeeId = employeeReq.EmployeeId;
                employee.FirstName = employeeReq.FirstName;
                employee.RoleId = employeeReq.RoleId;
                employee.LastName = employeeReq.LastName;
                employee.BirthDate = employeeReq.BirthDate;
                res = req.UpdateEmployee(employee);
            }
            else
            {
                res.SetError("Cannot Find Employee");
            }
                return res;
        }
        public SingleRsp DeleteEmployee(int id)
        {
            var res = new SingleRsp();
            Employee employee = new Employee();
            var check = base.All.Where(i => i.EmployeeId == id).FirstOrDefault();
            if(check != null)
             {
                employee = base.All.FirstOrDefault(i => i.EmployeeId == id);
                res = employeesRep.DeleteEmployee(employee);
            }
            else
            {
                res.SetError("Cannot Find Employee");
            }
              
            return res;

        }
        //thêm phân trang
        public object SearchEmployee(SearchEmployeeReq searchEmployeeReq)
        {

            var employees = All.Where(x => x.FirstName.Contains(searchEmployeeReq.Keyword));
            var offset = (searchEmployeeReq.Page - 1) * searchEmployeeReq.Size;
            var total = employees.Count();
            int totalPage = (total % searchEmployeeReq.Size) == 0 ? (int)(total / searchEmployeeReq.Size) :
                (int)(1 + (total / searchEmployeeReq.Size));
            var data = employees.OrderBy(x => x.EmployeeId).Skip(offset).Take(searchEmployeeReq.Size).ToList();
            var res = new
            {
                Data = data,
                TotalRecord = total,
                TotalPages = totalPage,
                Page = searchEmployeeReq.Page,
                Size = searchEmployeeReq.Size

            };

            return res;
        }
        #endregion

    }
}
