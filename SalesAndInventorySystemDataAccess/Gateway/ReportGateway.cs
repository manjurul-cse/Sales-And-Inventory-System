using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using SalesAndInventorySystemModel.BLL;
using SalesAndInventorySystemUI.ReportClass;

namespace SalesAndInventorySystemDataAccess.Gateway
{
    public class ReportGateway
    {

        public List<TotalProductReport> GetInvoices(DateTime fromdate, DateTime toDate)
        {
            List<TotalProductReport> totalProduct=new List<TotalProductReport>();
           
            try
            {
                using (SalesAndInventorySystemDataContext dataContext = new SalesAndInventorySystemDataContext())
                {
                    List<TotalProductReport> data = (from inv in dataContext.Invoices
                        join sp in dataContext.SellProducts on inv.InvoiceID equals sp.InvoiceID
                        join p in dataContext.Products on sp.ProductID equals p.ProductID
                        where inv.InvoiceDate >= fromdate && inv.InvoiceDate <= toDate
                        select new TotalProductReport()
                        {
                            InvoiceDate = inv.InvoiceDate,
                            InvoiceNo = inv.InvoiceNo,
                            ProductName= p.ProductName,
                            Quantiry= sp.Quantiry,
                            Price= sp.Price
                        }).ToList();
                    

                    
                    
                    return data;
                    
                    
                    


                        //(from ep in dbContext.tbl_EntryPoint
                        // join e in dbContext.tbl_Entry on ep.EID equals e.EID
                        // join t in dbContext.tbl_Title on e.TID equals t.TID
                        // where e.OwnerID == user.UID
                        // select new
                        // {
                        //     UID = e.OwnerID,
                        //     TID = e.TID,
                        //     Title = t.Title,
                        //     EID = e.EID
                        // }).Take(10);
                }
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }
        } 
    }
}
