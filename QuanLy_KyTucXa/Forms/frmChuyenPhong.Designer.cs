namespace QuanLy_KyTucXa.Forms
{
    partial class frmChuyenPhong
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            labelTitle = new Label();
            label1 = new Label();
            txtMSSV = new TextBox();
            label2 = new Label();
            txtPhongCu = new TextBox();
            label3 = new Label();
            cobPhongMoi = new ComboBox();
            btnXacNhan = new Button();
            txtHoTen = new TextBox();
            label4 = new Label();
            SuspendLayout();
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            labelTitle.ForeColor = Color.DarkBlue;
            labelTitle.Location = new Point(121, 33);
            labelTitle.Margin = new Padding(4, 0, 4, 0);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(444, 45);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "CHUYỂN PHÒNG SINH VIÊN";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(57, 150);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(139, 25);
            label1.TabIndex = 1;
            label1.Text = "Mã số sinh viên:";
            // 
            // txtMSSV
            // 
            txtMSSV.Location = new Point(214, 145);
            txtMSSV.Margin = new Padding(4, 5, 4, 5);
            txtMSSV.Name = "txtMSSV";
            txtMSSV.Size = new Size(370, 31);
            txtMSSV.TabIndex = 2;
            txtMSSV.TextChanged += txtMSSV_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(57, 294);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(130, 25);
            label2.TabIndex = 3;
            label2.Text = "Phòng hiện tại:";
            // 
            // txtPhongCu
            // 
            txtPhongCu.BackColor = Color.WhiteSmoke;
            txtPhongCu.Location = new Point(214, 289);
            txtPhongCu.Margin = new Padding(4, 5, 4, 5);
            txtPhongCu.Name = "txtPhongCu";
            txtPhongCu.ReadOnly = true;
            txtPhongCu.Size = new Size(370, 31);
            txtPhongCu.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(57, 378);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(152, 25);
            label3.TabIndex = 5;
            label3.Text = "Chọn phòng mới:";
            // 
            // cobPhongMoi
            // 
            cobPhongMoi.DropDownStyle = ComboBoxStyle.DropDownList;
            cobPhongMoi.FormattingEnabled = true;
            cobPhongMoi.Location = new Point(214, 373);
            cobPhongMoi.Margin = new Padding(4, 5, 4, 5);
            cobPhongMoi.Name = "cobPhongMoi";
            cobPhongMoi.Size = new Size(370, 33);
            cobPhongMoi.TabIndex = 6;
            // 
            // btnXacNhan
            // 
            btnXacNhan.BackColor = Color.ForestGreen;
            btnXacNhan.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnXacNhan.ForeColor = Color.White;
            btnXacNhan.Location = new Point(152, 482);
            btnXacNhan.Margin = new Padding(4, 5, 4, 5);
            btnXacNhan.Name = "btnXacNhan";
            btnXacNhan.Size = new Size(371, 75);
            btnXacNhan.TabIndex = 7;
            btnXacNhan.Text = "XÁC NHẬN CHUYỂN";
            btnXacNhan.UseVisualStyleBackColor = false;
            btnXacNhan.Click += btnXacNhan_Click;
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(214, 212);
            txtHoTen.Margin = new Padding(4, 5, 4, 5);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(370, 31);
            txtHoTen.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(57, 217);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(144, 25);
            label4.TabIndex = 8;
            label4.Text = "Họ tên sinh viên:";
            // 
            // frmChuyenPhong
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(689, 622);
            Controls.Add(txtHoTen);
            Controls.Add(label4);
            Controls.Add(btnXacNhan);
            Controls.Add(cobPhongMoi);
            Controls.Add(label3);
            Controls.Add(txtPhongCu);
            Controls.Add(label2);
            Controls.Add(txtMSSV);
            Controls.Add(label1);
            Controls.Add(labelTitle);
            Margin = new Padding(4, 5, 4, 5);
            Name = "frmChuyenPhong";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý Chuyển Phòng";
            Load += frmChuyenPhong_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMSSV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPhongCu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cobPhongMoi;
        private System.Windows.Forms.Button btnXacNhan;
        private TextBox txtHoTen;
        private Label label4;
    }
}