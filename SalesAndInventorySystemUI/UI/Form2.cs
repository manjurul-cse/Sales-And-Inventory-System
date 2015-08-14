using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SalesAndInventorySystemDataAccess.Gateway;
using SalesAndInventorySystemModel.BLL;

namespace SalesAndInventorySystemUI.UI
{
    public partial class Form2 : Form
    {
        private PrintDocument docToPrint = new PrintDocument();  
        ProductGateway productGateway=new ProductGateway();
       // private PrintPreviewControl ppc;
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
           PrintDocument document = new PrintDocument();  
            document.PrintPage +=document_PrintPage;  
 
            //PrintPreviewDialog ppd = new PrintPreviewDialog();  
            //ppd.Document = document;  
            //ppd.ShowDialog();  
        }

        void document_PrintPage(object sender, PrintPageEventArgs e)  

        {  
            string text=GetProduct();
            //e.Graphics.DrawString(text, new Font("Arial", 10), new SolidBrush(Color.Black), new PointF(10, 10));  
        }  



        private void PrintPage(object sender, PrintPageEventArgs e)
        {

            string text=GetProduct();
            e.Graphics.DrawString(text, new Font("Georgia", 35, FontStyle.Bold),
                Brushes.Black, 10, 10);
        }

        private string GetProduct()
        {
            List<Product> products = productGateway.GetAllProducts();
            int serialNo = 1;
            string text = "No\tProduct Name\tQuantiry\tPrice\n ";
            foreach (Product product in products)
            {
                text += serialNo + "\t" + product.ProductName + "\t" + product.Quantity + "\t" + product.Price + "\n";
                serialNo++;
            }
            return text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
        //    ppc = new PrintPreviewControl();
        //    ppc.Name = "PrintPreviewControl1";
        //    ppc.Dock = DockStyle.Fill;
        //    ppc.Location = new Point(80,88);
        //    ppc.Document = docToPrint;
        //    ppc.Zoom = .50;
        //    ppc.Document.DocumentName = "D:\\";
        //    ppc.UseAntiAlias = true;

        //    // Add PrintPreviewControl to Form
        //    Controls.Add(this.ppc);           
        }

    }

}
