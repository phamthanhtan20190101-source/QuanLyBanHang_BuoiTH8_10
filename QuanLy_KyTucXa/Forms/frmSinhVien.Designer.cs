namespace QuanLy_KyTucXa.Forms
{
    partial class frmSinhVien
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
            groupBox1 = new GroupBox();
            btnXinRoiKTX = new Button();
            btnDonXinChuyenPhong = new Button();
            label10 = new Label();
            txtTienNo = new TextBox();
            txtmaphong = new TextBox();
            txtngaysinh = new TextBox();
            txtngayvao = new TextBox();
            txtgioitinh = new TextBox();
            label9 = new Label();
            txthoten = new TextBox();
            label8 = new Label();
            txtlop = new TextBox();
            label7 = new Label();
            txtquequan = new TextBox();
            label6 = new Label();
            txtsdt = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtmssv = new TextBox();
            groupBox2 = new GroupBox();
            dgvLichSuDongTien = new DataGridView();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLichSuDongTien).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnXinRoiKTX);
            groupBox1.Controls.Add(btnDonXinChuyenPhong);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(txtTienNo);
            groupBox1.Controls.Add(txtmaphong);
            groupBox1.Controls.Add(txtngaysinh);
            groupBox1.Controls.Add(txtngayvao);
            groupBox1.Controls.Add(txtgioitinh);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(txthoten);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(txtlop);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(txtquequan);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(txtsdt);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtmssv);
            groupBox1.Location = new Point(23, 27);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1276, 240);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin sinh viên";
            // 
            // btnXinRoiKTX
            // 
            btnXinRoiKTX.Location = new Point(831, 194);
            btnXinRoiKTX.Name = "btnXinRoiKTX";
            btnXinRoiKTX.Size = new Size(418, 40);
            btnXinRoiKTX.TabIndex = 27;
            btnXinRoiKTX.Text = "Đơn Xin Rời KTX";
            btnXinRoiKTX.UseVisualStyleBackColor = true;
            btnXinRoiKTX.Click += btnXinRoiKTX_Click;
            // 
            // btnDonXinChuyenPhong
            // 
            btnDonXinChuyenPhong.Location = new Point(391, 194);
            btnDonXinChuyenPhong.Name = "btnDonXinChuyenPhong";
            btnDonXinChuyenPhong.Size = new Size(418, 40);
            btnDonXinChuyenPhong.TabIndex = 26;
            btnDonXinChuyenPhong.Text = "Đơn Xin Chuyển Phòng";
            btnDonXinChuyenPhong.UseVisualStyleBackColor = true;
            btnDonXinChuyenPhong.Click += btnDonXinChuyenPhong_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(6, 198);
            label10.Name = "label10";
            label10.Size = new Size(79, 25);
            label10.TabIndex = 24;
            label10.Text = "Tiền nợ :";
            // 
            // txtTienNo
            // 
            txtTienNo.Location = new Point(87, 194);
            txtTienNo.Name = "txtTienNo";
            txtTienNo.Size = new Size(286, 31);
            txtTienNo.TabIndex = 25;
            // 
            // txtmaphong
            // 
            txtmaphong.Location = new Point(523, 148);
            txtmaphong.Name = "txtmaphong";
            txtmaphong.Size = new Size(286, 31);
            txtmaphong.TabIndex = 23;
            // 
            // txtngaysinh
            // 
            txtngaysinh.Location = new Point(947, 96);
            txtngaysinh.Name = "txtngaysinh";
            txtngaysinh.Size = new Size(302, 31);
            txtngaysinh.TabIndex = 22;
            // 
            // txtngayvao
            // 
            txtngayvao.Location = new Point(947, 151);
            txtngayvao.Name = "txtngayvao";
            txtngayvao.Size = new Size(302, 31);
            txtngayvao.TabIndex = 21;
            // 
            // txtgioitinh
            // 
            txtgioitinh.Location = new Point(947, 42);
            txtgioitinh.Name = "txtgioitinh";
            txtgioitinh.Size = new Size(302, 31);
            txtgioitinh.TabIndex = 20;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(831, 95);
            label9.Name = "label9";
            label9.Size = new Size(102, 25);
            label9.TabIndex = 18;
            label9.Text = "Ngày Sinh :";
            // 
            // txthoten
            // 
            txthoten.Location = new Point(87, 93);
            txthoten.Name = "txthoten";
            txthoten.Size = new Size(286, 31);
            txthoten.TabIndex = 19;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 152);
            label8.Name = "label8";
            label8.Size = new Size(51, 25);
            label8.TabIndex = 16;
            label8.Text = "Lớp :";
            // 
            // txtlop
            // 
            txtlop.Location = new Point(87, 148);
            txtlop.Name = "txtlop";
            txtlop.Size = new Size(286, 31);
            txtlop.TabIndex = 17;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(391, 95);
            label7.Name = "label7";
            label7.Size = new Size(126, 25);
            label7.TabIndex = 14;
            label7.Text = "Số điện thoại :";
            // 
            // txtquequan
            // 
            txtquequan.Location = new Point(523, 42);
            txtquequan.Name = "txtquequan";
            txtquequan.Size = new Size(286, 31);
            txtquequan.TabIndex = 15;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(391, 154);
            label6.Name = "label6";
            label6.Size = new Size(103, 25);
            label6.TabIndex = 12;
            label6.Text = "Mã Phòng :";
            // 
            // txtsdt
            // 
            txtsdt.Location = new Point(523, 89);
            txtsdt.Name = "txtsdt";
            txtsdt.Size = new Size(286, 31);
            txtsdt.TabIndex = 13;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 93);
            label5.Name = "label5";
            label5.Size = new Size(75, 25);
            label5.TabIndex = 10;
            label5.Text = "Họ tên :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(831, 42);
            label4.Name = "label4";
            label4.Size = new Size(90, 25);
            label4.TabIndex = 8;
            label4.Text = "Giới Tính :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(831, 154);
            label3.Name = "label3";
            label3.Size = new Size(97, 25);
            label3.TabIndex = 6;
            label3.Text = "Ngày vào :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(391, 42);
            label2.Name = "label2";
            label2.Size = new Size(99, 25);
            label2.TabIndex = 4;
            label2.Text = "Quê quán :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 40);
            label1.Name = "label1";
            label1.Size = new Size(68, 25);
            label1.TabIndex = 1;
            label1.Text = "MSSV :";
            // 
            // txtmssv
            // 
            txtmssv.Location = new Point(87, 39);
            txtmssv.Name = "txtmssv";
            txtmssv.Size = new Size(286, 31);
            txtmssv.TabIndex = 2;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgvLichSuDongTien);
            groupBox2.Location = new Point(23, 273);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1276, 284);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            groupBox2.Text = "Lịch sử đóng tiền";
            // 
            // dgvLichSuDongTien
            // 
            dgvLichSuDongTien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLichSuDongTien.Dock = DockStyle.Fill;
            dgvLichSuDongTien.Location = new Point(3, 27);
            dgvLichSuDongTien.Name = "dgvLichSuDongTien";
            dgvLichSuDongTien.RowHeadersWidth = 62;
            dgvLichSuDongTien.Size = new Size(1270, 254);
            dgvLichSuDongTien.TabIndex = 0;
            // 
            // frmSinhVien
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1332, 569);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "frmSinhVien";
            Text = "frmSinhVien";
            Load += frmSinhVien_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvLichSuDongTien).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label9;
        private TextBox txthoten;
        private Label label8;
        private TextBox txtlop;
        private Label label7;
        private TextBox txtquequan;
        private Label label6;
        private TextBox txtsdt;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtmssv;
        private TextBox txtngaysinh;
        private TextBox txtngayvao;
        private TextBox txtgioitinh;
        private TextBox txtmaphong;
        private Label label10;
        private TextBox txtTienNo;
        private Button btnDonXinChuyenPhong;
        private Button btnXinRoiKTX;
        private GroupBox groupBox2;
        private DataGridView dgvLichSuDongTien;
    }
}