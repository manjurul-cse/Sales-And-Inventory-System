using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesAndInventorySystemUI.ReportClass
{
    public class TotalProductReportAll
    {
        public string InvoiceNo { get; set; }

        public DateTime InvoiceDate { get; set; }

        public string ProductName { set; get; }

        public int Quantiry { get; set; }

        public double Price { get; set; }
    }
}
