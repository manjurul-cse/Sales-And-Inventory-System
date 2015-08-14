using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesAndInventorySystemModel.BLL
{
    public class Invoice
    {
        public int InvoiceID { get; set; }
        public string InvoiceNo { get; set; }

        public DateTime InvoiceDate { get; set; }

        public double CostPrice { get; set; }

        public double vat { get; set; }

        public double TotalPrice { get; set; }

        public double Due { get; set; }

        //public virtual  List<Product> Products { get; set; }


    }
}
