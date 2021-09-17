using System;
using System.Windows.Forms;
using C_Sharf_Classes.Classes;
using C_Sharf_Classes.View;

namespace C_Sharf_Classes
{
    public partial class frmLogin : Form
    {

        Database db = new Database();
        Validations validate = new Validations();
        UI_events ui = new UI_events();
        Public_variables variables = new Public_variables();

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            
            TextBox[] txt = { txtUsername, txtPassword };
            if (!validate.txtRequired(txt))
            {
                return;
            }
            
            var reader = db.select("select * from users where username = '"+txtUsername.Text+ "' and password = '" + validate.encodePassword(txtPassword.Text) + "' ");
            if (reader.Read())
            {
                
                //add your id to a global variable userId
                variables.userId = Int32.Parse(reader["userid"].ToString());
                
                frmMain frmain = new frmMain();
                ui.Show(frmain, this);

                clear();
            }
            else
            {
                MessageBox.Show("Invalid Username / Password!");
                clear();
            }
            
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void clear()
        {
            txtUsername.Clear();
            txtPassword.Clear();
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            validate.alphanum(e);
        }

    }
}
