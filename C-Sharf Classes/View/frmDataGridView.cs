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
    public partial class frmDataGridView : Form
    {
        Database db = new Database();

        public frmDataGridView()
        {
            InitializeComponent();
        }

        void loadUsers()
        {
            //optional
            string[] customheader = { "User ID", "Username", "Gender" };

            //table methods
            db.table("select userid,username,sex from users", dgvUsers, customheader);
        }

        void searchUser()
        {
            //optional
            string[] customheader = { "User ID", "Username", "Gender" };

            //table methods
            db.table("select userid,username,sex from users where username='"+ txtUsername.Text +"'", dgvUsers, customheader);
        }

        private void frmDataGridView_Load(object sender, EventArgs e)
        {
            loadUsers();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            searchUser();
        }
    }
}
