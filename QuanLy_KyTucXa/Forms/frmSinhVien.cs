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
    public partial class frmSinhVien : Form
    {
        QLKTXDbContext context = new QLKTXDbContext();
        private string mssvDangNhap;
        public frmSinhVien()
        {
            InitializeComponent();
            
        }

        private void frmSinhVien_Load(object sender, EventArgs e)
        {
            LoadThongTinSinhVien();
        }

        private void LoadThongTinSinhVien()
        {
            try
            {
                // Tìm sinh viên trong Database dựa vào MSSV
                mssvDangNhap = frmMain.MaNguoiDungHienTai;
                var sv = context.SinhViens.FirstOrDefault(s => s.MSSV == mssvDangNhap);

                if (sv != null)
                {
                    // Gán dữ liệu vào các TextBox (đã được set ReadOnly trong Designer)
                    txtmssv.Text = sv.MSSV;
                    txthoten.Text = sv.HoTen;
                    txtlop.Text = sv.Lop;
                    txtsdt.Text = sv.SDT;
                    txtquequan.Text = sv.QueQuan;
                    txtgioitinh.Text = sv.GioiTinh;
                    txtmaphong.Text = sv.MaPhong;

                    // Xử lý Ngày tháng (kiểm tra null để không bị lỗi)
                    txtngaysinh.Text = sv.NgaySinh != null ? Convert.ToDateTime(sv.NgaySinh).ToString("dd/MM/yyyy") : "";
                    txtngayvao.Text = sv.NgayVao != null ? Convert.ToDateTime(sv.NgayVao).ToString("dd/MM/yyyy") : "";

                    // Xử lý cột trạng thái (Ví dụ: Nếu có mã phòng thì báo "Đang ở", ngược lại là "Chưa có phòng")
                    
                }
                else
                {
                    MessageBox.Show("Không tìm thấy dữ liệu của sinh viên này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối dữ liệu: " + ex.Message);
            }
        }
    }
}
