using QLNH.DAL;
using System;
using System.Collections.Generic; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLNH.Common.BLL;
using QLNH.DAL.Models;
using QLNH.Common.Rsp;
using QLNH.Common.Req;

namespace QLNH.BLL
{
    public class MenuSvc : GenericSvc<MenuRep,MenuItem>
    {
        private MenuRep menuRep;
        private CategoryRep categoryRep;
        public MenuSvc()
        {
            menuRep = new MenuRep();
            categoryRep = new CategoryRep();
        }
        #region -- Overrides --
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            res.Data = _rep.Read(id); //_rep: đại diện cho database 
            return res;
        }
        #endregion


        #region -- Methods --
     

        public SingleRsp CreateMenu(MenuReq menuReq)
        {
            var res = new SingleRsp();
            if (menuReq.MenuItemName != null && menuReq.Price > 0 && categoryRep.All.Where(i => i.CategoryId == menuReq.CategoryId).FirstOrDefault() != null)
            {
                MenuItem menuItem = new MenuItem();
                menuItem.MenuItemName = menuReq.MenuItemName;
                menuItem.Price = menuReq.Price;
                menuItem.CategoryId = menuReq.CategoryId;
                res = menuRep.CreateMenu(menuItem);
            }
            else
            {
                res.SetError("Wrong Format");
            }
            return res;
        }

        public SingleRsp DeleteMenu(int id)
        {
            var res = new SingleRsp();
            MenuItem menuItem = new MenuItem();
            menuItem = base.All.FirstOrDefault(i => i.MenuItemId == id);
            if(menuItem != null)
            {
                res = menuRep.DeleteMenu(menuItem);
                return res;
            }         
            else
            {
                var rsp = new SingleRsp("Not Found Menu Items");
                return rsp;
            }
            
        }

        public SingleRsp UpdateMenu(MenuReq menuReq)
        {
            var res = new SingleRsp();
            MenuItem menu = new MenuItem();
            //menu = base.All.FirstOrDefault(i=>i.MenuItemId == menuReq.MenuItemName)_
            if(menuRep.All.Where(i => i.MenuItemName.Contains(menuReq.MenuItemName)).FirstOrDefault() != null)
            {
                if (menuReq.MenuItemName != null && menuReq.Price > 0 && categoryRep.All.Where(i => i.CategoryId == menuReq.CategoryId).FirstOrDefault() != null)
                {
                    menu.MenuItemName = menuReq.MenuItemName;
                    menu.Price = menuReq.Price;
                    menu.CategoryId = menuReq.CategoryId;
                    res = menuRep.UpdateMenu(menu);
                }
                else
                {
                    res.SetError("Wrong Format");
                }
            }
            else
            {
                res.SetError("Not Available Menu Item");
            }
         
            return res;
        }
        #endregion
    }
}
