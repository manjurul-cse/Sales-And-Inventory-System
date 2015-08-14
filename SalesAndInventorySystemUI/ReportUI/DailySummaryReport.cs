using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Windows.Forms;
using SalesAndInventorySystemDataAccess.Gateway;
using SalesAndInventorySystemModel.BLL;
using SalesAndInventorySystemUI.Report;

namespace SalesAndInventorySystemUI.ReportUI
{
    public partial class DailySummaryReport : Form
    {
        public DailySummaryReport()
        {
            InitializeComponent();
            dailyReportViewer.ToolPanelView = ToolPanelViewType.None;
            dailyReportViewer.ShowGroupTreeButton = false;
        }

        private void DailySummaryReport_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            
            this.Location = new Point(0, 0);
            
            Size = Screen.PrimaryScreen.WorkingArea.Size;

            MaximizeBox = false;
            //BarcodeReportViewer.ToolPanelView = ToolPanelViewType.None;
            //BarcodeReportViewer.ShowGroupTreeButton = false;
            //this.reportViewer1.RefreshReport();
            
        }

        private void ShowReportButton_Click(object sender, EventArgs e)
        {
            List<Invoice> invoices = null;
            InvoiceGateway invoiceGateway=new InvoiceGateway();
            DailyReport dailyReport=new DailyReport();
            string fromDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string toDate = dateTimePicker2.Value.ToString("yyyy-MM-dd");

            if (fromDate!=string.Empty && toDate!=String.Empty && Convert.ToDateTime(fromDate)<=Convert.ToDateTime(toDate))
            {
                invoices=invoiceGateway.GetInvoiceWithDate(DateTime.Parse(fromDate), DateTime.Parse( toDate));
                dailyReport.SetDataSource(invoices);
                dailyReportViewer.ReportSource = dailyReport;
            }
        }
    }
}
