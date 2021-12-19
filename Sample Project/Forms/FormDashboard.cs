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
    public partial class FormDashboard : Form
    {
        Config config = new Config();
        public_vars vars = new public_vars();
        public FormDashboard()
        {
            InitializeComponent();
        }

        private void FormDashboard_Load(object sender, EventArgs e)
        {
            loadChartSample_Static();
            loadChart_from_DB();
            loadChartSample_Static_line();
        }

        void loadChartSample_Static()
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
            config.visualizer.chart(chartRight, "Male", X, Y, "Column");

            //_________________________________________________________________________________

            /*
             * NEW SERIES FEMALE
             */

            // new 
            string[] x2 = { "BSIT", "BSED", "AB" };
            int[] y2 = { 6, 0, 16 };

            // Female
            config.visualizer.chart(chartRight, "Female", x2, y2, "Column");
        }

        void loadChart_from_DB()
        {
            /*
             * SERIES SEX
             */
            string[] X = { };
            int[] Y = { };

            var reader = config.db.select("select count(*) as c, sex from users group by sex");
            while (reader.Read())
            {
                X = X.Concat(new string[] { reader["sex"].ToString() }).ToArray();
                Y = Y.Concat(new int[] { Int32.Parse(reader["c"].ToString()) }).ToArray();
            }

            // Chart Methods
            // ChartSeries = "Sex"; ChartType = "Column";
            config.visualizer.chart(chartLeft, "Sex", X, Y, "Column");

        }

        void loadChartSample_Static_line()
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
            config.visualizer.chart(chartTop, "Male", X, Y, "Line");

            //_________________________________________________________________________________

            /*
             * NEW SERIES FEMALE
             */

            // new 
            string[] x2 = { "BSIT", "BSED", "AB" };
            int[] y2 = { 6, 0, 16 };

            // Female
            config.visualizer.chart(chartTop, "Female", x2, y2, "Line");
        }

    }
}
