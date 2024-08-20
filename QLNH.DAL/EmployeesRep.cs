
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using QLNH.DAL.Models;
using QLNH.Common.DAL;
using QLNH.Common.Rsp;

namespace QLNH.DAL
{
    public class EmployeesRep : GenericRep<QuanLyNhaHangContext, Employee>
    {
        public EmployeesRep()
        {

        }
        //sửa getbyid
        public SingleRsp GetEmployeeById(int id)
        {
            var res = new SingleRsp();

            using (var context = new QuanLyNhaHangContext())
            {
                var employee = context.Employees.Find(id);
                try
                {
                    if (employee == null)
                    {
                        res.SetError("Nhân viên không được tìm thấy"); // Thông báo lỗi nếu không tìm thấy nhân viên
                    }
                    else
                    {
                        res.Data = employee;// Lưu trữ thông tin nhân viên vào thuộc tính Data
                    }
                }

                catch (Exception ex)
                {

                    res.SetError(ex.StackTrace);
                }
            }

            return res;
        }
        public int Remove(int id)
        {
            var m = base.All.First(i => i.EmployeeId == id);
            m = base.Delete(m);
            return m.EmployeeId;
        }


        public SingleRsp DeleteEmployee(Employee employee)
        {
            var res = new SingleRsp();
            using (var context = new QuanLyNhaHangContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Employees.Remove(employee);
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }
        #region -- Methods --

        public SingleRsp CreateEmployee(Employee employee)
        {
            var res = new SingleRsp();
            using (var context = new QuanLyNhaHangContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Employees.Add(employee);
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }
        public SingleRsp UpdateEmployee(Employee employee)
        {
            var res = new SingleRsp();
            using (var context = new QuanLyNhaHangContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Employees.Update(employee);
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }

        #endregion
    }
}
