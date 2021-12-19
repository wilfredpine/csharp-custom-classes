
namespace Sample_OOP_Pro.Forms
{
    partial class FormDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartLeft = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartRight = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chartTop = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRight)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTop)).BeginInit();
            this.SuspendLayout();
            // 
            // chartLeft
            // 
            chartArea4.Name = "ChartArea1";
            this.chartLeft.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chartLeft.Legends.Add(legend4);
            this.chartLeft.Location = new System.Drawing.Point(12, 32);
            this.chartLeft.Name = "chartLeft";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chartLeft.Series.Add(series4);
            this.chartLeft.Size = new System.Drawing.Size(396, 246);
            this.chartLeft.TabIndex = 0;
            this.chartLeft.Text = "chartLeft";
            // 
            // chartRight
            // 
            chartArea5.Name = "ChartArea1";
            this.chartRight.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.chartRight.Legends.Add(legend5);
            this.chartRight.Location = new System.Drawing.Point(11, 32);
            this.chartRight.Name = "chartRight";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            this.chartRight.Series.Add(series5);
            this.chartRight.Size = new System.Drawing.Size(395, 246);
            this.chartRight.TabIndex = 1;
            this.chartRight.Text = "chartRight";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chartRight);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(462, 351);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(421, 295);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Static";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chartLeft);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(23, 351);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(422, 295);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "From Database";
            // 
            // chartTop
            // 
            chartArea6.Name = "ChartArea1";
            this.chartTop.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.chartTop.Legends.Add(legend6);
            this.chartTop.Location = new System.Drawing.Point(23, 24);
            this.chartTop.Name = "chartTop";
            series6.ChartArea = "ChartArea1";
            series6.Legend = "Legend1";
            series6.Name = "Series1";
            this.chartTop.Series.Add(series6);
            this.chartTop.Size = new System.Drawing.Size(860, 304);
            this.chartTop.TabIndex = 1;
            this.chartTop.Text = "chartTop";
            // 
            // FormDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 675);
            this.Controls.Add(this.chartTop);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormDashboard";
            this.Load += new System.EventHandler(this.FormDashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRight)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartTop)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartLeft;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRight;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTop;
    }
}