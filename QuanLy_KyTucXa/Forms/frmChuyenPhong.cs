using QuanLy_KyTucXa.Data;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace QuanLy_KyTucXa.Forms
{
    public partial class frmChuyenPhong : Form
    {
        QLKTXDbContext context = new QLKTXDbContext();

        // Biến nhận MSSV từ các Form khác truyền sang (nếu có)
        public string mssvCanChuyen = "";

        public frmChuyenPhong()
        {
            InitializeComponent();
        }

        private void frmChuyenPhong_Load(object sender, EventArgs e)
        {
            try
            {
                // LƯU Ý: Không load tất cả danh sách phòng ở đây nữa.
                // Danh sách phòng bây giờ sẽ được load động tùy thuộc vào Giới tính/Tòa nhà của sinh viên.
                if (!string.IsNullOrEmpty(mssvCanChuyen))
                {
                    txtMSSV.Text = mssvCanChuyen;
                    LoadThongTinHienTai();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối CSDL: " + ex.Message, "Lỗi");
            }
        }

        // Hàm tra cứu sinh viên, hiển thị Họ Tên và lọc danh sách phòng được phép chuyển
        private void LoadThongTinHienTai()
        {
            string maSV = txtMSSV.Text.Trim();
            if (string.IsNullOrEmpty(maSV))
            {
                txtPhongCu.Text = "";
                txtHoTen.Text = ""; // Xóa trắng họ tên
                cobPhongMoi.DataSource = null;
                return;
            }

            var sv = context.SinhViens.FirstOrDefault(s => s.MSSV == maSV);
            if (sv != null)
            {
                // 1. Hiển thị Họ Tên sinh viên
                txtHoTen.Text = sv.HoTen;

                string toaNhaChoPhep1 = "";
                string toaNhaChoPhep2 = "";

                // 2. Logic xác định Tòa nhà được phép chuyển tới
                if (!string.IsNullOrEmpty(sv.MaPhong))
                {
                    txtPhongCu.Text = sv.MaPhong;

                    // Lấy ký tự đầu tiên của Mã phòng (VD: "A101" -> "A") để nhận diện tòa nhà
                    string toaNhaHienTai = sv.MaPhong.Substring(0, 1).ToUpper();

                    // Logic Tòa A -> C, Tòa B -> D
                    if (toaNhaHienTai == "A") toaNhaChoPhep1 = "C";
                    else if (toaNhaHienTai == "B") toaNhaChoPhep1 = "D";
                    else if (toaNhaHienTai == "C") toaNhaChoPhep1 = "A"; // Hỗ trợ chuyển ngược từ C về A
                    else if (toaNhaHienTai == "D") toaNhaChoPhep1 = "B"; // Hỗ trợ chuyển ngược từ D về B
                }
                else
                {
                    txtPhongCu.Text = "Chưa xếp phòng";

                    // Nếu chưa có phòng, dựa vào giới tính để gợi ý (Nam: B, D | Nữ: A, C)
                    if (sv.GioiTinh == "Nam" || sv.GioiTinh == "Nam ")
                    {
                        toaNhaChoPhep1 = "B";
                        toaNhaChoPhep2 = "D";
                    }
                    else // Nữ
                    {
                        toaNhaChoPhep1 = "A";
                        toaNhaChoPhep2 = "C";
                    }
                }

                // 3. LỌC: Chỉ lấy các phòng CÒN TRỐNG và THUỘC TÒA NHÀ ĐƯỢC PHÉP
                var danhSachPhongTrong = context.Phongs
                    .Where(p => p.SoLuongDangO < p.LoaiPhong &&
                                (p.MaPhong.StartsWith(toaNhaChoPhep1) ||
                                (!string.IsNullOrEmpty(toaNhaChoPhep2) && p.MaPhong.StartsWith(toaNhaChoPhep2))))
                    .Select(p => p.MaPhong)
                    .ToList();

                cobPhongMoi.DataSource = danhSachPhongTrong;

                if (danhSachPhongTrong.Count == 0)
                {
                    MessageBox.Show("Hiện không có phòng trống nào phù hợp cho sinh viên này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                txtPhongCu.Text = "Không tìm thấy SV";
                txtHoTen.Text = "";
                cobPhongMoi.DataSource = null;
            }
        }

        // Sự kiện gõ phím -> Tự động cập nhật
        private void txtMSSV_TextChanged(object sender, EventArgs e)
        {
            LoadThongTinHienTai();
        }

        // Nút XÁC NHẬN CHUYỂN
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            string maSV = txtMSSV.Text.Trim();
            string phongCu = txtPhongCu.Text;
            string phongMoi = cobPhongMoi.Text;

            if (string.IsNullOrEmpty(maSV) || string.IsNullOrEmpty(phongMoi))
            {
                MessageBox.Show("Vui lòng nhập mã sinh viên và chọn phòng mới!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (phongCu == phongMoi)
            {
                MessageBox.Show("Sinh viên đang ở phòng này rồi, không thể chuyển!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var sinhVien = context.SinhViens.FirstOrDefault(s => s.MSSV == maSV);
                var objPhongCu = context.Phongs.FirstOrDefault(p => p.MaPhong == phongCu);
                var objPhongMoi = context.Phongs.FirstOrDefault(p => p.MaPhong == phongMoi);

                if (sinhVien != null && objPhongMoi != null)
                {
                    // LƯU Ý: Phải kiểm tra an toàn vì có thể sinh viên "Chưa xếp phòng" (objPhongCu = null)
                    if (objPhongCu != null && objPhongCu.SoLuongDangO > 0)
                    {
                        // HÀNH ĐỘNG 1: Trừ 1 người ở phòng cũ
                        objPhongCu.SoLuongDangO -= 1;
                    }

                    // HÀNH ĐỘNG 2: Cộng 1 người vào phòng mới
                    objPhongMoi.SoLuongDangO += 1;

                    // HÀNH ĐỘNG 3: Cập nhật mã phòng mới cho Sinh viên
                    sinhVien.MaPhong = objPhongMoi.MaPhong;

                    // Lưu cả 3 hành động cùng lúc xuống CSDL
                    context.SaveChanges();

                    SystemLog.GhiNhatKy("Chuyển phòng", $"Chuyển sinh viên {sinhVien.HoTen} từ phòng {phongCu} sang phòng {phongMoi}");

                    MessageBox.Show($"Đã chuyển sinh viên {sinhVien.HoTen} sang phòng {phongMoi} thành công!\nSố lượng người của cả 2 phòng đã được cập nhật tự động.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chuyển phòng: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}