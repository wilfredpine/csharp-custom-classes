using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using C_Sharf_Classes.Classes;

namespace C_Sharf_Classes.View
{
    public partial class frmMain : Form
    {
        public static frmMain formParent;

        UI_events ui = new UI_events();

        public frmMain()
        {
            InitializeComponent();
            formParent = this;
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            frmDashboard dash = new frmDashboard();
            ui.FormShow(dash, "Fill");
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            frmDashboard dash = new frmDashboard();
            ui.FormShow(dash, "Fill");
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin();
            login.Show();
            this.Hide();
        }

        private void btnDataGridView_Click(object sender, EventArgs e)
        {
            frmDataGridView dgv = new frmDataGridView();
            ui.FormShow(dgv, "Fill");
        }

        private void btnInputs_Click(object sender, EventArgs e)
        {
            frmInputs input = new frmInputs();
            ui.FormShow(input, "Fill");
        }
    }
}
