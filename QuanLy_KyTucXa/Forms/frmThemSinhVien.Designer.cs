namespace QuanLy_KyTucXa.Forms
{
    partial class frmThemSinhVien
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            dataGridView = new DataGridView();
            MSSV = new DataGridViewTextBoxColumn();
            HoTen = new DataGridViewTextBoxColumn();
            Lop = new DataGridViewTextBoxColumn();
            QueQuan = new DataGridViewTextBoxColumn();
            SDT = new DataGridViewTextBoxColumn();
            NgaySinh = new DataGridViewTextBoxColumn();
            GioiTinh = new DataGridViewTextBoxColumn();
            NgayVao = new DataGridViewTextBoxColumn();
            MaPhong = new DataGridViewTextBoxColumn();
            groupBox2 = new GroupBox();
            groupBox1 = new GroupBox();
            btnXuat = new Button();
            btnNhap = new Button();
            datengayvao = new DateTimePicker();
            datengaysinh = new DateTimePicker();
            cobgioitinh = new ComboBox();
            cobmaphong = new ComboBox();
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
            btnHuyBo = new Button();
            btnLuu = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            btnThem = new Button();
            label1 = new Label();
            txtmssv = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { MSSV, HoTen, Lop, QueQuan, SDT, NgaySinh, GioiTinh, NgayVao, MaPhong });
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.Location = new Point(3, 27);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 62;
            dataGridView.Size = new Size(1311, 524);
            dataGridView.TabIndex = 0;
            dataGridView.CellClick += dataGridView_CellClick;
            // 
            // MSSV
            // 
            MSSV.DataPropertyName = "MSSV";
            MSSV.HeaderText = "Mã Số Sinh Viên";
            MSSV.MinimumWidth = 8;
            MSSV.Name = "MSSV";
            // 
            // HoTen
            // 
            HoTen.DataPropertyName = "HoTen";
            HoTen.HeaderText = "Họ Tên";
            HoTen.MinimumWidth = 8;
            HoTen.Name = "HoTen";
            // 
            // Lop
            // 
            Lop.DataPropertyName = "Lop";
            Lop.HeaderText = "Lớp";
            Lop.MinimumWidth = 8;
            Lop.Name = "Lop";
            // 
            // QueQuan
            // 
            QueQuan.DataPropertyName = "QueQuan";
            QueQuan.HeaderText = "Quê Quán";
            QueQuan.MinimumWidth = 8;
            QueQuan.Name = "QueQuan";
            // 
            // SDT
            // 
            SDT.DataPropertyName = "SDT";
            SDT.HeaderText = "Số Điện Thoại";
            SDT.MinimumWidth = 8;
            SDT.Name = "SDT";
            // 
            // NgaySinh
            // 
            NgaySinh.DataPropertyName = "NgaySinh";
            dataGridViewCellStyle3.Format = "dd/MM/yyyy";
            NgaySinh.DefaultCellStyle = dataGridViewCellStyle3;
            NgaySinh.HeaderText = "Ngày Sinh";
            NgaySinh.MinimumWidth = 8;
            NgaySinh.Name = "NgaySinh";
            // 
            // GioiTinh
            // 
            GioiTinh.DataPropertyName = "GioiTinh";
            GioiTinh.HeaderText = "Giới Tính";
            GioiTinh.MinimumWidth = 8;
            GioiTinh.Name = "GioiTinh";
            // 
            // NgayVao
            // 
            NgayVao.DataPropertyName = "NgayVao";
            dataGridViewCellStyle4.Format = "dd/MM/yyyy";
            NgayVao.DefaultCellStyle = dataGridViewCellStyle4;
            NgayVao.HeaderText = "Ngày Vào";
            NgayVao.MinimumWidth = 8;
            NgayVao.Name = "NgayVao";
            // 
            // MaPhong
            // 
            MaPhong.DataPropertyName = "MaPhong";
            MaPhong.HeaderText = "Mã Phòng";
            MaPhong.MinimumWidth = 8;
            MaPhong.Name = "MaPhong";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dataGridView);
            groupBox2.Location = new Point(5, 300);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1317, 554);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh sách sinh viên";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnXuat);
            groupBox1.Controls.Add(btnNhap);
            groupBox1.Controls.Add(datengayvao);
            groupBox1.Controls.Add(datengaysinh);
            groupBox1.Controls.Add(cobgioitinh);
            groupBox1.Controls.Add(cobmaphong);
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
            groupBox1.Controls.Add(btnHuyBo);
            groupBox1.Controls.Add(btnLuu);
            groupBox1.Controls.Add(btnXoa);
            groupBox1.Controls.Add(btnSua);
            groupBox1.Controls.Add(btnThem);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtmssv);
            groupBox1.Location = new Point(8, 13);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1311, 290);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin sinh viên";
            // 
            // btnXuat
            // 
            btnXuat.Location = new Point(1046, 240);
            btnXuat.Name = "btnXuat";
            btnXuat.Size = new Size(236, 41);
            btnXuat.TabIndex = 23;
            btnXuat.Text = "Xuất file Excel";
            btnXuat.UseVisualStyleBackColor = true;
            btnXuat.Click += btnXuat_Click;
            // 
            // btnNhap
            // 
            btnNhap.Location = new Point(786, 240);
            btnNhap.Name = "btnNhap";
            btnNhap.Size = new Size(236, 41);
            btnNhap.TabIndex = 22;
            btnNhap.Text = "Nhập file Excel";
            btnNhap.UseVisualStyleBackColor = true;
            btnNhap.Click += btnNhap_Click;
            // 
            // datengayvao
            // 
            datengayvao.CustomFormat = "dd/MM/yyyy";
            datengayvao.Format = DateTimePickerFormat.Custom;
            datengayvao.Location = new Point(997, 150);
            datengayvao.MaxDate = new DateTime(2100, 12, 31, 0, 0, 0, 0);
            datengayvao.MinDate = new DateTime(2020, 1, 1, 0, 0, 0, 0);
            datengayvao.Name = "datengayvao";
            datengayvao.Size = new Size(285, 31);
            datengayvao.TabIndex = 21;
            // 
            // datengaysinh
            // 
            datengaysinh.CustomFormat = "dd/MM/yyyy";
            datengaysinh.Format = DateTimePickerFormat.Custom;
            datengaysinh.Location = new Point(997, 95);
            datengaysinh.MaxDate = new DateTime(2100, 12, 31, 0, 0, 0, 0);
            datengaysinh.MinDate = new DateTime(2000, 1, 1, 0, 0, 0, 0);
            datengaysinh.Name = "datengaysinh";
            datengaysinh.Size = new Size(285, 31);
            datengaysinh.TabIndex = 21;
            // 
            // cobgioitinh
            // 
            cobgioitinh.FormattingEnabled = true;
            cobgioitinh.Items.AddRange(new object[] { "Nam", "Nữ" });
            cobgioitinh.Location = new Point(537, 140);
            cobgioitinh.Name = "cobgioitinh";
            cobgioitinh.Size = new Size(286, 33);
            cobgioitinh.TabIndex = 20;
            cobgioitinh.SelectedIndexChanged += cobgioitinh_SelectedIndexChanged;
            // 
            // cobmaphong
            // 
            cobmaphong.FormattingEnabled = true;
            cobmaphong.Location = new Point(996, 38);
            cobmaphong.Name = "cobmaphong";
            cobmaphong.Size = new Size(286, 33);
            cobmaphong.TabIndex = 20;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(880, 97);
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
            label7.Location = new Point(405, 93);
            label7.Name = "label7";
            label7.Size = new Size(126, 25);
            label7.TabIndex = 14;
            label7.Text = "Số điện thoại :";
            // 
            // txtquequan
            // 
            txtquequan.Location = new Point(537, 40);
            txtquequan.Name = "txtquequan";
            txtquequan.Size = new Size(286, 31);
            txtquequan.TabIndex = 15;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(880, 46);
            label6.Name = "label6";
            label6.Size = new Size(103, 25);
            label6.TabIndex = 12;
            label6.Text = "Mã Phòng :";
            // 
            // txtsdt
            // 
            txtsdt.Location = new Point(537, 87);
            txtsdt.MaxLength = 10;
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
            label4.Location = new Point(405, 148);
            label4.Name = "label4";
            label4.Size = new Size(90, 25);
            label4.TabIndex = 8;
            label4.Text = "Giới Tính :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(880, 156);
            label3.Name = "label3";
            label3.Size = new Size(97, 25);
            label3.TabIndex = 6;
            label3.Text = "Ngày vào :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(405, 40);
            label2.Name = "label2";
            label2.Size = new Size(99, 25);
            label2.TabIndex = 4;
            label2.Text = "Quê quán :";
            // 
            // btnHuyBo
            // 
            btnHuyBo.Location = new Point(584, 240);
            btnHuyBo.Name = "btnHuyBo";
            btnHuyBo.Size = new Size(120, 41);
            btnHuyBo.TabIndex = 3;
            btnHuyBo.Text = "Hủy bỏ";
            btnHuyBo.UseVisualStyleBackColor = true;
            btnHuyBo.Click += btnHuyBo_Click;
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(443, 240);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(120, 41);
            btnLuu.TabIndex = 3;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(302, 240);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(120, 41);
            btnXoa.TabIndex = 3;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(159, 240);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(120, 41);
            btnSua.TabIndex = 3;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(11, 240);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(120, 41);
            btnThem.TabIndex = 3;
            btnThem.Text = "Thêm ";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
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
            // frmThemSinhVien
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1334, 866);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "frmThemSinhVien";
            Text = "frmThêmSinhViên";
            Load += frmThemSinhVien_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView;
        private GroupBox groupBox2;
        private GroupBox groupBox1;
        private Button btnHuyBo;
        private Button btnLuu;
        private Button btnXoa;
        private Button btnSua;
        private Button btnThem;
        private Label label1;
        private TextBox txtmssv;
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
        private DateTimePicker datengayvao;
        private DateTimePicker datengaysinh;
        private ComboBox cobgioitinh;
        private ComboBox cobmaphong;
        private DataGridViewTextBoxColumn MSSV;
        private DataGridViewTextBoxColumn HoTen;
        private DataGridViewTextBoxColumn Lop;
        private DataGridViewTextBoxColumn QueQuan;
        private DataGridViewTextBoxColumn SDT;
        private DataGridViewTextBoxColumn NgaySinh;
        private DataGridViewTextBoxColumn GioiTinh;
        private DataGridViewTextBoxColumn NgayVao;
        private DataGridViewTextBoxColumn MaPhong;
        private Button btnXuat;
        private Button btnNhap;
    }
}