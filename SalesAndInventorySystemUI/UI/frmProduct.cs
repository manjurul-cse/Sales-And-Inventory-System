using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Reflection;
using System.Security.Cryptography;
using System.Windows.Forms;
using iTextSharp.text;
using SalesAndInventorySystemDataAccess.Gateway;
using SalesAndInventorySystemModel.BLL;

namespace SalesAndInventorySystemUI.UI
{
    public partial class frmProduct : Form
    {
        ProductGateway productGateway=new ProductGateway();
        CompanyGateway companyGateway=new CompanyGateway();
        CategoryGateway categoryGateway=new CategoryGateway();
        private Product product = null;
        private int productID = 0;
        private List<String> abcd;
        private PropertyInfo[] propInfos;
        
        public frmProduct()
        {
            InitializeComponent();
            try
            {
                barcodeNoTextBox.Text = Get8Digits();
                LoadComboBox();
                cmbCategory.DisplayMember = "Name";
                cmbCategory.ValueMember = "CategoryID";
                cmbCompany.DisplayMember = "Name";
                cmbCompany.ValueMember = "ID";
                barcodeNoTextBox.Focus();
                ColorCode();
            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void ColorCode()
        {
             abcd=new List<string>();
            abcd.Add("Select Color");
             Type colorType = typeof(System.Drawing.Color);
             propInfos = colorType.GetProperties(BindingFlags.Static | BindingFlags.DeclaredOnly | BindingFlags.Public);
             foreach (PropertyInfo propInfo in propInfos)
             {
                 abcd.Add(propInfo.Name);
             }
            colorComboBox.DataSource = abcd;
        }    
        
        public frmProduct(Product aProduct) :this()
        {
            btnSave.Text = @"Update";
            label6.Text = "Add Quantity";
            label7.Visible = true;
            availableQuantityTextBox.Visible = true;
            FillFieldsWith(aProduct);
            productID = aProduct.ProductID;
        }

        private void FillFieldsWith(Product aProduct)
        {
            barcodeNoTextBox.Text = aProduct.BarCode;
            txtProductName.Text = aProduct.ProductName;
            descriptionTextBox.Text = aProduct.Description;
            priceTextBox.Text = 0.0.ToString();
            quantityTextBox.Text = 0.ToString();
            cmbCompany.SelectedValue = aProduct.Category.PersonType.ID;
            cmbCategory.SelectedValue = aProduct.Category.CategoryID;
            availableQuantityTextBox.Text = aProduct.Quantity.ToString();
            oldPriceTextBox.Text = aProduct.Price.ToString();
        }

        private void LoadComboBox()
        {
            try
            {
                LoadCompanyComboBox();
            }
            catch (Exception exception)
            {
                
                throw new Exception(exception.Message);
            }
        }

        private void LoadCompanyComboBox()
        {
            try
            {
                List<PersonType> companies = companyGateway.GetCompanies();
                companies.Insert(0, new PersonType() { ID = 0, Name = "Select PersonType" });
                cmbCompany.BindingContext = new BindingContext();
                cmbCompany.DataSource = companies;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        

        private void Reset()
        {
            txtProductName.Text = "";
            cmbCompany.SelectedIndex = 0;
            cmbCategory.SelectedIndex = 0;
            btnSave.Enabled = true;
            barcodeNoTextBox.Text = string.Empty;
            barcodeNoTextBox.Focus();
            descriptionTextBox.Text = string.Empty;
            priceTextBox.Text = string.Empty;
            quantityTextBox.Text = string.Empty;
            sizeTextBox.Text=String.Empty;
            colorComboBox.SelectedIndex = 0;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (barcodeNoTextBox.Text == string.Empty)
            {
                MessageBox.Show(@"Please enter Barcode No", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                barcodeNoTextBox.Focus();
                return;
            }
            if (txtProductName.Text == "")
            {
                MessageBox.Show(@"Please enter product name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProductName.Focus();
                return;
            }
            if (cmbCompany.SelectedIndex == 0)
            {
                MessageBox.Show(@"Please select company", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbCompany.Focus();
                return;
            }
            if (cmbCategory.SelectedIndex == 0)
            {
                MessageBox.Show(@"Please select category", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbCategory.Focus();
                return;
            }
            if (priceTextBox.Text == string.Empty)
            {
                MessageBox.Show(@"Please enter price.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                priceTextBox.Focus();
                return;
            }
            if (quantityTextBox.Text == string.Empty)
            {
                MessageBox.Show(@"Please enter quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                quantityTextBox.Focus();
                return;
            }

            if (sizeTextBox.Text==String.Empty)
            {
                MessageBox.Show(@"Please enter size of product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sizeTextBox.Focus();
                return;
            }

            if (colorComboBox.SelectedIndex==0)
            {
                MessageBox.Show(@"Please select color of product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                colorComboBox.Focus();
                return;
            }
            if (buyPriceextBox.Text == String.Empty)
            {
                MessageBox.Show(@"Please enter buy price of product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                buyPriceextBox.Focus();
                return;
            }
            try
            {
                product=new Product()
                {
                    ProductID = productID,
                    BarCode = barcodeNoTextBox.Text,
                    ProductName = txtProductName.Text,
                    Description = descriptionTextBox.Text,
                    InsertDate =DateTime.Parse( DateTime.Now.ToString("dd-MM-yyyy")),
                    UpdateDate = DateTime.Parse(DateTime.Now.ToString("dd-MM-yyyy")),
                    Price = Double.Parse(priceTextBox.Text),
                    Quantity = Convert.ToInt32(quantityTextBox.Text),
                    CategoryID = Convert.ToInt32(cmbCategory.SelectedValue),
                    Color=colorComboBox.SelectedText,
                    Size = sizeTextBox.Text,
                    BuyPrice = Double.Parse(buyPriceextBox.Text),
                    Discount = Double.Parse(discountTextBox.Text),
                    Vat = 0

                };
                if (btnSave.Text == "Save")
                {
                    if (productGateway.CheckBarCode(product))
                    {
                        MessageBox.Show(@"Barcode NO Already Exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtProductName.Focus();
                        return;
                    }

                    if (productGateway.CheckProduct(product))
                    {
                        MessageBox.Show(@"Product Name Already Exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtProductName.Focus();
                        return;
                    }
                
                    if (productGateway.AddProduct(product))
                    {
                        txtProductName.Text = string.Empty;
                        MessageBox.Show(@"Successfully saved.", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Reset();
                        return;
                    }
                }
                else if(btnSave.Text=="Update")
                {
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

        private void btnGetData_Click(object sender, EventArgs e)
        {
            frmProductsRecord frm = new frmProductsRecord();
            frm.Show();
            Close();
        }

        public string Get8Digits()
        {
            try
            {
                var bytes = new byte[4];
                var rng = RandomNumberGenerator.Create();
                rng.GetBytes(bytes);
                uint random = BitConverter.ToUInt32(bytes, 0) % 100000000;
                string barcode = String.Format("{0:D8}", random);
                if (productGateway.CheckNewBarCode(barcode))
                {
                    return barcode;
                }
                else
                {
                    Get8Digits();
                }
                return null;
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }
            

        }
            

        private void cmbCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCompany.SelectedIndex==0)
            {
                List<Category> categories=new List<Category>()
                {
                    new Category(){CategoryID = 0, Name = "Select PersonType"}
                };
                cmbCategory.DataSource = categories;
                cmbCategory.SelectedIndex = 0;
            }
            else
            {
                try
                {
                    int CategoryID = Convert.ToInt32(cmbCompany.SelectedValue);
                    List<Category> categories = categoryGateway.GetCategoriesByID(CategoryID);
                    categories.Insert(0, new Category() { CategoryID = 0, Name = "Select PersonType" });
                    cmbCategory.DataSource = categories;
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            //foreach (PropertyInfo s in propInfos)
            //{
            //    Color aColor=new Color();
            //    aColor=s.
            //    comboBox1.BackColor= col
            //}
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime a=Convert.ToDateTime(DateTime.Now.ToString("dd-MM-yyyy"));
        }

        
    }
}
