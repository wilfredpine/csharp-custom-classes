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
    public partial class frmDashboard : Form
    {

        UI_events ui = new UI_events();
        Database db = new Database();

        public frmDashboard()
        {
            InitializeComponent();
        }

        void loadChartSample()
        {
            /*
             * SERIES MALE
             */

            // Array Legend
            string[] X = { "BSIT", "BSED" };
            // Add item to array Legend
            X = X.Concat(new string[] { "AB" }).ToArray(); 
            // new X is "BSIT", "BSED", "AB"


            // Array Value
            int[] Y = { 12, 14 };
            // Add item to array
            Y = Y.Concat(new int[] { 2 }).ToArray(); 
            // Y = 12, 14, 2


            // Pass to Chart Methods = Male Series
            ui.chart(chartUser, "Male", X, Y, "Column");

            //_________________________________________________________________________________
            
            /*
             * NEW SERIES FEMALE
             */

            // new 
            string[] x2 = { "BSIT", "BSED", "AB" };
            int[] y2 = { 6, 0, 16 };

            // Female
            ui.chart(chartUser, "Female", x2, y2, "Column");
        }

        void loadChart()
        {
            /*
             * SERIES SEX
             */
            string[] X = {};
            int[] Y = {};

            var reader = db.select("select count(*) as c, sex from users group by sex");
            while (reader.Read())
            {
                X = X.Concat(new string[] { reader["sex"].ToString() }).ToArray();
                Y = Y.Concat(new int[] { Int32.Parse(reader["c"].ToString()) }).ToArray();
            }

            // Chart Methods
            // ChartSeries = "Sex"; ChartType = "Column";
            ui.chart(chartUser, "Sex", X, Y, "Column");
            
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            loadChart();
        }
    }
}
