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
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text) || string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tài khoản và mật khẩu!");
                return;
            }

            using (var db = new QuanLy_KyTucXa.Data.QLKTXDbContext())
            {
                // --- PHẦN MỚI THÊM: BĂM MẬT KHẨU TRƯỚC KHI TÌM KIẾM ---
                string matKhauGoVao = MaHoaHelper.HashPassword(txtMatKhau.Text);

                // Kiểm tra tài khoản trong CSDL (so sánh với mật khẩu ĐÃ BĂM)
                var taiKhoan = db.TaiKhoans.FirstOrDefault(tk => tk.TenTaiKhoan == txtTenDangNhap.Text && tk.MatKhau == matKhauGoVao);
                // -----------------------------------------------------

                if (taiKhoan != null)
                {
                    // Lưu thông tin vào biến static của frmMain để các Form khác dùng chung
                    frmMain.MaNguoiDungHienTai = taiKhoan.TenTaiKhoan;
                    frmMain.QuyenHienTai = taiKhoan.Quyen;

                    SystemLog.GhiNhatKy("Đăng nhập", $"Tài khoản {taiKhoan.TenTaiKhoan} đăng nhập vào hệ thống");

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.Cancel;
        }

        private void txtMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDangNhap_Click(sender, e);
            }
        }

        private void checkHienMK_CheckedChanged(object sender, EventArgs e)
        {
            if (checkHienMK.Checked)
            {
                // Khi tick vào: Bỏ ký tự che giấu đi để hiện mật khẩu
                txtMatKhau.PasswordChar = '\0';
            }
            else
            {
                // Khi bỏ tick: Dùng lại dấu sao '*' để che mật khẩu lại
                txtMatKhau.PasswordChar = '*';
            }
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {

        }
    }
}