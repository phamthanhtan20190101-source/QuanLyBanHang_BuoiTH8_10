namespace QuanLy_KyTucXa.Forms
{
    partial class frmDoiMatKhau
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
            label3 = new Label();
            txtMatKhauCu = new TextBox();
            label1 = new Label();
            txtMatKhauMoi = new TextBox();
            btnLuu = new Button();
            btnHuy = new Button();
            label2 = new Label();
            txtXacNhanMK = new TextBox();
            SuspendLayout();
            // 
            // label3 (Mật khẩu cũ)
            // 
            label3.AutoSize = true;
            label3.Location = new Point(24, 25);
            label3.Name = "label3";
            label3.Size = new Size(118, 25);
            label3.TabIndex = 0;
            label3.Text = "Mật khẩu cũ :";
            // 
            // txtMatKhauCu
            // 
            txtMatKhauCu.Location = new Point(24, 63);
            txtMatKhauCu.Name = "txtMatKhauCu";
            txtMatKhauCu.PasswordChar = '*';
            txtMatKhauCu.Size = new Size(499, 31);
            txtMatKhauCu.TabIndex = 1;
            // 
            // label1 (Mật khẩu mới)
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 115);
            label1.Name = "label1";
            label1.Size = new Size(131, 25);
            label1.TabIndex = 2;
            label1.Text = "Mật khẩu mới :";
            // 
            // txtMatKhauMoi
            // 
            txtMatKhauMoi.Location = new Point(24, 153);
            txtMatKhauMoi.Name = "txtMatKhauMoi";
            txtMatKhauMoi.PasswordChar = '*';
            txtMatKhauMoi.Size = new Size(499, 31);
            txtMatKhauMoi.TabIndex = 3;
            // 
            // label2 (Xác nhận)
            // 
            label2.AutoSize = true;
            label2.Location = new Point(24, 210);
            label2.Name = "label2";
            label2.Size = new Size(213, 25);
            label2.TabIndex = 4;
            label2.Text = "Xác nhận mật khẩu mới : ";
            // 
            // txtXacNhanMK
            // 
            txtXacNhanMK.Location = new Point(24, 248);
            txtXacNhanMK.Name = "txtXacNhanMK";
            txtXacNhanMK.PasswordChar = '*';
            txtXacNhanMK.Size = new Size(499, 31);
            txtXacNhanMK.TabIndex = 5;
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(90, 320);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(160, 45);
            btnLuu.TabIndex = 6;
            btnLuu.Text = "Lưu thay đổi";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += new EventHandler(btnLuu_Click); // NỐI SỰ KIỆN
            // 
            // btnHuy
            // 
            btnHuy.Location = new Point(280, 320);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(140, 45);
            btnHuy.TabIndex = 7;
            btnHuy.Text = "Hủy bỏ";
            btnHuy.UseVisualStyleBackColor = true;
            btnHuy.Click += new EventHandler(btnHuy_Click); // NỐI SỰ KIỆN
            // 
            // frmDoiMatKhau
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(578, 423);
            Controls.Add(label2);
            Controls.Add(txtXacNhanMK);
            Controls.Add(btnHuy);
            Controls.Add(btnLuu);
            Controls.Add(label1);
            Controls.Add(txtMatKhauMoi);
            Controls.Add(label3);
            Controls.Add(txtMatKhauCu);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmDoiMatKhau";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Thay đổi mật khẩu";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private TextBox txtMatKhauCu;
        private Label label1;
        private TextBox txtMatKhauMoi;
        private Button btnLuu;
        private Button btnHuy;
        private Label label2;
        private TextBox txtXacNhanMK;
    }
}