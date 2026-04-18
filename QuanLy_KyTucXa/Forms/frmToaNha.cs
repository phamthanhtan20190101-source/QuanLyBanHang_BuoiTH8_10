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
using ClosedXML.Excel;

namespace QuanLy_KyTucXa.Forms
{
    public partial class frmToaNha : Form
    {
        QLKTXDbContext context = new QLKTXDbContext();
        bool xuLyThem = false;
        string currentMaPhong = "";
        public frmToaNha()
        {
            InitializeComponent();
        }

        private void frmToaNha_Load(object sender, EventArgs e)
        {
            BatTatChucNang(false); // Khóa nhập liệu ban đầu
            LoadDataToAllGrids();  // Tải dữ liệu lên 4 bảng
        }

        private void BatTatChucNang(bool moKhoa)
        {
            txtMaPhong.Enabled = true;

            // Các ô khác vẫn giữ nguyên theo biến moKhoa
            cobToaNha.Enabled = moKhoa;
            cobLoaiPhong.Enabled = moKhoa;
            txtGiaPhong.Enabled = false; // Giá tự động nhảy nên luôn khóa

            // Nhóm nút Lưu/Hủy
            btnLuu.Enabled = moKhoa;
            btnHuyBo.Enabled = true;

            // Nhóm nút Chức năng chính
            btnThem.Enabled = !moKhoa;
            btnSua.Enabled = !moKhoa;
            btnXoa.Enabled = !moKhoa;
            btnTimKiem.Enabled = !moKhoa;
        }

        private void LoadDataToAllGrids()
        {
            // --- HÀM TẢI DỮ LIỆU CHIA VỀ 4 BẢNG ---


            try
            {
                // 1. Tắt tự động tạo cột để lưới không bị rối
                dataGridViewToaA.AutoGenerateColumns = false;
                dataGridViewToaB.AutoGenerateColumns = false;
                dataGridViewToaC.AutoGenerateColumns = false;
                dataGridViewToaD.AutoGenerateColumns = false;

                // 2. Trỏ cột Số Lượng trên giao diện vào thuộc tính "SoLuongHienThi" mà ta sắp tạo
                dataGridViewToaA.Columns["SoLuongDangOA"].DataPropertyName = "SoLuongHienThi";
                dataGridViewToaB.Columns["SoLuongDangOB"].DataPropertyName = "SoLuongHienThi";
                dataGridViewToaC.Columns["SoLuongDangOC"].DataPropertyName = "SoLuongHienThi";
                dataGridViewToaD.Columns["SoLuongDangOD"].DataPropertyName = "SoLuongHienThi";

                // 3. Lấy danh sách phòng và KẾT HỢP đếm số sinh viên
                var listPhong = context.Phongs
                    .Select(p => new
                    {
                        MaPhong = p.MaPhong,
                        Gia = p.Gia,
                        MaToaNha = p.MaToaNha,
                        LoaiPhong = p.LoaiPhong,

                        // Đếm người ĐANG Ở trực tiếp từ bảng SinhViens và ghép chuỗi "Số đang ở / Tối đa"
                        SoLuongHienThi = context.SinhViens.Count(s => s.MaPhong == p.MaPhong).ToString() + "/" + p.LoaiPhong.ToString()
                    })
                    .ToList();

                // 4. Đổ dữ liệu vào từng lưới
                dataGridViewToaA.DataSource = listPhong.Where(p => p.MaToaNha == "A").ToList();
                dataGridViewToaB.DataSource = listPhong.Where(p => p.MaToaNha == "B").ToList();
                dataGridViewToaC.DataSource = listPhong.Where(p => p.MaToaNha == "C").ToList();
                dataGridViewToaD.DataSource = listPhong.Where(p => p.MaToaNha == "D").ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }





        private void btnThem_Click(object sender, EventArgs e)
        {
            xuLyThem = true;          // Bật cờ Thêm
            BatTatChucNang(true);     // Mở khóa nhập liệu

            // Reset dữ liệu cũ
            txtMaPhong.Clear();
            cobToaNha.SelectedIndex = -1;
            cobLoaiPhong.SelectedIndex = -1;

            txtMaPhong.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaPhong.Text))
            {
                MessageBox.Show("Vui lòng chọn phòng cần sửa từ danh sách!", "Thông báo");
                return;
            }

