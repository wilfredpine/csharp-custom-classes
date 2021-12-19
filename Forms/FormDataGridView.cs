using System;
using System.Windows.Forms;

namespace Sample_OOP_Pro.Forms
{
    public partial class FormDataGridView : Form
    {
        Config config = new Config();
        public FormDataGridView()
        {
            InitializeComponent();
        }

        void loadUsers()
        {
            //optional
            string[] customheader = { "User ID", "Username", "Gender" };

            //table methods
            config.db.table("select userid,username,sex from users", dgvUsers, customheader);
        }

        void searchUser()
        {
            //optional
            string[] customheader = { "User ID", "Username", "Gender" };

            //table methods
            config.db.table("select userid,username,sex from users where username='" + txtUsername.Text + "'", dgvUsers, customheader);
        }

        private void FormDataGridView_Load(object sender, EventArgs e)
        {
            loadUsers();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            searchUser();
        }
    }
}
