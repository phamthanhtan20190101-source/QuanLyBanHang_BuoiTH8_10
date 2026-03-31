namespace QuanLy_KyTucXa.Forms
{
    partial class CapNhatDongTien
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            txthoten = new TextBox();
            label8 = new Label();
            txtlop = new TextBox();
            label7 = new Label();
            txtsdt = new TextBox();
            label5 = new Label();
            btnThoat = new Button();
            label1 = new Label();
            txtmssv = new TextBox();
            dataGridView = new DataGridView();
            MSSV = new DataGridViewTextBoxColumn();
            HoTen = new DataGridViewTextBoxColumn();
            Lop = new DataGridViewTextBoxColumn();
            SDT = new DataGridViewTextBoxColumn();
            NgayVao = new DataGridViewTextBoxColumn();
            MaPhong = new DataGridViewTextBoxColumn();
            TrangThaiTienPhong = new DataGridViewTextBoxColumn();
            groupBox2 = new GroupBox();
            groupBox1 = new GroupBox();
            checkSVno = new CheckBox();
            label4 = new Label();
            txtTienNo = new TextBox();
            btnXacnhan = new Button();
            label3 = new Label();
            checkedList_DongTien = new CheckedListBox();
            label2 = new Label();
            textsotiennhan = new TextBox();
            cobtimkiem = new ComboBox();
            btnTimKiem = new Button();
            txttimkiem = new TextBox();
            label10 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // txthoten
            // 
            txthoten.Location = new Point(91, 93);
            txthoten.Name = "txthoten";
            txthoten.Size = new Size(286, 31);
            txthoten.TabIndex = 19;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(10, 152);
            label8.Name = "label8";
            label8.Size = new Size(51, 25);
            label8.TabIndex = 16;
            label8.Text = "Lớp :";
            // 
            // txtlop
            // 
            txtlop.Location = new Point(91, 148);
            txtlop.Name = "txtlop";
            txtlop.Size = new Size(286, 31);
            txtlop.TabIndex = 17;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(409, 93);
            label7.Name = "label7";
            label7.Size = new Size(126, 25);
            label7.TabIndex = 14;
            label7.Text = "Số điện thoại :";
            // 
            // txtsdt
            // 
            txtsdt.Location = new Point(560, 87);
            txtsdt.Name = "txtsdt";
            txtsdt.Size = new Size(286, 31);
            txtsdt.TabIndex = 13;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(10, 93);
            label5.Name = "label5";
            label5.Size = new Size(75, 25);
            label5.TabIndex = 10;
            label5.Text = "Họ tên :";
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(1166, 235);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(120, 41);
            btnThoat.TabIndex = 3;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 40);
            label1.Name = "label1";
            label1.Size = new Size(68, 25);
            label1.TabIndex = 1;
            label1.Text = "MSSV :";
            // 
            // txtmssv
            // 
            txtmssv.Location = new Point(91, 39);
            txtmssv.Name = "txtmssv";
            txtmssv.Size = new Size(286, 31);
            txtmssv.TabIndex = 2;
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { MSSV, HoTen, Lop, SDT, NgayVao, MaPhong, TrangThaiTienPhong });
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.Location = new Point(3, 27);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersWidth = 62;
            dataGridView.Size = new Size(1312, 524);
            dataGridView.TabIndex = 0;
            dataGridView.CellClick += dataGridView_CellClick;
            // 
            // MSSV
            // 
            MSSV.HeaderText = "Mã Số Sinh Viên";
            MSSV.MinimumWidth = 8;
            MSSV.Name = "MSSV";
            MSSV.ReadOnly = true;
            // 
            // HoTen
            // 
            HoTen.HeaderText = "Họ Tên";
            HoTen.MinimumWidth = 8;
            HoTen.Name = "HoTen";
            HoTen.ReadOnly = true;
            // 
            // Lop
            // 
            Lop.HeaderText = "Lớp";
            Lop.MinimumWidth = 8;
            Lop.Name = "Lop";
            Lop.ReadOnly = true;
            // 
            // SDT
            // 
            SDT.HeaderText = "Số Điện Thoại";
            SDT.MinimumWidth = 8;
            SDT.Name = "SDT";
            SDT.ReadOnly = true;
            // 
            // NgayVao
            // 
            dataGridViewCellStyle2.Format = "dd/MM/yyyy";
            NgayVao.DefaultCellStyle = dataGridViewCellStyle2;
            NgayVao.HeaderText = "Ngày Vào";
            NgayVao.MinimumWidth = 8;
            NgayVao.Name = "NgayVao";
            NgayVao.ReadOnly = true;
            // 
            // MaPhong
            // 
            MaPhong.HeaderText = "Mã Phòng";
            MaPhong.MinimumWidth = 8;
            MaPhong.Name = "MaPhong";
            MaPhong.ReadOnly = true;
            // 
            // TrangThaiTienPhong
            // 
            TrangThaiTienPhong.DataPropertyName = "TrangThaiTienPhong";
            TrangThaiTienPhong.HeaderText = "Trạng Thái Tiền Phòng";
            TrangThaiTienPhong.MinimumWidth = 8;
            TrangThaiTienPhong.Name = "TrangThaiTienPhong";
            TrangThaiTienPhong.ReadOnly = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dataGridView);
            groupBox2.Location = new Point(12, 307);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1318, 554);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh sách sinh viên";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(checkSVno);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtTienNo);
            groupBox1.Controls.Add(btnXacnhan);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(checkedList_DongTien);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(textsotiennhan);
            groupBox1.Controls.Add(cobtimkiem);
            groupBox1.Controls.Add(btnTimKiem);
            groupBox1.Controls.Add(txttimkiem);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(txthoten);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(txtlop);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(txtsdt);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(btnThoat);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtmssv);
            groupBox1.Location = new Point(15, 20);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1315, 290);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin sinh viên";
            // 
            // checkSVno
            // 
            checkSVno.AutoSize = true;
            checkSVno.Location = new Point(509, 235);
            checkSVno.Name = "checkSVno";
            checkSVno.Size = new Size(169, 29);
            checkSVno.TabIndex = 38;
            checkSVno.Text = "Sinh viên còn nợ";
            checkSVno.UseVisualStyleBackColor = true;
            checkSVno.CheckedChanged += checkSVno_CheckedChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(409, 152);
            label4.Name = "label4";
            label4.Size = new Size(136, 25);
            label4.TabIndex = 37;
            label4.Text = "Số tiền còn nợ :";
            // 
            // txtTienNo
            // 
            txtTienNo.Location = new Point(560, 146);
            txtTienNo.Name = "txtTienNo";
            txtTienNo.Size = new Size(286, 31);
            txtTienNo.TabIndex = 36;
            // 
            // btnXacnhan
            // 
            btnXacnhan.Location = new Point(1098, 93);
            btnXacnhan.Name = "btnXacnhan";
            btnXacnhan.Size = new Size(188, 41);
            btnXacnhan.TabIndex = 34;
            btnXacnhan.Text = "Xác nhận đóng tiền";
            btnXacnhan.UseVisualStyleBackColor = true;
            btnXacnhan.Click += btnXacnhan_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(865, 38);
            label3.Name = "label3";
            label3.Size = new Size(185, 25);
            label3.TabIndex = 33;
            label3.Text = "Đóng tiền cho tháng :";
            // 
            // checkedList_DongTien
            // 
            checkedList_DongTien.FormattingEnabled = true;
            checkedList_DongTien.Items.AddRange(new object[] { "Tháng 1", "Tháng 2", "Tháng 3", "Tháng 4", "Tháng 5", "Tháng 6", "Tháng 7", "Tháng 8", "Tháng 9", "Tháng 10", "Tháng 11", "Tháng 12" });
            checkedList_DongTien.Location = new Point(879, 66);
            checkedList_DongTien.Name = "checkedList_DongTien";
            checkedList_DongTien.Size = new Size(142, 116);
            checkedList_DongTien.TabIndex = 32;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(409, 40);
            label2.Name = "label2";
            label2.Size = new Size(145, 25);
            label2.TabIndex = 27;
            label2.Text = "Số tiền đã nhận :";
            // 
            // textsotiennhan
            // 
            textsotiennhan.Location = new Point(560, 40);
            textsotiennhan.Name = "textsotiennhan";
            textsotiennhan.Size = new Size(286, 31);
            textsotiennhan.TabIndex = 26;
            // 
            // cobtimkiem
            // 
            cobtimkiem.FormattingEnabled = true;
            cobtimkiem.Location = new Point(849, 235);
            cobtimkiem.Name = "cobtimkiem";
            cobtimkiem.Size = new Size(285, 33);
            cobtimkiem.TabIndex = 25;
            cobtimkiem.SelectedIndexChanged += cobtimkiem_SelectedIndexChanged;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(707, 235);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(120, 41);
            btnTimKiem.TabIndex = 24;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // txttimkiem
            // 
            txttimkiem.Location = new Point(109, 237);
            txttimkiem.Name = "txttimkiem";
            txttimkiem.Size = new Size(382, 31);
            txttimkiem.TabIndex = 23;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(10, 243);
            label10.Name = "label10";
            label10.Size = new Size(93, 25);
            label10.TabIndex = 22;
            label10.Text = "Tìm kiếm :";
            // 
            // CapNhatDongTien
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1402, 819);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "CapNhatDongTien";
            Text = "CapNhatDongTien";
            Load += CapNhatDongTien_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private TextBox txthoten;
        private Label label8;
        private TextBox txtlop;
        private Label label7;
        private TextBox txtsdt;
        private Label label5;
        private Button btnThoat;
        private Label label1;
        private TextBox txtmssv;
        private DataGridView dataGridView;
        private GroupBox groupBox2;
        private GroupBox groupBox1;
        private Label label2;
        private TextBox textsotiennhan;
        private ComboBox cobtimkiem;
        private Button btnTimKiem;
        private TextBox txttimkiem;
        private Label label10;
        private Label label3;
        private CheckedListBox checkedList_DongTien;
        private Button btnXacnhan;
        private Label label4;
        private TextBox txtTienNo;
        private CheckBox checkSVno;
        private DataGridViewTextBoxColumn MSSV;
        private DataGridViewTextBoxColumn HoTen;
        private DataGridViewTextBoxColumn Lop;
        private DataGridViewTextBoxColumn SDT;
        private DataGridViewTextBoxColumn NgayVao;
        private DataGridViewTextBoxColumn MaPhong;
        private DataGridViewTextBoxColumn TrangThaiTienPhong;
    }
}