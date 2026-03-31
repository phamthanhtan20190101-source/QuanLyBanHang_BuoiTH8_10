using QuanLy_KyTucXa.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace QuanLy_KyTucXa.Forms
{
    public partial class frmMain : Form
    {
        QLKTXDbContext context = new QLKTXDbContext();
        frmDangNhap dangNhap = null;

        // Cập nhật lại các Form con của bạn (Tạm thời tôi để kiểu chung Form, bạn có thể đổi tên class sau)
        Form frmThemSinhVien = null;
        Form frmToaNha = null;
        CapNhatDongTien CapNhatDongTien = null;
        QuanLy_KyTucXa.Reports.frmThongKeLichSuDongTien formThongKeLichSu = null;

        string hoVaTenNhanVien = "";
        public frmMain()
        {
            InitializeComponent();
            ChuaDangNhap();
        }

        private void DangNhap()
        {
        LamLai:
            if (dangNhap == null || dangNhap.IsDisposed)
                dangNhap = new frmDangNhap();

            if (dangNhap.ShowDialog() == DialogResult.OK)
            {
                string tenDangNhap = dangNhap.txtTenDangNhap.Text.Trim();
                string matKhau = dangNhap.txtMatKhau.Text.Trim();

                if (tenDangNhap == "")
                {
                    MessageBox.Show("Tên đăng nhập không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dangNhap.txtTenDangNhap.Focus();
                    goto LamLai;
                }
                else if (matKhau == "")
                {
                    MessageBox.Show("Mật khẩu không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dangNhap.txtMatKhau.Focus();
                    goto LamLai;
                }
                else
                {
                    // Sửa lại thành t.TenTaiKhoan cho khớp với DB của bạn
                    var taiKhoan = context.TaiKhoans.Where(t => t.TenTaiKhoan == tenDangNhap).SingleOrDefault();

                    if (taiKhoan == null)
                    {
                        MessageBox.Show("Tên đăng nhập không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dangNhap.txtTenDangNhap.Focus();
                        goto LamLai;
                    }
                    if (taiKhoan.MatKhau == matKhau)
                    {
                        // ===== CODE MỚI: TÌM TÊN THẬT TỪ BẢNG QUẢN LÝ =====
                        if (taiKhoan.Quyen == "QuanLy")
                        {
                            // Dùng TenTaiKhoan (VD: QL001) để tìm trong bảng QuanLy
                            // Lưu ý: Sửa chữ context.QuanLys thành tên bảng Quản lý trong CSDL của bạn nếu khác
                            var thongTinQL = context.QuanLys.Where(q => q.MaQuanLy == taiKhoan.TenTaiKhoan).SingleOrDefault();

                            if (thongTinQL != null)
                            {
                                hoVaTenNhanVien = thongTinQL.HoTenQuanLy; // Lấy tên thật (VD: Vũ Thị Yên Vy)
                            }
                            else
                            {
                                hoVaTenNhanVien = taiKhoan.TenTaiKhoan; // Phòng hờ nếu không tìm thấy
                            }
                        }
                        else if (taiKhoan.Quyen == "Admin")
                        {
                            hoVaTenNhanVien = "Quản trị viên cấp cao"; // Hoặc để tên gì bạn muốn cho Admin
                        }
                        else
                        {
                            hoVaTenNhanVien = taiKhoan.TenTaiKhoan; // Các quyền khác
                        }
                        // ===================================================

                        // Phân quyền bằng chuỗi
                        if (taiKhoan.Quyen == "Admin" || taiKhoan.Quyen == "QuanLy")
                        {
                            QuyenQuanLy();
                        }
                        else if (taiKhoan.Quyen == "SinhVien")
                        {
                            QuyenNhanVien();
                        }
                        else
                        {
                            ChuaDangNhap();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dangNhap.txtMatKhau.Focus();
                        goto LamLai;
                    }
                }
            }
        }

        public void ChuaDangNhap()
        {
            mnuDangNhap.Enabled = true;

            mnuDangXuat.Enabled = false;
            mnuDoiMatKhau.Enabled = false;

            // Khóa nhóm Quản lý
            mnuThemSv.Enabled = false;
            mnuthemphong.Enabled = false;
            mnuCapnhattienphong.Enabled = false;

            //===== KHÓA BÁO CÁO THỐNG KÊ =====
            // Tên menu này lấy theo ảnh bạn gửi lúc nãy, nếu bạn đổi tên thì sửa lại cho đúng nhé
            mnulichsudongtien.Enabled = false;

            lblTrangThai.Text = "Chưa đăng nhập.";
        }

        public void QuyenQuanLy()
        {
            mnuDangNhap.Enabled = false;

            mnuDangXuat.Enabled = true;
            mnuDoiMatKhau.Enabled = true;

            // Quản lý được xài hết
            mnuThemSv.Enabled = true;
            mnuthemphong.Enabled = true;
            mnuCapnhattienphong.Enabled = true;

            lblTrangThai.Text = "Quản lý: " + hoVaTenNhanVien;
        }

        public void QuyenNhanVien()
        {
            mnuDangNhap.Enabled = false;

            mnuDangXuat.Enabled = true;
            mnuDoiMatKhau.Enabled = true;

            // Nhân viên KHÔNG được thêm phòng mới (Ví dụ về phân quyền)
            mnuthemphong.Enabled = false;

            // Nhân viên được phép cập nhật sinh viên và thu tiền
            mnuThemSv.Enabled = true;
            mnuCapnhattienphong.Enabled = true;

            lblTrangThai.Text = "Nhân viên: " + hoVaTenNhanVien;
        }

        private void hệThốngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mnuDangNhap_Click(object sender, EventArgs e)
        {
            DangNhap();
        }

        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                ChuaDangNhap(); // Đăng xuất xong thì khóa màn hình lại
            }
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuThemSv_Click(object sender, EventArgs e)
        {
            if (frmThemSinhVien == null || frmThemSinhVien.IsDisposed)
            {
                frmThemSinhVien = new frmThemSinhVien(); // Gọi tên class Form thêm sinh viên
                frmThemSinhVien.MdiParent = this;
                frmThemSinhVien.Show();
            }
            else
            {
                frmThemSinhVien.Activate();
            }
        }

        private void mnuthemphong_Click(object sender, EventArgs e)
        {
            if (frmToaNha == null || frmToaNha.IsDisposed)
            {
                frmToaNha = new frmToaNha(); // Gọi tên class Form thêm phòng
                frmToaNha.MdiParent = this;
                frmToaNha.Show();
            }
            else
            {
                frmToaNha.Activate();
            }
        }

        private void mnuCapnhattienphong_Click(object sender, EventArgs e)
        {
            if (CapNhatDongTien == null || CapNhatDongTien.IsDisposed)
            {
                CapNhatDongTien = new CapNhatDongTien(); // Gọi class Cập nhật đóng tiền của bạn
                CapNhatDongTien.MdiParent = this;
                CapNhatDongTien.Show();
            }
            else
            {
                CapNhatDongTien.Activate();
            }
        }

        private void mnulichsudongtien_Click(object sender, EventArgs e)
        {
            if (formThongKeLichSu == null || formThongKeLichSu.IsDisposed)
            {
                // Nếu form chưa được mở hoặc đã bị đóng -> Tạo mới và mở lên
                formThongKeLichSu = new QuanLy_KyTucXa.Reports.frmThongKeLichSuDongTien();
                formThongKeLichSu.MdiParent = this; // Đặt Form Main làm cha
                formThongKeLichSu.Show();
            }
            else
            {
                // Nếu form đang mở sẵn rồi -> Đưa nó nổi lên trên cùng
                formThongKeLichSu.Activate();
            }
        }
    }
}
