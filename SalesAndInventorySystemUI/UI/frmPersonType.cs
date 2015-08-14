using System;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web.Caching;
using System.Windows.Forms;
using SalesAndInventorySystemDataAccess;
using SalesAndInventorySystemDataAccess.Gateway;
using SalesAndInventorySystemModel.BLL;

namespace SalesAndInventorySystemUI.UI
{
    public partial class frmPersonType : Form
    {
        
        private int typeID=0;
        private PersonType personType=null;
        CompanyGateway TypeNameGateway=new CompanyGateway();

        public frmPersonType()
        {
            InitializeComponent();
        }

        public frmPersonType(PersonType aPersonType):this()
        {
            try
            {
                btnSave.Text = @"Update";
                FillFieldsWith(aPersonType);
                typeID = aPersonType.ID;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FillFieldsWith(PersonType updatePersonType)
        {
            txtTypeName.Text = updatePersonType.Name;
        }
        private void Reset()
        {
            txtTypeName.Text = "";
            btnSave.Enabled = true;
            txtTypeName.Focus();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            personType = new PersonType();
            personType.ID = typeID;
            personType.Name = txtTypeName.Text;
            
            if (txtTypeName.Text == "")
            {
                MessageBox.Show("Please enter personType name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTypeName.Focus();
                return;
            }
            try
            {
                if (TypeNameGateway.CheckCompany(personType))
                {
                    MessageBox.Show(@"PersonType Name Already Exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTypeName.Focus();
                    return;
                }
                else if (btnSave.Text==@"Save")
                {
                    if (TypeNameGateway.AddCompany(personType))
                    {
                        txtTypeName.Text = string.Empty;
                        MessageBox.Show(@"Successfully saved.", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else if (btnSave.Text == @"Update")
                {
                    if (TypeNameGateway.UpdateCompany(personType))
                    {
                        txtTypeName.Text = string.Empty;
                        MessageBox.Show(@"Successfully updated.", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmMainMenu myForm = (frmMainMenu)Application.OpenForms["frmMainMenu"];
                        frmPersonTypeRecord frmPersonTypeRecord=new frmPersonTypeRecord(){MdiParent = myForm};
                        frmPersonTypeRecord.Show();
                        this.Close();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show(@"Problem to save PersonType....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTypeName.Text = "";
                    txtTypeName.Focus();
                    return;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            frmMainMenu myForm = (frmMainMenu)Application.OpenForms["frmMainMenu"];
            frmPersonTypeRecord frm = new frmPersonTypeRecord(){MdiParent = myForm};
            frm.Show();
            this.Close();
        }

        private void frmPersonType_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        
    }
}
