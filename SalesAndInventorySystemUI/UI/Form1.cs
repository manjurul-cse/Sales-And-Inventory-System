using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using iTextSharp.text;
using iTextSharp.text.pdf;
using SalesAndInventorySystemDataAccess.Gateway;
using SalesAndInventorySystemModel.BLL;



namespace SalesAndInventorySystemUI.UI
{
    public partial class Form1 : Form
    {
        CompanyGateway companyGateway=new CompanyGateway();
       
        public Form1()
        {
            InitializeComponent();
            
           
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ReportDocument rd;
                rd = new ReportDocument();
            rd.Load(@"C:\Users\PLABON\Documents\Visual Studio 2013\Projects\SalesAndInventorySystem\SalesAndInventorySystemUI\Report\a.rpt");
            List<PersonType> company = companyGateway.GetCompanies();
            var companyX = company.Select(x => new {x.ID, x.Name});
            rd.SetDataSource(companyX);
            crystalReportViewer1.ReportSource = rd;
            
            crystalReportViewer1.Refresh();
                int a = 10;
            if (File.Exists(@"D:\" + "AAAA" + a  +".pdf"))
                File.Delete(@"D:\" + a++ + ".pdf");
            rd.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"D:\" + a + ".pdf");


            


           

            
                
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        




            //cryRpt.Load("~/Report/CrystalReport1.rpt");
            //crystalReportViewer1.ReportSource = cryRpt;
            //cryRpt.ExportToDisk( ExportTypeFormat.PortableDocFormat , "path to file );
            //crystalReportViewer1.Refresh();
        

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
