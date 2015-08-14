using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SalesAndInventorySystemDataAccess.Gateway;
using SalesAndInventorySystemUI.Report;
using SalesAndInventorySystemUI.ReportClass;

namespace SalesAndInventorySystemUI.ReportUI
{
    public partial class TotalReport : Form
    {
        InvoiceGateway invoiceGateway=new InvoiceGateway();
        SellProductGateway sellProductGateway=new SellProductGateway();
        ProductGateway productGateway=new ProductGateway();

        public TotalReport()
        {
            InitializeComponent();
        }

        

        private void ShowReportButton_Click_1(object sender, EventArgs e)
        {
            string fromDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string toDate = dateTimePicker2.Value.ToString("yyyy-MM-dd");
            ReportGateway reportGateway=new ReportGateway();
            TotalReports totalReports=new TotalReports();
            List<TotalProductReport> aReport=reportGateway.GetInvoices(DateTime.Parse(fromDate), DateTime.Parse(toDate));
            totalReports.SetDataSource(aReport);
            crystalReportViewer1.ReportSource = totalReports;


        }


        
        
        private void TotalReport_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            this.Location = new Point(0, 0);

            Size = Screen.PrimaryScreen.WorkingArea.Size;

            MaximizeBox = false;
        }

        
    }
}
