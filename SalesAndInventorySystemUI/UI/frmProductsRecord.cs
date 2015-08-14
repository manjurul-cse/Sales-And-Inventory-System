using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using SalesAndInventorySystemDataAccess.Gateway;
using SalesAndInventorySystemModel.BLL;

namespace SalesAndInventorySystemUI.UI
{
    public partial class frmProductsRecord : Form
    {
        ProductGateway productGateWay=new ProductGateway();
        CategoryGateway categoryGateway=new CategoryGateway();
        CompanyGateway companyGateway=new CompanyGateway();
        private List<Product> products = null;

        public delegate void DataSender(Product aNewProduct);
        public event DataSender dataSender;

        public frmProductsRecord()
        {
            InitializeComponent();
        }
        public void GetData()
        {
            resultListView.Items.Clear();
            try
            {
                products = productGateWay.GetAllProducts();
                if (products.Count>0)
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
                        item.SubItems.Add((product.BuyPrice).ToString());
                        item.SubItems.Add(product.Price.ToString());
                        item.SubItems.Add(product.Quantity.ToString());
                        item.SubItems.Add(product.Discount.ToString() + "%");
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

        
        private void frmProductsRecord_Load(object sender, EventArgs e)
        {
            GetData();
        }

       


        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            deleteToolStripMenuItem.Enabled = (resultListView.Items.Count > 0);
            updateToolStripMenuItem.Enabled = (resultListView.Items.Count > 0);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Product selectProduct = GetSelectedCategory();
            int selectedIndex = resultListView.SelectedIndices[0];
            DialogResult result = MessageBox.Show("You are about to delete " + selectProduct.ProductName + " \nIs that alright?", "Delete Employee", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    productGateWay.DeleteProduct(selectProduct);
                    resultListView.Items.RemoveAt(selectedIndex);
                }
                catch (Exception exception)
                {

                    MessageBox.Show(exception.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private Product GetSelectedCategory()
        {
            int index = resultListView.SelectedIndices[0];
            ListViewItem item = resultListView.Items[index];
            return (Product)item.Tag;
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Product selectProduct = GetSelectedCategory();
            frmProduct frmProduct=new frmProduct(selectProduct);
            frmProduct.ShowDialog();
            GetData();
            resultListView.HideSelection = false;



        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            List<Product> searchProduct = null;
            string searchString = nameTextBox.Text;
            if (searchString == string.Empty)
            {
                searchProduct = products;
            }
            else
            {
                searchProduct = products.Where(x => x.ProductName.ToUpper(CultureInfo.InvariantCulture).Contains(searchString.ToUpper(CultureInfo.InvariantCulture)) ||
                    x.Category.Name.ToUpper(CultureInfo.InvariantCulture).Contains(searchString.ToUpper(CultureInfo.InvariantCulture))||
                    x.Category.PersonType.Name.ToUpper(CultureInfo.InvariantCulture).Contains(searchString.ToUpper(CultureInfo.InvariantCulture))||
                    x.BarCode.Contains(searchString)).Select(x => x).ToList();
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
                        item.SubItems.Add((product.BuyPrice).ToString());
                        item.SubItems.Add(product.Price.ToString());
                        item.SubItems.Add(product.Quantity.ToString());
                        item.SubItems.Add(product.Discount.ToString()+ "%");
                        item.SubItems.Add(product.BarCode);


                        resultListView.Items.Add(item);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void resultListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Product selectProduct = GetSelectedCategory();
            frmInvoice frmInvoice=new frmInvoice();
            if (CheckOpened("frmInvoice"))
            {
                dataSender(selectProduct);
                Close();
            }
            
        }

        private bool CheckOpened(string name)
        {
            FormCollection fc = Application.OpenForms;
            foreach (Form frm in fc)
            {
                if (frm.Name == name)
                {
                    return true;
                }
            }
            return false;
        }



        private void frm2_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }


        private Product GetSelectedProduct()
        {
            int index = resultListView.SelectedIndices[0];
            ListViewItem item = resultListView.Items[index];
            return (Product)item.Tag;

        }

        private void frmProductsRecord_FormClosed(object sender, FormClosedEventArgs e)
        {
            //frmProduct frmProduct=new frmProduct();
            //frmProduct.Show();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Product selectProduct = GetSelectedCategory();
            frmInvoice frmInvoice = new frmInvoice(selectProduct);
            frmInvoice.FormClosed += new FormClosedEventHandler(frm2_FormClosed);
            frmInvoice.Show();
            Hide();
        }

        
    }
}
