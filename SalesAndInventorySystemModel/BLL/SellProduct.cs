using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesAndInventorySystemModel.BLL
{
    public class SellProduct
    {
        public int ID { get; set; }

        public double Price { get; set; }
       // public double Discount { get; set; }
        public string Size { get; set; }
        public int Quantiry { get; set; }
        public int ProductID { get; set; }

        public int InvoiceID { get; set; }
        public virtual  Invoice  Invoice{ get; set; }
    }
}
