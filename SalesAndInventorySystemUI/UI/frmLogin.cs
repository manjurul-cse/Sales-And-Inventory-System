using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using SalesAndInventorySystemDataAccess.Gateway;
using SalesAndInventorySystemModel.BLL;

namespace SalesAndInventorySystemUI.UI
{
    public partial class frmLogin : Form
    {
        UserGateway userGateway=new UserGateway();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "")
            {
                MessageBox.Show("Please enter user name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserName.Focus();
                return;
            }
            if (txtPassword.Text == "")
            {
                MessageBox.Show("Please enter password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return;
            }
            try
            {
                User user = new User()
                {
                    UserName = txtUserName.Text,
                    Password = txtPassword.Text
                };
                if (userGateway.Login(user))
                {
                    DialogResult = DialogResult.OK;
                }

                else
                {
                    MessageBox.Show("Login is Failed...Try again !", "Login Denied", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    txtUserName.Clear();
                    txtPassword.Clear();
                    txtUserName.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
      
        private void Form1_Load(object sender, EventArgs e)
        {
            ProgressBar1.Visible = false;
            txtUserName.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //this.Hide();
            //frmChangePassword frm = new frmChangePassword();
            //frm.Show();
            //frm.txtUserName.Text = "";
            //frm.txtNewPassword.Text = "";
            //frm.txtOldPassword.Text = "";
            //frm.txtConfirmPassword.Text = "";
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //this.Hide();
            //frmRecoveryPassword frm = new frmRecoveryPassword();
            //frm.txtEmail.Focus();
            //frm.Show();
        }
    }
}
