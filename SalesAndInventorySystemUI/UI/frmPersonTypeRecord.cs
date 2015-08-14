using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using SalesAndInventorySystemDataAccess.Gateway;
using SalesAndInventorySystemModel.BLL;


namespace SalesAndInventorySystemUI.UI
{
    public partial class frmPersonTypeRecord : Form
    {
        CompanyGateway TypeNameGateway=new CompanyGateway();
        private List<PersonType> personTypes=null;
        private string parameter = string.Empty;

        public frmPersonTypeRecord()
        {
            InitializeComponent();
        }

        
        private void frmPersonTypeRecord_Load(object sender, EventArgs e)
        {
            try
            {
                GetData();
            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        public void GetData( )
        {
            resultListView.Items.Clear();
            try
            {
               personTypes = TypeNameGateway.GetCompanies();
                if (personTypes.Count>0)
                {
                    
                    foreach (PersonType personType in personTypes)
                    {
                        ListViewItem item=new ListViewItem(personType.Name.ToString());
                        item.Tag = personType;
                        item.SubItems.Add(personType.Name);
                        resultListView.Items.Add(item);
                        
                    }
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        private void frmPersonTypeRecord_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            List<PersonType> searchPersonType = null;
            if (nameTextBox.Text == string.Empty)
            {
                searchPersonType = personTypes;
            }
            else
            {
                searchPersonType = personTypes.Where(x => x.Name.ToUpper(CultureInfo.InvariantCulture).Contains(nameTextBox.Text.ToUpper(CultureInfo.InvariantCulture))).Select(x => x).ToList();
            }
            resultListView.Items.Clear();
            try
            {

                if (searchPersonType.Count > 0)
                {
                    int serialNo = 0;
                    foreach (PersonType personType in searchPersonType)
                    {
                        ListViewItem item = new ListViewItem(personType.Name);
                        item.Tag = personType;
                        item.SubItems.Add(personType.Name);
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
            try
            {
                frmMainMenu myForm = (frmMainMenu)Application.OpenForms["frmMainMenu"];
                PersonType selectPersonType = GetSelectedPersonType();
                frmPersonType frmPersonType = new frmPersonType(selectPersonType){MdiParent = myForm};
                frmPersonType.Show();
                Close();
                //GetData();
                //resultListView.HideSelection = false;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private PersonType GetSelectedPersonType()
        {
            int index = resultListView.SelectedIndices[0];
            ListViewItem item = resultListView.Items[index];
            return (PersonType)item.Tag;
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            deleteToolStripMenuItem.Enabled = (resultListView.Items.Count > 0);
            updateToolStripMenuItem.Enabled = (resultListView.Items.Count > 0);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PersonType selectedPersonType = GetSelectedPersonType();
            int selectedIndex = resultListView.SelectedIndices[0];
            DialogResult result =MessageBox.Show("You are about to delete " + selectedPersonType.Name + " \nIs that alright?","Delete Employee", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    TypeNameGateway.DeleteCompany(selectedPersonType);
                    personTypes.Remove(selectedPersonType);
                    resultListView.Items.RemoveAt(selectedIndex);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmMainMenu myForm = (frmMainMenu)Application.OpenForms["frmMainMenu"];
            frmPersonType frm = new frmPersonType() { MdiParent = myForm };
            frm.Show();
            Close();
        }

        
    }
}
