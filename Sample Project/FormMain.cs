using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sample_OOP_Pro.Forms;

namespace Sample_OOP_Pro
{
    public partial class FormMain : Form
    {
        Config config = new Config();
        public Button[] menu;
        public FormMain()
        {
            InitializeComponent();
            this.menu = new Button[]{ btnDashboard, btnDataGridView, btnInputs, btnProfile, btnLogout};
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
             config.ui.FormShow(new FormDashboard(), "Fill");
             config.ui.active("FormDashboard", btnDashboard, Color.Blue, menu, Color.Gray);
        }

        private void btnDataGridView_Click(object sender, EventArgs e)
        {
            config.ui.FormShow(new FormDataGridView(), "Fill");
            config.ui.active("FormDataGridView", btnDataGridView, Color.Blue, menu, Color.Gray);
        }

        private void btnInputs_Click(object sender, EventArgs e)
        {
            config.ui.FormShow(new FormInputs(), "Fill");
            config.ui.active("FormInputs", btnInputs, Color.Blue, menu, Color.Gray);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            config.ui.Show(new FormLogin(), this);
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            config.ui.FormShow(new FormUpload(), "Fill");
            config.ui.active("FormUpload", btnProfile, Color.Blue, menu, Color.Gray);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            config.ui.FormShow(new FormDashboard(), "Fill");
            config.ui.active("FormDashboard", btnDashboard, Color.Blue, menu, Color.Gray);
        }
    }
}