            xuLyThem = false;         // Bật cờ Sửa
            BatTatChucNang(true);     // Mở khóa nhập liệu
            txtMaPhong.Enabled = false; // Không cho sửa Mã Phòng (Khóa chính)
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentMaPhong))
            {
                MessageBox.Show("Vui lòng chọn phòng cần xóa từ danh sách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Hỏi lại để tránh xóa nhầm
            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa vĩnh viễn phòng {currentMaPhong}?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    var p = context.Phongs.Find(currentMaPhong);
                    if (p != null)
                    {
                        // [CODE MỚI] 3. ĐẾM TRỰC TIẾP SỐ SINH VIÊN ĐANG Ở PHÒNG NÀY
                        int soSinhVienDangO = context.SinhViens.Count(s => s.MaPhong == currentMaPhong);

                        // Nếu lớn hơn 0 -> Tức là có người ở -> Chặn lại ngay!
                        if (soSinhVienDangO > 0)
                        {
                            MessageBox.Show($"Không thể xóa!\nPhòng {currentMaPhong} hiện đang có {soSinhVienDangO} sinh viên ở.\nVui lòng chuyển các sinh viên này sang phòng khác trước khi xóa.", "Từ chối xóa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; // Thoát hàm, không chạy lệnh xóa bên dưới
                        }

                        // 4. Nếu phòng trống (soSinhVienDangO == 0) thì tiến hành xóa
                        context.Phongs.Remove(p);
                        context.SaveChanges();
                        SystemLog.GhiNhatKy("Xóa phòng", $"Đã xóa phòng {currentMaPhong} khỏi hệ thống");
                        MessageBox.Show("Xóa phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Tải lại lưới và đưa giao diện về trạng thái ban đầu
                        LoadDataToAllGrids();
                        btnHuyBo_Click(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    // Bắt lỗi trong trường hợp phòng này đang bị dính khóa ngoại với bảng Hóa Đơn / Đóng Tiền
                    MessageBox.Show("Lỗi: Không thể xóa phòng này vì đang có dữ liệu liên quan (Hóa đơn, v.v...)\nChi tiết: " + ex.Message, "Lỗi xóa dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaPhong.Text) ||
                string.IsNullOrWhiteSpace(cobToaNha.Text) ||
                string.IsNullOrWhiteSpace(cobLoaiPhong.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ Mã phòng, Tòa nhà và Loại phòng!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Dừng lại không chạy code lưu bên dưới nữa
            }

            try
            {
                Phong p;

                if (xuLyThem)
                {


                    // Kiểm tra trùng mã
                    if (context.Phongs.Find(txtMaPhong.Text) != null)
                    {
                        MessageBox.Show("Mã phòng này đã tồn tại!", "Trùng lặp");
                        txtMaPhong.Focus();
                        return;
                    }

                    p = new Phong();
                    p.MaPhong = txtMaPhong.Text;

                    // Gán các giá trị mặc định cho phòng mới
                    p.TrangThai = "Trống";
                    p.TienDienNuoc = 50000;
                    p.SoLuongDangO = 0;

                    // Thêm vào Context (chưa lưu)
                    context.Phongs.Add(p);
                }
                else
                {
                    // --- LOGIC CẬP NHẬT (SỬA) ---
                    p = context.Phongs.Find(currentMaPhong);
                    if (p == null) return;
                }

                // --- XỬ LÝ DỮ LIỆU CHUNG (Cho cả Thêm và Sửa) ---

                // 1. Xử lý Mã Tòa Nhà (Từ "Tòa A (Nam)" -> "A")
                string tenChon = cobToaNha.Text;
                string maToaNha = "";
                if (tenChon.Contains("Tòa A")) maToaNha = "A";
                else if (tenChon.Contains("Tòa B")) maToaNha = "B";
                else if (tenChon.Contains("Tòa C")) maToaNha = "C";
                else if (tenChon.Contains("Tòa D")) maToaNha = "D";
                p.MaToaNha = maToaNha;

                // 2. Xử lý Loại Phòng & Giá
                int sucChua = 0;
                decimal giaTien = 0;

                if (cobLoaiPhong.Text.Contains("4"))
                {
                    sucChua = 4;
                    // Giá mặc định: 120.000đ / 1 người
                    giaTien = 120000;
                }
                else if (cobLoaiPhong.Text.Contains("6"))
                {
                    sucChua = 6;
                    // Giá mặc định: 80.000đ / 1 người
                    giaTien = 80000;
                }

                p.LoaiPhong = sucChua;
                p.Gia = giaTien;

                // Lưu thay đổi xuống CSDL
                context.SaveChanges();

                if (xuLyThem)
                    SystemLog.GhiNhatKy("Thêm phòng", $"Thêm mới phòng {p.MaPhong} (Tòa {p.MaToaNha}, loại {p.LoaiPhong} người)");
                else
                    SystemLog.GhiNhatKy("Sửa phòng", $"Cập nhật thông tin phòng {p.MaPhong}");


                MessageBox.Show(xuLyThem ? "Thêm mới thành công!" : "Cập nhật thành công!");

                // Tải lại dữ liệu và reset form
                LoadDataToAllGrids();
                btnHuyBo_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message + "\n" + ex.InnerException?.Message);
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            BatTatChucNang(false);
            txtMaPhong.Clear();
            cobToaNha.SelectedIndex = -1;
            cobLoaiPhong.SelectedIndex = -1;
        }

        private void dataGridViewToaA_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dataGridViewToaA.Rows[e.RowIndex].IsNewRow) return;

            DataGridViewRow row = dataGridViewToaA.Rows[e.RowIndex];

            txtMaPhong.Text = row.Cells["MaPhongA"].Value?.ToString();
            txtGiaPhong.Text = row.Cells["GiaA"].Value?.ToString();


            string soLuongChuoi = row.Cells["SoLuongDangOA"].Value?.ToString(); // Lấy chuỗi "1/4"
            if (!string.IsNullOrEmpty(soLuongChuoi) && soLuongChuoi.Contains("/"))
            {
                string sucChua = soLuongChuoi.Split('/')[1]; // Cắt lấy số phía sau dấu '/'

                // Chú ý: "4 Người " của bạn đang có 1 khoảng trắng ở cuối theo file Designer
                if (sucChua == "4") cobLoaiPhong.Text = "4 Người ";
                else if (sucChua == "6") cobLoaiPhong.Text = "6 Người";
            }

            cobToaNha.Text = "Tòa A";
            currentMaPhong = txtMaPhong.Text;
        }

        private void dataGridViewToaB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dataGridViewToaB.Rows[e.RowIndex].IsNewRow) return;

            DataGridViewRow row = dataGridViewToaB.Rows[e.RowIndex];

            txtMaPhong.Text = row.Cells["MaPhongB"].Value?.ToString();
            txtGiaPhong.Text = row.Cells["GiaB"].Value?.ToString();

            // -- CODE MỚI: Cắt chuỗi "1/4" để lấy số "4" gán vào ComboBox Loại phòng --
            string soLuongChuoi = row.Cells["SoLuongDangOB"].Value?.ToString(); // Lấy chuỗi "1/4"
            if (!string.IsNullOrEmpty(soLuongChuoi) && soLuongChuoi.Contains("/"))
            {
                string sucChua = soLuongChuoi.Split('/')[1]; // Cắt lấy số phía sau dấu '/'

                // Chú ý: "4 Người " của bạn đang có 1 khoảng trắng ở cuối theo file Designer
                if (sucChua == "4") cobLoaiPhong.Text = "4 Người ";
                else if (sucChua == "6") cobLoaiPhong.Text = "6 Người";
            }

            cobToaNha.Text = "Tòa B";
            currentMaPhong = txtMaPhong.Text;
        }

        private void dataGridViewToaC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dataGridViewToaC.Rows[e.RowIndex].IsNewRow) return;

            DataGridViewRow row = dataGridViewToaC.Rows[e.RowIndex];

            txtMaPhong.Text = row.Cells["MaPhongC"].Value?.ToString();
            txtGiaPhong.Text = row.Cells["GiaC"].Value?.ToString();


            string soLuongChuoi = row.Cells["SoLuongDangOC"].Value?.ToString(); // Lấy chuỗi "1/4"
            if (!string.IsNullOrEmpty(soLuongChuoi) && soLuongChuoi.Contains("/"))
            {
                string sucChua = soLuongChuoi.Split('/')[1]; // Cắt lấy số phía sau dấu '/'

                // Chú ý: "4 Người " của bạn đang có 1 khoảng trắng ở cuối theo file Designer
                if (sucChua == "4") cobLoaiPhong.Text = "4 Người ";
                else if (sucChua == "6") cobLoaiPhong.Text = "6 Người";
            }

            cobToaNha.Text = "Tòa C";
            currentMaPhong = txtMaPhong.Text;
        }

        private void dataGridViewToaD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dataGridViewToaD.Rows[e.RowIndex].IsNewRow) return;

            DataGridViewRow row = dataGridViewToaD.Rows[e.RowIndex];

            txtMaPhong.Text = row.Cells["MaPhongD"].Value?.ToString();
            txtGiaPhong.Text = row.Cells["GiaD"].Value?.ToString();

            string soLuongChuoi = row.Cells["SoLuongDangOD"].Value?.ToString(); // Lấy chuỗi "1/4"
            if (!string.IsNullOrEmpty(soLuongChuoi) && soLuongChuoi.Contains("/"))
            {
                string sucChua = soLuongChuoi.Split('/')[1]; // Cắt lấy số phía sau dấu '/'

                // Chú ý: "4 Người " của bạn đang có 1 khoảng trắng ở cuối theo file Designer
                if (sucChua == "4") cobLoaiPhong.Text = "4 Người ";
                else if (sucChua == "6") cobLoaiPhong.Text = "6 Người";
            }

            cobToaNha.Text = "Tòa D";
            currentMaPhong = txtMaPhong.Text;
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Nhập dữ liệu phòng từ tập tin Excel";
            openFileDialog.Filter = "Tập tin Excel|*.xlsx";
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataTable table = new DataTable();
                    using (XLWorkbook workbook = new XLWorkbook(openFileDialog.FileName))
                    {
                        var worksheet = workbook.Worksheet(1); // Lấy Sheet đầu tiên
                        bool firstRow = true;
                        string readRange = "1:1";

                        foreach (IXLRow row in worksheet.RowsUsed())
                        {
                            // Đọc dòng tiêu đề để tạo cột
                            if (firstRow)
                            {
                                readRange = string.Format("1:{0}", row.LastCellUsed().Address.ColumnNumber);
                                foreach (IXLCell cell in row.Cells(readRange))
                                {
                                    table.Columns.Add(cell.Value.ToString());
                                }
                                firstRow = false;
                            }
                            else // Đọc nội dung
                            {
                                table.Rows.Add();
                                int cellIndex = 0;
                                foreach (IXLCell cell in row.Cells(readRange))
                                {
                                    table.Rows[table.Rows.Count - 1][cellIndex] = cell.Value.ToString();
                                    cellIndex++;
                                }
                            }
                        }
                    }

                    // Xử lý dữ liệu đã đọc được
                    if (table.Rows.Count > 0)
                    {
                        int countThanhCong = 0;
                        foreach (DataRow r in table.Rows)
                        {
                            string maPhongExcel = r["MaPhong"].ToString();

                            // 1. Nếu Mã phòng này đã có trong phần mềm -> Bỏ qua để không bị lỗi trùng lặp
                            if (context.Phongs.Any(p => p.MaPhong == maPhongExcel))
                                continue;

                            // 2. Tạo đối tượng Phòng mới và lấy dữ liệu từ Excel
                            Phong p = new Phong();
                            p.MaPhong = maPhongExcel;
                            p.MaToaNha = r["MaToaNha"].ToString(); // "A", "B", "C", "D"

                            // Xử lý chuyển đổi kiểu số an toàn
                            if (int.TryParse(r["LoaiPhong"].ToString(), out int loaiPhong))
                                p.LoaiPhong = loaiPhong; // 4 hoặc 6

                            if (decimal.TryParse(r["Gia"].ToString(), out decimal gia))
                                p.Gia = gia;

                            // 3. Tự động gán các giá trị mặc định y như lúc Thêm bằng tay
                            p.TrangThai = "Trống";
                            p.TienDienNuoc = 100000;
                            p.SoLuongDangO = 0;

                            context.Phongs.Add(p);
                            countThanhCong++;
                        }

                        context.SaveChanges();

                        SystemLog.GhiNhatKy("Nhập Excel", $"Đã nhập thêm {countThanhCong} phòng mới từ file Excel");
                        MessageBox.Show($"Đã nhập thành công {countThanhCong} phòng mới.\n(Các mã phòng đã tồn tại bị bỏ qua)", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Gọi hàm LoadDataToAllGrids để làm mới cả 4 bảng (Tòa A, B, C, D) lập tức
                        LoadDataToAllGrids();
                    }
                    else
                    {
                        MessageBox.Show("Tập tin Excel rỗng hoặc không đúng định dạng.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi đọc file Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Xuất dữ liệu Phòng ra Excel";
            saveFileDialog.Filter = "Tập tin Excel|*.xlsx";
            saveFileDialog.FileName = "DanhSachPhong_" + DateTime.Now.ToString("dd_MM_yyyy") + ".xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataTable table = new DataTable();
                    // Tạo các cột tương ứng với thông tin Phòng
                    table.Columns.Add("MaPhong", typeof(string));
                    table.Columns.Add("MaToaNha", typeof(string));
                    table.Columns.Add("LoaiPhong", typeof(int));
                    table.Columns.Add("Gia", typeof(decimal));

                    // Lấy toàn bộ danh sách phòng từ CSDL
                    var danhSachPhong = context.Phongs.ToList();
                    foreach (var p in danhSachPhong)
                    {
                        table.Rows.Add(
                            p.MaPhong,
                            p.MaToaNha,
                            p.LoaiPhong,
                            p.Gia
                        );
                    }

                    // Dùng ClosedXML xuất ra file
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        var sheet = wb.Worksheets.Add(table, "Phong");
                        sheet.Columns().AdjustToContents(); // Tự động căn chỉnh độ rộng cột
                        wb.SaveAs(saveFileDialog.FileName);
                    }
                    SystemLog.GhiNhatKy("Xuất Excel", "Đã xuất danh sách phòng ra file Excel");

                    MessageBox.Show("Đã xuất dữ liệu ra tập tin Excel thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xuất file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtMaPhong.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(tuKhoa))
            {
                // Nếu để trống ô Mã phòng mà bấm Tìm kiếm -> Tải lại toàn bộ dữ liệu
                LoadDataToAllGrids();
                return;
            }

            try
            {
                // Lấy lại danh sách gốc có ghép chuỗi Số lượng
                var listPhong = context.Phongs
                    .Select(p => new
                    {
                        MaPhong = p.MaPhong,
                        Gia = p.Gia,
                        MaToaNha = p.MaToaNha,
                        LoaiPhong = p.LoaiPhong,
                        SoLuongHienThi = context.SinhViens.Count(s => s.MaPhong == p.MaPhong).ToString() + "/" + p.LoaiPhong.ToString()
                    })
                    .Where(p => p.MaPhong.ToLower().Contains(tuKhoa)) // Lọc theo từ khóa
                    .ToList();

                // Đổ dữ liệu đã lọc vào 4 lưới
                dataGridViewToaA.DataSource = listPhong.Where(p => p.MaToaNha == "A").ToList();
                dataGridViewToaB.DataSource = listPhong.Where(p => p.MaToaNha == "B").ToList();
                dataGridViewToaC.DataSource = listPhong.Where(p => p.MaToaNha == "C").ToList();
                dataGridViewToaD.DataSource = listPhong.Where(p => p.MaToaNha == "D").ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }

        private void cobLoaiPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng chọn loại phòng nào để tự động điền giá
            if (cobLoaiPhong.Text.Contains("4"))
            {
                txtGiaPhong.Text = "120000";
            }
            else if (cobLoaiPhong.Text.Contains("6"))
            {
                txtGiaPhong.Text = "80000";
            }
            else
            {
                txtGiaPhong.Text = ""; // Nếu chưa chọn hoặc chọn sai thì xóa trắng ô giá
            }
        }
    }

}
