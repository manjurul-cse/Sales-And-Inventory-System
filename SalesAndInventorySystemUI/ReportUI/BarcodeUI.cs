using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using SalesAndInventorySystemDataAccess.Gateway;
using SalesAndInventorySystemModel.BLL;
using SalesAndInventorySystemUI.Report;
using SalesAndInventorySystemUI.ReportClass;

namespace SalesAndInventorySystemUI.ReportUI
{
    
    public partial class BarcodeUI : Form
    {
        ReportDocument report=new ReportDocument();
        ProductGateway productGateway = new ProductGateway();
        CategoryGateway categoryGateway=new CategoryGateway();
        public BarcodeUI()
        {
            InitializeComponent();
            BarcodeReportViewer.ToolPanelView = ToolPanelViewType.None;
            BarcodeReportViewer.ShowGroupTreeButton = false;
        }

        

        private void buttonShowBarcode_Click(object sender, EventArgs e)
        {
            try
            {
                string bCode = textBox1.Text.Trim();
                int no = Convert.ToInt32(textBox2.Text.Trim());
                if (bCode == "") return;
                if (no < 0) return;
                BarcodeReport barcodeReport = new BarcodeReport();
                List<ReportProducts> productses=new List<ReportProducts>();
                ReportProducts aProducts = GetProduct(bCode);
                for (int i = 0; i < no; i++)
                {
                   productses.Add(aProducts);
                }
                barcodeReport.SetDataSource(productses);
                BarcodeReportViewer.ReportSource = barcodeReport;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            
        }

        private ReportProducts GetProduct(string bCode)
        {
            
            try
            {
                Product aProduct = productGateway.GetDataBarCode(bCode);
                Category aCategory = categoryGateway.GetCategoryByID(aProduct.CategoryID);
                ReportProducts product = new ReportProducts(){BarCode = aProduct.BarCode, Price = aProduct.Price, Category = aCategory.Name, Size = aProduct.Size, ProductName = aProduct.ProductName};
                return product;
            }
            catch (Exception exception)
            {
                
                throw new Exception(exception.Message);
            }
        }

        private List<ReportProducts> AllProducts()
        {
            List<ReportProducts> products = new List<ReportProducts>();
            try
            {
                
                List<Product> Allproduct = productGateway.GetAllProducts();
                    foreach (Product product in Allproduct)
                    {
                        Category category = categoryGateway.GetCategoryByID(product.CategoryID);
                        ReportProducts newProduct=new ReportProducts(){ BarCode = product.BarCode, Price = product.Price, ProductName = product.ProductName, Size = product.Size, Category = category.Name};

                        products.Add(newProduct);
                    }
               
                return products;
            }
            catch (Exception exception)
            {
                
                throw new Exception(exception.Message);
            }
        }

        private void buttonShowAllBarcode_Click(object sender, EventArgs e)
        {
            try
            {
                BarcodeReport barcodeReport = new BarcodeReport();

                List<ReportProducts> products = AllProducts();
                if (products.Count > 0)
                {
                    barcodeReport.SetDataSource(products);
                    BarcodeReportViewer.ReportSource = barcodeReport;
                }
            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message);
            }
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BarcodeUI_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
           
            this.Location = new Point(0, 0);
            
            Size = Screen.PrimaryScreen.WorkingArea.Size;

            MaximizeBox = false;
        }
    }
}
