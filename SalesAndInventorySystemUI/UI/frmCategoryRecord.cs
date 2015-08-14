using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using SalesAndInventorySystemDataAccess.Gateway;
using SalesAndInventorySystemModel.BLL;

namespace SalesAndInventorySystemUI.UI
{
    public partial class frmCategoryRecord : Form
    {
        CategoryGateway categoryGateway=new CategoryGateway();
        CompanyGateway companyGateway=new CompanyGateway();
        private List<Category> categories = null; 
        
        

        public frmCategoryRecord()
        {
            InitializeComponent();
            
        }
        
        public void GetData()
        {
            resultListView.Items.Clear();
            try
            {
                categories = categoryGateway.GetCategoriesByID();
                if (categories.Count > 0)
                {
                    int serialNo = 0;
                    foreach (Category category in categories)
                    {
                        ListViewItem item = new ListViewItem(category.Name);
                        item.Tag = category;
                        //item.SubItems.Add(category.Name);
                        item.SubItems.Add(companyGateway.GetCompanies(category.CompanyID).Name);
                        resultListView.Items.Add(item);
                        serialNo++;
                    }
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        private void frmCategoryRecord_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmCategory frm = new frmCategory();
            frm.Show();
            
        }

        private void frmCategoryRecord_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            List<Category> searchCategories = null;
            if (nameTextBox.Text == string.Empty)
            {
                searchCategories = categories;
            }
            else
            {
                searchCategories = categories.Where(x => x.Name.ToUpper(CultureInfo.InvariantCulture).Contains(nameTextBox.Text.ToUpper(CultureInfo.InvariantCulture))).Select(x => x).ToList();
            }
            resultListView.Items.Clear();
            try
            {
                if (searchCategories.Count > 0)
                {
                    int serialNo = 0;
                    foreach (Category category in searchCategories)
                    {
                        ListViewItem item = new ListViewItem(category.Name);
                        item.Tag = category;
                        //item.SubItems.Add(category.Name);
                        item.SubItems.Add(companyGateway.GetCompanies(category.CompanyID).Name);
                        resultListView.Items.Add(item);
                        serialNo++;
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMainMenu myForm = (frmMainMenu)Application.OpenForms["frmMainMenu"];
            Category selectCategory = GetSelectedCategory();
            frmCategory frmCategory = new frmCategory(selectCategory){MdiParent = myForm};
            frmCategory.Show();
            Close();
            //GetData();
            //resultListView.HideSelection = false;
        }

        private Category GetSelectedCategory()
        {
            int index = resultListView.SelectedIndices[0];
            ListViewItem item = resultListView.Items[index];
            return (Category)item.Tag;
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            deleteToolStripMenuItem.Enabled = (resultListView.Items.Count > 0);
            updateToolStripMenuItem.Enabled = (resultListView.Items.Count > 0);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Category selectCategory = GetSelectedCategory();
            int selectedIndex = resultListView.SelectedIndices[0];
            DialogResult result = MessageBox.Show("You are about to delete " + selectCategory.Name + " \nIs that alright?", "Delete Employee", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    categoryGateway.DeleteCategory(selectCategory);
                    resultListView.Items.RemoveAt(selectedIndex);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

}
