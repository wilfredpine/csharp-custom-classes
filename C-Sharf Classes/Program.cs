using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using C_Sharf_Classes.Classes;
using C_Sharf_Classes.View;

namespace C_Sharf_Classes
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Database db = new Database();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmLogin());
            }
            catch(Exception)
            {
                MessageBox.Show("Database Connection Error! The application will exit.");
                System.Environment.Exit(1);
            }
           
        }
    }
}
