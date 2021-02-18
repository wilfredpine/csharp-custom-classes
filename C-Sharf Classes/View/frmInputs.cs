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
    public partial class frmInputs : Form
    {

        Database db = new Database();
        Validations validate = new Validations();

        public frmInputs()
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
            if (!validate.txtRequired(txt) || !validate.cmbRequired(cmb))
                return;
            
            // database
            if(db.exist("select username from users where username='" + txtUsername.Text + "'"))
            {
                MessageBox.Show("Username Already Exist");
            }
            else
            {

                if (txtPassword.Text == txtCPassword.Text)
                {
                    //3 lines save
                    string[] value = { txtUsername.Text, validate.encodePassword(txtPassword.Text), cmbSex.Text };
                    string[] column = { "username", "password", "sex" };
                    db.save("users", column, value);

                    //or you can use // 1 line
                    //db.cud("INSERT INTO users (username,password,sex) VALUES ('" + txtUsername.Text + "','" + txtPassword.Text + "','" + cmbSex.Text + "')","Successfully Saved");

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
            validate.alphanum(e);
        }
    }
}
