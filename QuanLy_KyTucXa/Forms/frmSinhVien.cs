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

        // Hàm dùng chung để lấy thông tin Tòa nhà, Quản lý và gọi in PDF
        private void TaoDonTuDong(string tenLoaiDon)
        {
            try
            {
                string mssv = frmMain.MaNguoiDungHienTai;
                var sv = context.SinhViens.FirstOrDefault(s => s.MSSV == mssv);

                if (sv == null || string.IsNullOrEmpty(sv.MaPhong))
                {
                    MessageBox.Show("Bạn chưa được xếp phòng nên không thể tạo đơn này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Truy vấn logic: Sinh viên -> Phòng -> Tòa Nhà
                var phong = context.Phongs.FirstOrDefault(p => p.MaPhong == sv.MaPhong);
                string tenToaNha = "Không xác định";

                
                string tenQuanLy = "...................................";

                if (phong != null)
                {
                    var toaNha = context.ToaNhas.FirstOrDefault(t => t.MaToaNha == phong.MaToaNha);
                    if (toaNha != null)
                    {
                        tenToaNha = toaNha.MaToaNha;
                       
                    }
                }

                // Gọi hàm bên PdfHelper để xuất file
                PdfHelper.XuatDonPDF(tenLoaiDon, sv, tenToaNha, tenQuanLy);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDonXinChuyenPhong_Click(object sender, EventArgs e)
        {
            TaoDonTuDong("CHUYỂN PHÒNG");
        }

        private void btnXinRoiKTX_Click(object sender, EventArgs e)
        {
            TaoDonTuDong("RỜI KÝ TÚC XÁ");
        }
    }
}
