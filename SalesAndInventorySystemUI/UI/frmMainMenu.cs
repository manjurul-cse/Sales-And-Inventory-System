using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using SalesAndInventorySystemDataAccess.Gateway;
using SalesAndInventorySystemModel.BLL;
using SalesAndInventorySystemUI.ReportUI;

namespace SalesAndInventorySystemUI.UI
{
    public partial class frmMainMenu : Form
    {
        ProductGateway productGateWay = new ProductGateway();
        CategoryGateway categoryGateway = new CategoryGateway();
        CompanyGateway companyGateway = new CompanyGateway();
        private List<Product> products = null; 
        public frmMainMenu()
        {
            InitializeComponent();
            GetData();
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmCustomers frm = new frmCustomers();
            //frm.Show();
        }

        private void registrationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //frmUserRegistration frm = new frmUserRegistration();
            //frm.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmAbout frm = new frmAbout();
            //frm.Show();
        }

        private void registrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmUserRegistration frm = new frmUserRegistration();
            //frm.Show();
        }

        private void profileEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmCustomers frm = new frmCustomers();
            //frm.Show();
        }

        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmProduct frm = new frmProduct();
            frm.Show();
        }

        private void notepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Notepad.exe");
        }

        private void calculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Calc.exe");
        }

        private void wordpadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Wordpad.exe");
        }

        private void taskManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("TaskMgr.exe");
        }

        private void mSWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Winword.exe");
        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {

            
            panel1.Visible = false;
            panel2.Visible = false;


           
            frmCategory frm = new frmCategory(){MdiParent = this};
            frm.Show();
        }

        private void companyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            frmPersonType frm = new frmPersonType(){MdiParent = this};
            panel1.Visible = false;
            panel2.Visible = false;
            
           
            frm.Show();
        }

        private void customersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmCustomersRecord frm = new frmCustomersRecord();
            //frm.Show();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            Application.Restart();
            
        }

        private void frmMainMenu_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            resultListView.Width = w - 40;
            Size = Screen.PrimaryScreen.WorkingArea.Size;
            
            MaximizeBox = false;
            Timer timer = new Timer();
            timer.Interval = (10 * 1000);
            timer.Tick += new EventHandler(timer_Tick);
            if (txtProductName.Text.Count() > 0) timer1.Stop();
            else timer.Start();

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            GetData();
        }


        public void GetData()
        {
            resultListView.Items.Clear();
            try
            {
                products = productGateWay.GetAllProducts();
                if (products.Count > 0)
                {
                    int serialNo = 0;
                    foreach (Product product in products)
                    {
                        product.Category = categoryGateway.GetCategoryByID(product.CategoryID);
                        product.Category.PersonType = companyGateway.GetCompanies(product.Category.CompanyID);
                        ListViewItem item = new ListViewItem(product.ProductName);
                        item.Tag = product;
                        //item.SubItems.Add(product.ProductName);
                        item.SubItems.Add(product.Category.Name);
                        item.SubItems.Add(product.Category.PersonType.Name);
                        item.SubItems.Add(product.BuyPrice.ToString());
                        item.SubItems.Add((product.Price).ToString());
                        item.SubItems.Add(product.Size.ToString());
                        item.SubItems.Add(product.Quantity.ToString());
                        item.SubItems.Add(product.Discount.ToString());
                        item.SubItems.Add(product.BarCode);


                        resultListView.Items.Add(item);
                        serialNo++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ToolStripStatusLabel4.Text = System.DateTime.Now.ToString();
        }

        private void productsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmProduct frm = new frmProduct();
            frm.Show();
        }

        private void productsToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmProductsRecord frm = new frmProductsRecord();
            frm.Show();
        }
        

        private void InvoiceToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmInvoice invoice=new frmInvoice();
            invoice.Show();
        }

        private void stockToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //frmStockRecord frm = new frmStockRecord();
            //frm.Show();
        }

        private void invoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInvoice invoice=new frmInvoice();
            invoice.Show();

        }

        private void salesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //SalesAndInventorySystem.frmInvoice frm = new SalesAndInventorySystem.frmInvoice();
            //frm.label6.Text = lblUser.Text;
            //frm.Show();
        }

        private void salesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //frmSalesRecord frm = new frmSalesRecord();
            //frm.Show();
        }

        private void loginDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmLoginDetails frm = new frmLoginDetails();
            //frm.Show();
        }

        

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            BarcodeUI reader=new BarcodeUI();
            reader.Show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {

        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {
            
            List<Product> searchProduct = null;
            string searchString = txtProductName.Text;
            if (searchString == string.Empty)
            {
                searchProduct = products;
            }
            else
            {
                searchProduct = products.Where(x => x.ProductName.ToUpper(CultureInfo.InvariantCulture).Contains(searchString.ToUpper(CultureInfo.InvariantCulture)) ||
                    x.Category.Name.ToUpper(CultureInfo.InvariantCulture).Contains(searchString.ToUpper(CultureInfo.InvariantCulture)) ||
                    x.Category.PersonType.Name.ToUpper(CultureInfo.InvariantCulture).Contains(searchString.ToUpper(CultureInfo.InvariantCulture)) ||
                    x.BarCode.Equals(searchString)).Select(x => x).ToList();
            }
            try
            {
                resultListView.Items.Clear();
                if (searchProduct.Count > 0)
                {
                    int serialNo = 0;
                    foreach (Product product in searchProduct)
                    {
                        product.Category = categoryGateway.GetCategoryByID(product.CategoryID);
                        product.Category.PersonType = companyGateway.GetCompanies(product.Category.CompanyID);
                        ListViewItem item = new ListViewItem(product.ProductName);
                        item.Tag = product;
                        //item.SubItems.Add(product.ProductName);
                        item.SubItems.Add(product.Category.Name);
                        item.SubItems.Add(product.Category.PersonType.Name);
                        item.SubItems.Add(product.BuyPrice.ToString());
                        item.SubItems.Add((product.Price).ToString());
                        item.SubItems.Add(product.Size);
                        item.SubItems.Add(product.Quantity.ToString());
                        item.SubItems.Add(product.Discount.ToString());
                        item.SubItems.Add(product.BarCode);
                        resultListView.Items.Add(item);
                        serialNo++;
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        

        

      
    }
}
