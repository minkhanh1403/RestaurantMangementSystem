using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNH.DAL.Models
{
    public class MenuItemsStatistics
    {
        public int MenuItemId { get; set; }
        public string MenuItemName { get; set; }
        public int TotalQuantitySold { get; set; }
        public decimal TotalRevenue { get; set; }

    }
}
