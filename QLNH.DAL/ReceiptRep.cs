using QLNH.Common.DAL;
using QLNH.Common.Rsp;
using QLNH.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNH.DAL
{
    public class ReceiptRep : GenericRep<QuanLyNhaHangContext, Receipt>
    {
        public SingleRsp CreateReceipt(Receipt receipt)
        {
            var res = new SingleRsp();
            using (var context = new QuanLyNhaHangContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Receipts.Add(receipt);
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
