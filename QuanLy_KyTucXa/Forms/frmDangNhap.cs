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
            this.DialogResult = DialogResult.OK;
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
    }
}
