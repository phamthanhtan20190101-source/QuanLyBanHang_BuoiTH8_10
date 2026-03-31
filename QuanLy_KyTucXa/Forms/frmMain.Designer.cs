namespace QuanLy_KyTucXa.Forms
{
    partial class frmMain
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
            menuStrip1 = new MenuStrip();
            nmuHeThong = new ToolStripMenuItem();
            mnuDangNhap = new ToolStripMenuItem();
            mnuDangXuat = new ToolStripMenuItem();
            mnuDoiMatKhau = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            mnuThoat = new ToolStripMenuItem();
            quảnLýToolStripMenuItem = new ToolStripMenuItem();
            mnuThemSv = new ToolStripMenuItem();
            mnuthemphong = new ToolStripMenuItem();
            mnuCapnhattienphong = new ToolStripMenuItem();
            statusStrip = new StatusStrip();
            lblTrangThai = new ToolStripStatusLabel();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            báoCáoThốngKêToolStripMenuItem = new ToolStripMenuItem();
            mnulichsudongtien = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { nmuHeThong, quảnLýToolStripMenuItem, báoCáoThốngKêToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1135, 33);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // nmuHeThong
            // 
            nmuHeThong.DropDownItems.AddRange(new ToolStripItem[] { mnuDangNhap, mnuDangXuat, mnuDoiMatKhau, toolStripSeparator1, mnuThoat });
            nmuHeThong.Name = "nmuHeThong";
            nmuHeThong.Size = new Size(106, 29);
            nmuHeThong.Text = "Hệ Thống";
            // 
            // mnuDangNhap
            // 
            mnuDangNhap.Name = "mnuDangNhap";
            mnuDangNhap.Size = new Size(224, 34);
            mnuDangNhap.Text = "Đăng nhập";
            mnuDangNhap.Click += mnuDangNhap_Click;
            // 
            // mnuDangXuat
            // 
            mnuDangXuat.Name = "mnuDangXuat";
            mnuDangXuat.Size = new Size(224, 34);
            mnuDangXuat.Text = "Đăng xuất";
            mnuDangXuat.Click += mnuDangXuat_Click;
            // 
            // mnuDoiMatKhau
            // 
            mnuDoiMatKhau.Name = "mnuDoiMatKhau";
            mnuDoiMatKhau.Size = new Size(224, 34);
            mnuDoiMatKhau.Text = "Đổi mật khẩu";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(221, 6);
            // 
            // mnuThoat
            // 
            mnuThoat.Name = "mnuThoat";
            mnuThoat.ShortcutKeys = Keys.Alt | Keys.F4;
            mnuThoat.Size = new Size(224, 34);
            mnuThoat.Text = "Thoát";
            mnuThoat.Click += mnuThoat_Click;
            // 
            // quảnLýToolStripMenuItem
            // 
            quảnLýToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { mnuThemSv, mnuthemphong, mnuCapnhattienphong });
            quảnLýToolStripMenuItem.Name = "quảnLýToolStripMenuItem";
            quảnLýToolStripMenuItem.Size = new Size(89, 29);
            quảnLýToolStripMenuItem.Text = "Quản lý";
            // 
            // mnuThemSv
            // 
            mnuThemSv.Name = "mnuThemSv";
            mnuThemSv.Size = new Size(277, 34);
            mnuThemSv.Text = "Thêm sinh viên";
            mnuThemSv.Click += mnuThemSv_Click;
            // 
            // mnuthemphong
            // 
            mnuthemphong.Name = "mnuthemphong";
            mnuthemphong.Size = new Size(277, 34);
            mnuthemphong.Text = "Thêm phòng";
            mnuthemphong.Click += mnuthemphong_Click;
            // 
            // mnuCapnhattienphong
            // 
            mnuCapnhattienphong.Name = "mnuCapnhattienphong";
            mnuCapnhattienphong.Size = new Size(277, 34);
            mnuCapnhattienphong.Text = "Cập nhật tiền phòng";
            mnuCapnhattienphong.Click += mnuCapnhattienphong_Click;
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new Size(24, 24);
            statusStrip.Items.AddRange(new ToolStripItem[] { lblTrangThai, toolStripStatusLabel1 });
            statusStrip.Location = new Point(0, 553);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(1135, 32);
            statusStrip.TabIndex = 2;
            statusStrip.Text = "Chưa đăng nhập.";
            // 
            // lblTrangThai
            // 
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(148, 25);
            lblTrangThai.Text = "Chưa đăng nhập.";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(972, 25);
            toolStripStatusLabel1.Spring = true;
            toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // báoCáoThốngKêToolStripMenuItem
            // 
            báoCáoThốngKêToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { mnulichsudongtien });
            báoCáoThốngKêToolStripMenuItem.Name = "báoCáoThốngKêToolStripMenuItem";
            báoCáoThốngKêToolStripMenuItem.Size = new Size(186, 29);
            báoCáoThốngKêToolStripMenuItem.Text = "Báo Cáo - Thống Kê";
            // 
            // mnulichsudongtien
            // 
            mnulichsudongtien.Name = "mnulichsudongtien";
            mnulichsudongtien.Size = new Size(325, 34);
            mnulichsudongtien.Text = "Thống kê lịch sử đóng tiền";
            mnulichsudongtien.Click += mnulichsudongtien_Click;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1135, 585);
            Controls.Add(statusStrip);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmMain";
            WindowState = FormWindowState.Maximized;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private StatusStrip statusStrip;
        private ToolStripMenuItem nmuHeThong;
        private ToolStripMenuItem mnuDangNhap;
        private ToolStripMenuItem mnuDangXuat;
        private ToolStripMenuItem mnuDoiMatKhau;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem mnuThoat;
        private ToolStripMenuItem quảnLýToolStripMenuItem;
        private ToolStripMenuItem mnuThemSv;
        private ToolStripMenuItem mnuthemphong;
        private ToolStripMenuItem mnuCapnhattienphong;
        private ToolStripStatusLabel lblTrangThai;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripMenuItem báoCáoThốngKêToolStripMenuItem;
        private ToolStripMenuItem mnulichsudongtien;
    }
}