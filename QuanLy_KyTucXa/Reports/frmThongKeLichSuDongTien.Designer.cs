namespace QuanLy_KyTucXa.Reports
{
    partial class frmThongKeLichSuDongTien
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
            reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            cobLocTheoThang = new ComboBox();
            label1 = new Label();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // reportViewer1
            // 
            reportViewer1.Dock = DockStyle.Fill;
            reportViewer1.Location = new Point(0, 0);
            reportViewer1.Name = "reportViewer1";
            reportViewer1.ServerReport.BearerToken = null;
            reportViewer1.Size = new Size(800, 450);
            reportViewer1.TabIndex = 0;
            // 
            // cobLocTheoThang
            // 
            cobLocTheoThang.FormattingEnabled = true;
            cobLocTheoThang.Items.AddRange(new object[] { "Tháng 1", "Tháng 2", "Tháng 3", "Tháng 4", "Tháng 5", "Tháng 6", "Tháng 7", "Tháng 8", "Tháng 9", "Tháng 10", "Tháng 11", "Tháng 12" });
            cobLocTheoThang.Location = new Point(565, 6);
            cobLocTheoThang.Name = "cobLocTheoThang";
            cobLocTheoThang.Size = new Size(182, 33);
            cobLocTheoThang.TabIndex = 1;
            cobLocTheoThang.SelectedIndexChanged += cobLocTheoThang_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(414, 9);
            label1.Name = "label1";
            label1.Size = new Size(145, 25);
            label1.TabIndex = 2;
            label1.Text = "Lọc theo tháng : ";
            // 
            // panel1
            // 
            panel1.Controls.Add(cobLocTheoThang);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 42);
            panel1.TabIndex = 4;
            // 
            // frmThongKeLichSuDongTien
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(reportViewer1);
            Name = "frmThongKeLichSuDongTien";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmThongKeLichSuDongTien";
            WindowState = FormWindowState.Maximized;
            Load += frmThongKeLichSuDongTien_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private ComboBox cobLocTheoThang;
        private Label label1;
        private Panel panel1;
    }
}