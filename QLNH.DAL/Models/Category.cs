using System;
using System.Collections.Generic;

#nullable disable

namespace QLNH.DAL.Models
{
    public partial class Category
    {
        public Category()
        {
            MenuItems = new HashSet<MenuItem>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<MenuItem> MenuItems { get; set; }
    }
}
