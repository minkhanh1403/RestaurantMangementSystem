using QLNH.Common.BLL;
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
    public class CategorySvc : GenericSvc<CategoryRep, Category>
    {
        private CategoryRep categoryRep;
        public CategorySvc()
        {
            categoryRep = new CategoryRep();
        }

        public SingleRsp CreateCategory(string name)
        {
            var res = new SingleRsp();

            Category category = new Category();
            if(name != null)
            {
                category.CategoryName = name;
                categoryRep.CreateCategory(category);
            }
            else
            {
                res.SetError("Wrong Format");
            }

           
            return res;
        }

        public SingleRsp UpdateCategory(int id, string name)
        {
            var res = new SingleRsp();

            Category category = new Category();

            if(categoryRep.All.Where(i => i.CategoryId == id).FirstOrDefault() != null)
            {
                if(name != null)
                {
                    category.CategoryId = id;
                    category.CategoryName = name;
                    categoryRep.UpdateCategory(category);
                }              
                else
                {
                    res.SetError("Wrong format");
                }
            }
            else
            {
                res.SetError("No Available OrderID");
            }

            return res;
        }

        public SingleRsp DeleteCategory(int id)
        {
            var res = new SingleRsp();
            Category category = new Category();
            category = base.All.FirstOrDefault(i => i.CategoryId == id);
            if (category != null)
            {
                res = categoryRep.DeleteCategory(category);
                return res;
            }
            else
            {
                var rsp = new SingleRsp("Khong tim thay");
                return rsp;
            }

        }
    }
}
