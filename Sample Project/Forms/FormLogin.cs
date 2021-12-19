using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sample_OOP_Pro.Forms
{
    public partial class FormLogin : Form
    {
        Config config = new Config();
        public_vars vars = new public_vars();

        public FormLogin()
        {
            InitializeComponent();
        }

        void clear()
        {
            txtUsername.Clear();
            txtPassword.Clear();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            TextBox[] txt = { txtUsername, txtPassword };
            if (!config.validate.txtRequired(txt))
            {
                return;
            }

            var reader = config.db.select("select * from users where username = '" + txtUsername.Text + "' and password = '" + config.validate.encodePassword(txtPassword.Text) + "' ");
            if (reader.Read())
            {
                //add your id to a global variable userId
                vars.user_id = Int32.Parse(reader["userid"].ToString());

                FormMain frmain = new FormMain();
                config.ui.Show(frmain, this);

                clear();
            }
            else
            {
                MessageBox.Show("Invalid Username / Password!");
            }
        }
    }
}
