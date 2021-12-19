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
    
    public partial class FormInputs : Form
    {
        Config config = new Config();
        public FormInputs()
        {
            InitializeComponent();
        }

        void clearInputs()
        {
            txtPassword.Clear();
            txtCPassword.Clear();
            txtUsername.Clear();
            cmbSex.SelectedIndex = -1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // validation
            TextBox[] txt = { txtUsername, txtPassword, txtCPassword };
            ComboBox[] cmb = { cmbSex };
            if (!config.validate.txtRequired(txt, true) || !config.validate.cmbRequired(cmb, true))
                return;

            // database
            if (config.db.exist("select username from users where username='" + txtUsername.Text + "'"))
            {
                MessageBox.Show("Username Already Exist");
            }
            else
            {

                if (txtPassword.Text == txtCPassword.Text)
                {
                    //3 lines save
                    string[] column = { "username", "password", "sex" };
                    string[] value = { txtUsername.Text, config.validate.encodePassword(txtPassword.Text), cmbSex.Text };
                    config.db.save("users", column, value, "User Successfully Saved");

                    //or you can use // 1 line
                    //config.db.cud("INSERT INTO users (username,password,sex) VALUES ('" + txtUsername.Text + "','" + txtPassword.Text + "','" + cmbSex.Text + "')","Successfully Saved");

                    clearInputs();
                }
                else
                {
                    MessageBox.Show("Password did not match!");
                }

            }
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            config.validate.alphanum(e);
        }
    }
}
