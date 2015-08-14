using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using SalesAndInventorySystemDataAccess;
using SalesAndInventorySystemModel.BLL;
using SalesAndInventorySystemUI.ReportUI;
using SalesAndInventorySystemUI.UI;
using User = SalesAndInventorySystemModel.BLL.User;

namespace SalesAndInventorySystemUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMainMenu());
            //using (var addsd = new SalesAndInventorySystemDataContext())
            //{
            //    var aUser = new User() { UserID = 1, UserName = "ADMIN", Password = "123456" };
            //    addsd.Users.AddOrUpdate(aUser);
            //    addsd.Entry(aUser).State = System.Data.Entity.EntityState.Added;
            //    addsd.SaveChanges();

            //}

            //frmSplash frmSplash = new frmSplash();
            //frmSplash.ShowDialog();
            //frmLogin login = new frmLogin();
            //DialogResult result = login.ShowDialog();
            //if (result == DialogResult.OK)
            //{
            //    Application.Run(new frmMainMenu());
            //}
            //else
            //{
            //    Application.Exit();
            //}
           
            
            
        }
    }
}
