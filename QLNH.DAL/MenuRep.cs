using System;
using QLNH.Common.DAL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLNH.DAL.Models;
using QLNH.Common.Rsp;
using QLNH.Common.Req;

namespace QLNH.DAL
{
    public class MenuRep : GenericRep<QuanLyNhaHangContext,MenuItem>
    {
        public MenuRep()
        {

        }
      
        #region -- Overrides --
        public override MenuItem Read(int id)
        {
            var res = All.FirstOrDefault(c=>c.MenuItemId == id);
            return res;
        }



        #endregion

        #region -- Methods --

        public SingleRsp DeleteMenu(MenuItem menuItem)
        {
            var res = new SingleRsp();
            using (var context = new QuanLyNhaHangContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.MenuItems.Remove(menuItem);
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

        public SingleRsp CreateMenu(MenuItem menuItem)
        {
            var res = new SingleRsp();
            using (var context = new QuanLyNhaHangContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.MenuItems.Add(menuItem);
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

        public SingleRsp UpdateMenu(MenuItem menuItem)
        {
            var res = new SingleRsp();
            using (var context = new QuanLyNhaHangContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.MenuItems.Update(menuItem);
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


        public List<string> GetFoodName(List<int> menuid)
        {
            using (var context = new QuanLyNhaHangContext())
            {
                List<string> FoodName = context.MenuItems.Where(i => menuid.Contains(i.MenuItemId)).Select(i => i.MenuItemName).ToList();

                //List<int> MatchedFoodName = menuid.Intersect(FoodName).ToList();
                return FoodName;
            }          
        }
        #endregion
    }
}
