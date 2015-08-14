using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using SalesAndInventorySystemModel.BLL;

namespace SalesAndInventorySystemDataAccess.Gateway
{
    public class InvoiceGateway
    {
        public bool AddInvoice(Invoice invoice, List<Product> products )
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    using (SalesAndInventorySystemDataContext dataContext = new SalesAndInventorySystemDataContext())
                    {
                        //Invoice newInvoice=new Invoice(){ InvoiceNo = invoice.InvoiceNo, CostPrice = invoice.CostPrice, Due = invoice.Due, InvoiceDate = invoice.InvoiceDate, TotalPrice = invoice.TotalPrice, vat = invoice.vat};
                        dataContext.Invoices.Add(invoice);
                        dataContext.SaveChanges();

                        if (invoice.InvoiceID>0)
                        {
                            foreach (Product product in products)
                            {
                                SellProduct sellProduct=new SellProduct(){ InvoiceID = invoice.InvoiceID, Price = product.Price, ProductID = product.ProductID, Quantiry = product.Quantity, Size = product.Size};
                                dataContext.SellProducts.Add(sellProduct);
                                dataContext.Database.ExecuteSqlCommand("Update Products set Quantity= Quantity-" + product.Quantity + "where ProductID="+product.ProductID);
                                dataContext.SaveChanges();
                            }
                        }
                    }
                    ts.Complete();
                    return true;
                }
                return false;
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }
        }

        public List<Invoice> GetInvoices()
        {
            List<Invoice> invoices = null;
            try
            {
                using (SalesAndInventorySystemDataContext dataContext = new SalesAndInventorySystemDataContext())
                {
                    invoices = dataContext.Invoices.ToList();
                    return invoices;
                }
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }
        } 

        public List<Invoice> GetInvoiceWithDate(DateTime fromDate, DateTime toDate)
        {
            List<Invoice> invoices = null;
            try
            {
                using (SalesAndInventorySystemDataContext dataContext = new SalesAndInventorySystemDataContext())
                {
                    invoices = dataContext.Invoices.Where(x=>x.InvoiceDate>=fromDate).ToList();
                    return invoices;
                }
            }
            catch (Exception exception)
            {
                
                throw new Exception(exception.Message);
            }
        }
    }

    
}
