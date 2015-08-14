using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesAndInventorySystemModel.BLL
{
    public class Product
    {
        public int ProductID { set; get; }

        public string ProductName { set; get; }

        //public string CategoryName { set; get; }

        //public string CompanyName { set; get; }

        public string Description { set; get; }

        public DateTime InsertDate { set; get; }

        public DateTime UpdateDate { set; get; }

        public double BuyPrice { get; set; }

        public double Discount { get; set; }

        public double Vat { get; set; }

        public double Price { set; get; }

        public int Quantity { set; get; }

        public int CategoryID { get; set; }

        public string BarCode { get; set; }

        public string Color { get; set; }

        public string Size { get; set; }

        public virtual  Category Category { get; set; }

        public virtual Invoice Invoice { get; set; }

    }
}
