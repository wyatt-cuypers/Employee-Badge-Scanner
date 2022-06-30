using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employee_Badge_Scanner
{
    public partial class databaseConnection : Form
    {
        public databaseConnection()
        {
            InitializeComponent();
            txtServer.Text = MainForm.dbServer;
            txtUser.Text = MainForm.dbUser;
            txtPassword.Text = MainForm.dbPassword;
        }
        private void databaseConnection_Close(object sender, FormClosingEventArgs e)
        {
            this.Hide();
        }

        private void btnOkay_Click(object sender, EventArgs e)
        {
            MainForm.dbServer = txtServer.Text;
            MainForm.dbUser = txtUser.Text;
            MainForm.dbPassword = txtPassword.Text;
            MainForm.Store_INI_Values();
            MainForm.btnRefresh.PerformClick();
            this.Close();
        }
    }
}
