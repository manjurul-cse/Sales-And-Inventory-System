using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using SalesAndInventorySystemDataAccess.Gateway;
using SalesAndInventorySystemModel.BLL;


namespace SalesAndInventorySystemUI.UI
{
    public partial class frmCategory : Form
    {
        
        private int categoryID;
        private Category category = null;
        CategoryGateway categoryGateway=new CategoryGateway();
        CompanyGateway companyGateway=new CompanyGateway();




        public frmCategory()
        {
            InitializeComponent();
            LoadComboBox();
            companyNameComboBox.DisplayMember = "Name";
            companyNameComboBox.ValueMember = "ID";
            
        }

        private List<PersonType> GetCompany()
        {
            try
            {
                return companyGateway.GetCompanies();
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }

        }

        public frmCategory(Category aCategory) : this()
        {
            try
            {
                btnSave.Text = @"Update";
                FillFieldsWith(aCategory);
                categoryID = aCategory.CategoryID;
            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message);
            }
            
            
        }

        private void FillFieldsWith(Category aCategory)
        {
            txtCategoryName.Text = aCategory.Name;
            companyNameComboBox.SelectedValue = aCategory.CompanyID;
        }
        

        private void btnSave_Click(object sender, EventArgs e)
        {
            category=new Category();
            category.CategoryID = categoryID;
            category.Name = txtCategoryName.Text;
            category.CompanyID = Convert.ToInt32(companyNameComboBox.SelectedValue);
            if (txtCategoryName.Text == "")
            {
                MessageBox.Show("Please enter Category name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCategoryName.Focus();
                return;
            }

            if (companyNameComboBox.SelectedIndex==0)
            {
                MessageBox.Show("Please Select  Category name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                companyNameComboBox.Focus();
                return;
            }
            try
            {
                if (categoryGateway.CheckCategory(category))
                {
                    MessageBox.Show(@"PersonType Name Already Exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCategoryName.Focus();
                    return;
                }
                else if (btnSave.Text == @"Save")
                {
                    if (categoryGateway.AddCategory(category))
                    {
                        txtCategoryName.Text = string.Empty;
                        companyNameComboBox.SelectedIndex = 0;
                        MessageBox.Show(@"Successfully saved.", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else if (btnSave.Text == @"Update")
                {
                    if (categoryGateway.UpdateCategory(category))
                    {
                        txtCategoryName.Text = string.Empty;
                        MessageBox.Show(@"Successfully updated.", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show(@"Problem to save PersonType....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCategoryName.Text = "";
                    txtCategoryName.Focus();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        private void Reset()
        {
            txtCategoryName.Text = "";

            companyNameComboBox.SelectedIndex = 0;
            txtCategoryName.Focus();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            frmMainMenu myForm = (frmMainMenu)Application.OpenForms["frmMainMenu"];
            frmCategoryRecord frm = new frmCategoryRecord(){MdiParent = myForm};
            frm.Show();
            Close();
        }

        private void frmCategory_Load(object sender, EventArgs e)
        {
            
           
        }

        private void LoadComboBox()
        {
            try
            {
                List<PersonType> companies = GetCompany();
                companies.Insert(0, new PersonType() { ID = 0, Name = "Select PersonType" });
                companyNameComboBox.BindingContext = new BindingContext();
                companyNameComboBox.DataSource = companies;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
