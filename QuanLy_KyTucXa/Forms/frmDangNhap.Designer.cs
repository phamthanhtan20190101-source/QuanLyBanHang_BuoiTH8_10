namespace QuanLy_KyTucXa.Forms
{
    partial class frmDangNhap
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
            label1 = new Label();
            txtTenDangNhap = new TextBox();
            btnDangNhap = new Button();
            checkHienMK = new CheckBox();
            label2 = new Label();
            label3 = new Label();
            txtMatKhau = new TextBox();
            btnHuyBo = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(211, 19);
            label1.Name = "label1";
            label1.Size = new Size(166, 36);
            label1.TabIndex = 0;
            label1.Text = "Đăng nhập";
            // 
            // txtTenDangNhap
            // 
            txtTenDangNhap.Location = new Point(46, 100);
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.Size = new Size(499, 31);
            txtTenDangNhap.TabIndex = 1;
            // 
            // btnDangNhap
            // 
            btnDangNhap.Location = new Point(46, 293);
            btnDangNhap.Name = "btnDangNhap";
            btnDangNhap.Size = new Size(155, 44);
            btnDangNhap.TabIndex = 4;
            btnDangNhap.Text = "Đăng nhập";
            btnDangNhap.UseVisualStyleBackColor = true;
            btnDangNhap.Click += btnDangNhap_Click;
            // 
            // checkHienMK
            // 
            checkHienMK.AutoSize = true;
            checkHienMK.Location = new Point(392, 246);
            checkHienMK.Name = "checkHienMK";
            checkHienMK.Size = new Size(153, 29);
            checkHienMK.TabIndex = 3;
            checkHienMK.Text = "Hiện mật khẩu";
            checkHienMK.UseVisualStyleBackColor = true;
            checkHienMK.CheckedChanged += checkHienMK_CheckedChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(46, 62);
            label2.Name = "label2";
            label2.Size = new Size(138, 25);
            label2.TabIndex = 0;
            label2.Text = "Tên đăng nhập :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(46, 157);
            label3.Name = "label3";
            label3.Size = new Size(100, 25);
            label3.TabIndex = 0;
            label3.Text = "Mật khẩu : ";
            // 
            // txtMatKhau
            // 
            txtMatKhau.Location = new Point(46, 195);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.PasswordChar = '*';
            txtMatKhau.Size = new Size(499, 31);
            txtMatKhau.TabIndex = 2;
            txtMatKhau.KeyDown += txtMatKhau_KeyDown;
            // 
            // btnHuyBo
            // 
            btnHuyBo.Location = new Point(390, 293);
            btnHuyBo.Name = "btnHuyBo";
            btnHuyBo.Size = new Size(155, 44);
            btnHuyBo.TabIndex = 5;
            btnHuyBo.Text = "Hủy bỏ";
            btnHuyBo.UseVisualStyleBackColor = true;
            btnHuyBo.Click += btnHuyBo_Click;
            // 
            // frmDangNhap
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(593, 370);
            Controls.Add(btnHuyBo);
            Controls.Add(label3);
            Controls.Add(txtMatKhau);
            Controls.Add(label2);
            Controls.Add(checkHienMK);
            Controls.Add(btnDangNhap);
            Controls.Add(txtTenDangNhap);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmDangNhap";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmDangNhap";
            Load += frmDangNhap_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnDangNhap;
        private CheckBox checkHienMK;
        private Label label2;
        private Label label3;
        private Button btnHuyBo;
        public TextBox txtMatKhau;
        public TextBox txtTenDangNhap;
    }
}