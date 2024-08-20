using QLNH.Common.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLNH.DAL.Models;
using QLNH.Common.Rsp;

namespace QLNH.DAL
{
    public class CategoryRep : GenericRep<QuanLyNhaHangContext, Category>
    {
        public SingleRsp CreateCategory(Category category)
        {
            var res = new SingleRsp();
            using (var context = new QuanLyNhaHangContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Categories.Add(category);
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

        public SingleRsp UpdateCategory(Category category)
        {
            var res = new SingleRsp();
            using (var context = new QuanLyNhaHangContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Categories.Update(category);
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

        public SingleRsp DeleteCategory(Category category)
        {
            var res = new SingleRsp();
            using (var context = new QuanLyNhaHangContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Categories.Remove(category);
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
    }
    }
