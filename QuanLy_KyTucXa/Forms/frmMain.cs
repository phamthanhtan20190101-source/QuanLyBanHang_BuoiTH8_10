using QuanLy_KyTucXa.Data;
using System;
using System.Linq;
using System.Windows.Forms;

namespace QuanLy_KyTucXa.Forms
{
    public partial class frmMain : Form
    {
        // 1. KHAI BÁO BIẾN TĨNH VÀ CONTEXT
        public static string MaNguoiDungHienTai = "";
        public static string QuyenHienTai = "";
        QLKTXDbContext context = new QLKTXDbContext();

        // 2. KHAI BÁO CÁC BIẾN FORM CON
        Form frmThemSinhVien = null;
        Form frmToaNha = null;
        CapNhatDongTien CapNhatDongTien = null;
        QuanLy_KyTucXa.Reports.frmThongKeLichSuDongTien formThongKeLichSu = null;
        frmSinhVien formThongTinCaNhan = null;
        QuanLy_KyTucXa.Reports.frmThongKeHoaDon formThongKeHoaDon = null;

        public frmMain()
        {
            InitializeComponent();
            ChuaDangNhap();
            DongBoMatKhauCu();// Khóa hệ thống khi vừa mở phần mềm
        }

        // --- HÀM 1: TRẠNG THÁI CHƯA ĐĂNG NHẬP (XÓA BỎ DƯ THỪA) ---
        private void ChuaDangNhap()
        {
            quảnLýToolStripMenuItem.Enabled = false;
            báoCáoThốngKêToolStripMenuItem.Enabled = false;
            thôngTinSinhViênToolStripMenuItem.Enabled = false;

            mnuDangNhap.Enabled = true;
            mnuDangXuat.Enabled = false;
            mnuDoiMatKhau.Enabled = false;

            lblTrangThai.Text = "Chưa đăng nhập";
        }

        // --- HÀM 2: PHÂN QUYỀN VÀ HIỆN TÊN (ĐÃ SỬA ĐỂ HIỆN TÊN THẬT) ---
        private void PhanQuyenHanh()
        {
            // 1. Mặc định gán tên hiển thị là mã số trước
            string tenHienThi = MaNguoiDungHienTai;

            // 2. Tìm tên thật tùy theo quyền hạn
            if (QuyenHienTai == "SinhVien")
            {
                var sv = context.SinhViens.Find(MaNguoiDungHienTai);
                if (sv != null) tenHienThi = sv.HoTen;
            }
            else if (QuyenHienTai == "QuanLy")
            {
                
                var nv = context.QuanLys.Find(MaNguoiDungHienTai);
                if (nv != null) tenHienThi = nv.HoTenQuanLy; // Giả sử cột tên là HoTen
            }

            // 3. Phân quyền menu và dán tên lên StatusStrip
            if (QuyenHienTai == "QuanLy")
            {
                quảnLýToolStripMenuItem.Enabled = true;
                báoCáoThốngKêToolStripMenuItem.Enabled = true;
                thôngTinSinhViênToolStripMenuItem.Enabled = true;

                lblTrangThai.Text = "Quyền: Quản lý | Tài khoản: " + tenHienThi;
            }
            else if (QuyenHienTai == "SinhVien")
            {
                quảnLýToolStripMenuItem.Enabled = false;
                báoCáoThốngKêToolStripMenuItem.Enabled = false;
                thôngTinSinhViênToolStripMenuItem.Enabled = true;

                lblTrangThai.Text = "Quyền: Sinh viên | Tài khoản: " + tenHienThi;
            }

            mnuDangNhap.Enabled = false;
            mnuDangXuat.Enabled = true;
            mnuDoiMatKhau.Enabled = true;
        }

        // --- XỬ LÝ SỰ KIỆN HỆ THỐNG ---

        private void mnuDangNhap_Click(object sender, EventArgs e)
        {
            frmDangNhap dangNhap = new frmDangNhap();
            if (dangNhap.ShowDialog() == DialogResult.OK)
            {
                PhanQuyenHanh(); // Chạy hàm phân quyền duy nhất
            }
        }

        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MaNguoiDungHienTai = "";
                QuyenHienTai = "";
                foreach (Form child in this.MdiChildren) { child.Close(); }
                ChuaDangNhap();
            }
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuDoiMatKhau_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau formDoiMK = new frmDoiMatKhau();
            formDoiMK.ShowDialog();
        }

        // --- MỞ CÁC FORM CON (GIỮ NGUYÊN LOGIC CHUẨN) ---

        private void mnuThemSv_Click(object sender, EventArgs e)
        {
            if (frmThemSinhVien == null || frmThemSinhVien.IsDisposed)
            {
                frmThemSinhVien = new frmThemSinhVien();
                frmThemSinhVien.MdiParent = this;
                frmThemSinhVien.Show();
            }
            else frmThemSinhVien.Activate();
        }

        private void mnuthemphong_Click(object sender, EventArgs e)
        {
            if (frmToaNha == null || frmToaNha.IsDisposed)
            {
                frmToaNha = new frmToaNha();
                frmToaNha.MdiParent = this;
                frmToaNha.Show();
            }
            else frmToaNha.Activate();
        }

        private void mnuCapnhattienphong_Click(object sender, EventArgs e)
        {
            if (CapNhatDongTien == null || CapNhatDongTien.IsDisposed)
            {
                CapNhatDongTien = new CapNhatDongTien();
                CapNhatDongTien.MdiParent = this;
                CapNhatDongTien.Show();
            }
            else CapNhatDongTien.Activate();
        }

        private void mnulichsudongtien_Click(object sender, EventArgs e)
        {
            if (formThongKeLichSu == null || formThongKeLichSu.IsDisposed)
            {
                formThongKeLichSu = new QuanLy_KyTucXa.Reports.frmThongKeLichSuDongTien();
                formThongKeLichSu.MdiParent = this;
                formThongKeLichSu.Show();
            }
            else formThongKeLichSu.Activate();
        }

        private void mnuThongtincanhan_Click(object sender, EventArgs e)
        {
            if (formThongTinCaNhan == null || formThongTinCaNhan.IsDisposed)
            {
                formThongTinCaNhan = new frmSinhVien();
                formThongTinCaNhan.MdiParent = this;
                formThongTinCaNhan.Show();
            }
            else formThongTinCaNhan.Activate();
        }

        private void mnuThongKeHoaDon_Click(object sender, EventArgs e)
        {
            if (formThongKeHoaDon == null || formThongKeHoaDon.IsDisposed)
            {
                formThongKeHoaDon = new QuanLy_KyTucXa.Reports.frmThongKeHoaDon();
                formThongKeHoaDon.MdiParent = this;
                formThongKeHoaDon.Show();
            }
            else formThongKeHoaDon.Activate();
        }

        private void DongBoMatKhauCu()
        {
            try
            {
                var danhSachTaiKhoan = context.TaiKhoans.ToList();
                int soTaiKhoanDuocCapNhat = 0;

                foreach (var tk in danhSachTaiKhoan)
                {
                    // Nếu độ dài < 64 tức là mật khẩu thường chưa được băm
                    if (tk.MatKhau != null && tk.MatKhau.Length < 64)
                    {
                        tk.MatKhau = MaHoaHelper.HashPassword(tk.MatKhau);
                        soTaiKhoanDuocCapNhat++;
                    }
                }

                if (soTaiKhoanDuocCapNhat > 0)
                {
                    context.SaveChanges();
                    MessageBox.Show($"Đã nâng cấp bảo mật thành công cho {soTaiKhoanDuocCapNhat} tài khoản cũ!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex) { }
        }
    }
}