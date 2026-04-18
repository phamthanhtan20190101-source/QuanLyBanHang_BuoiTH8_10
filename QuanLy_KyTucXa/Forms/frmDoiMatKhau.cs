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
    public partial class frmDoiMatKhau : Form
    {
        QLKTXDbContext context = new QLKTXDbContext();
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMatKhauCu.Text) ||
                string.IsNullOrWhiteSpace(txtMatKhauMoi.Text) ||
                string.IsNullOrWhiteSpace(txtXacNhanMK.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Kiểm tra mật khẩu mới và xác nhận
            if (txtMatKhauMoi.Text != txtXacNhanMK.Text)
            {
                MessageBox.Show("Mật khẩu mới và xác nhận không trùng khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtXacNhanMK.Focus();
                return;
            }

            try
            {
                // 3. Lấy tên người dùng đang đăng nhập từ Form Main
                string tenUser = frmMain.MaNguoiDungHienTai;
                var taiKhoan = context.TaiKhoans.FirstOrDefault(tk => tk.TenTaiKhoan == tenUser);

                if (taiKhoan != null)
                {
                    // KIỂM TRA MẬT KHẨU CŨ (Băm cái cũ gõ vào để so sánh)
                    string mkCuDaBam = MaHoaHelper.HashPassword(txtMatKhauCu.Text);
                    if (taiKhoan.MatKhau != mkCuDaBam)
                    {
                        MessageBox.Show("Mật khẩu cũ không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtMatKhauCu.Focus();
                        return;
                    }

                    // LƯU MẬT KHẨU MỚI (Băm cái mới rồi mới lưu)
                    taiKhoan.MatKhau = MaHoaHelper.HashPassword(txtMatKhauMoi.Text);
                    context.SaveChanges();

                    SystemLog.GhiNhatKy("Đổi mật khẩu", $"Tài khoản {tenUser} vừa thay đổi mật khẩu");

                    MessageBox.Show("Thay đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin tài khoản!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
    

