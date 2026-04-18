using Microsoft.IdentityModel.Tokens;
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
    public partial class frmThemSinhVien : Form
    {
        QLKTXDbContext context = new QLKTXDbContext();

        // Các biến trạng thái
        bool xuLyThem = false;
        string currentMSSV = "";

        public frmThemSinhVien()
        {
            InitializeComponent();
        }

        private void BatTatChucNang(bool giaTri)
        {
            btnLuu.Enabled = giaTri;
            btnHuyBo.Enabled = giaTri;

            txtmssv.Enabled = giaTri;
            txthoten.Enabled = giaTri;
            txtlop.Enabled = giaTri;
            txtsdt.Enabled = giaTri;
            txtquequan.Enabled = giaTri;
            cobgioitinh.Enabled = giaTri;
            cobmaphong.Enabled = giaTri;
            datengaysinh.Enabled = giaTri;
            datengayvao.Enabled = giaTri;

            btnThem.Enabled = !giaTri;
            btnSua.Enabled = !giaTri;
            btnXoa.Enabled = !giaTri;
        }

        private void frmThemSinhVien_Load(object sender, EventArgs e)
        {
            LoadComboboxPhong(); // Chỉ cần tải danh sách phòng 1 lần khi mở Form
            ResetForm();         // Gọi hàm Reset để đưa form về trạng thái ban đầu
        }

        // Tạo riêng hàm ResetForm để load lại lưới và khóa nút mà không cần load lại ComboBox
        private void ResetForm()
        {
            BatTatChucNang(false);
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                dataGridView.AutoGenerateColumns = false;
                List<SinhVien> listSV = context.SinhViens.OrderBy(sv => sv.HoTen).ToList();
                dataGridView.DataSource = listSV;

                if (dataGridView.Columns["Phong"] != null)
                    dataGridView.Columns["Phong"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private void LoadComboboxPhong(string gioiTinh = "")
        {
            var query = context.Phongs.AsQueryable();

            // Dùng MaToaNha để lọc vì dữ liệu cột này lưu chính xác là "A", "B", "C", "D"
            if (gioiTinh == "Nam")
            {
                query = query.Where(p => p.ToaNha.MaToaNha == "A" || p.ToaNha.MaToaNha == "C");
            }
            else if (gioiTinh == "Nữ")
            {
                query = query.Where(p => p.ToaNha.MaToaNha == "B" || p.ToaNha.MaToaNha == "D");
            }

            var listPhong = query
                .Select(p => new
                {
                    p.MaPhong,
                    TenToaNha = p.ToaNha.TenToaNha
                })
                .ToList();

            // Xóa bộ nhớ đệm cũ trước khi đổ dữ liệu mới
            cobmaphong.DataSource = null;

            // Đổ dữ liệu đã lọc ra
            cobmaphong.DataSource = listPhong;
            cobmaphong.DisplayMember = "MaPhong";
            cobmaphong.ValueMember = "MaPhong";
            cobmaphong.SelectedIndex = -1;
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // [ĐÃ SỬA] Chặn ngay lập tức nếu click vào tiêu đề hoặc dòng trống dưới cùng
            if (e.RowIndex < 0 || dataGridView.Rows[e.RowIndex].IsNewRow)
                return;

            DataGridViewRow row = dataGridView.Rows[e.RowIndex];

            txtmssv.Text = row.Cells["MSSV"].Value?.ToString();
            currentMSSV = txtmssv.Text;

            txthoten.Text = row.Cells["HoTen"].Value?.ToString();
            txtlop.Text = row.Cells["Lop"].Value?.ToString();
            txtsdt.Text = row.Cells["SDT"].Value?.ToString();
            txtquequan.Text = row.Cells["QueQuan"].Value?.ToString();
            cobgioitinh.Text = row.Cells["GioiTinh"].Value?.ToString();

            // [ĐÃ SỬA] Kiểm tra kỹ DBNull.Value để tránh lỗi khi ngày tháng trong SQL bị rỗng
            if (row.Cells["NgaySinh"].Value != null && row.Cells["NgaySinh"].Value != DBNull.Value)
                datengaysinh.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);

            if (row.Cells["NgayVao"].Value != null && row.Cells["NgayVao"].Value != DBNull.Value)
                datengayvao.Value = Convert.ToDateTime(row.Cells["NgayVao"].Value);

            cobmaphong.SelectedValue = row.Cells["MaPhong"].Value?.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            xuLyThem = true;
            BatTatChucNang(true);

            txtmssv.Clear();
            txthoten.Clear();
            txtlop.Clear();
            txtsdt.Clear();
            txtquequan.Clear();
            cobgioitinh.SelectedIndex = -1;
            cobmaphong.SelectedIndex = -1;
            datengaysinh.Value = DateTime.Now;
            datengayvao.Value = DateTime.Now;
            txtmssv.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtmssv.Text))
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần sửa!", "Thông báo");
                return;
            }

            xuLyThem = false;
            BatTatChucNang(true);
            SystemLog.GhiNhatKy("Sửa sinh viên", $"Sửa mới sinh viên {txtmssv.Text} - {txthoten.Text}");
            txtmssv.Enabled = false; // Không cho sửa khóa chính
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentMSSV))
            {
                MessageBox.Show("Vui lòng chọn sinh viên để xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa sinh viên " + txthoten.Text + " và toàn bộ tài khoản đăng nhập của sinh viên này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    // 1. Tìm sinh viên cần xóa
                    var sv = context.SinhViens.Find(currentMSSV);

                    // 2. Tìm tài khoản tương ứng (Tên tài khoản chính là MSSV)
                    var tk = context.TaiKhoans.FirstOrDefault(t => t.TenTaiKhoan == currentMSSV);

                    if (sv != null)
                    {
                        // Xóa tài khoản trước (nếu tìm thấy)
                        if (tk != null)
                        {
                            context.TaiKhoans.Remove(tk);
                        }

                        // Sau đó xóa sinh viên
                        context.SinhViens.Remove(sv);

                        // Lưu cả 2 thao tác xuống CSDL cùng một lúc
                        context.SaveChanges();

                        SystemLog.GhiNhatKy("Xóa sinh viên", $"Đã xóa sinh viên {currentMSSV} khỏi hệ thống");

                        MessageBox.Show("Đã xóa sinh viên và tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ResetForm();
                    }
                }
                catch (Exception ex)
                {
                    // Bắt lỗi trong trường hợp SV này đã đóng tiền, có hóa đơn... thì SQL sẽ chặn không cho xóa
                    MessageBox.Show("Không thể xóa sinh viên này vì đang có dữ liệu liên quan (Lịch sử đóng tiền, Hóa đơn...)\n\nChi tiết: " + ex.Message, "Lỗi xóa dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtmssv.Text) || string.IsNullOrWhiteSpace(txthoten.Text))
            {
                MessageBox.Show("Vui lòng nhập MSSV và Họ Tên!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(txtmssv.Text, @"^SV\d{3}$"))
            {
                MessageBox.Show("Mã số sinh viên không hợp lệ!", "Sai định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmssv.Clear();
                txtmssv.Focus();
                return;
            }

            string maPhongChon = cobmaphong.SelectedValue?.ToString();
            if (!string.IsNullOrEmpty(maPhongChon))
            {
                var phongDuocChon = context.Phongs.FirstOrDefault(p => p.MaPhong == maPhongChon);
                if (phongDuocChon != null)
                {
                    int sucChuaToiDa = phongDuocChon.LoaiPhong;
                    int soNguoiHienTai = context.SinhViens.Count(s => s.MaPhong == maPhongChon && s.MSSV != txtmssv.Text);

                    if (soNguoiHienTai >= sucChuaToiDa)
                    {
                        MessageBox.Show($"Phòng {maPhongChon} hiện đã đủ người (Tối đa {sucChuaToiDa} người)!\nVui lòng chọn phòng khác cho sinh viên này.", "Phòng đã đầy", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        cobmaphong.Focus();
                        return;
                    }
                }
            }

            try
            {
                // --- XỬ LÝ CHỐNG LỖI CƠ SỞ DỮ LIỆU TẠI ĐÂY ---
                // Cắt bỏ khoảng trắng dư thừa
                string gtInput = cobgioitinh.Text.Trim();
                // Đổi "Nữ" thành "Nu" để tiết kiệm dung lượng, tránh lỗi Truncated
                string gtSafe = (gtInput == "Nữ") ? "Nu" : gtInput;
                // ---------------------------------------------

                if (xuLyThem)
                {
                    var checkID = context.SinhViens.Find(txtmssv.Text);
                    if (checkID != null)
                    {
                        MessageBox.Show("Mã số sinh viên này đã tồn tại!", "Trùng mã");
                        return;
                    }

                    SinhVien sv = new SinhVien();
                    sv.MSSV = txtmssv.Text;
                    sv.HoTen = txthoten.Text;
                    sv.Lop = txtlop.Text;
                    sv.SDT = txtsdt.Text;
                    sv.QueQuan = txtquequan.Text;
                    sv.GioiTinh = gtSafe; // SỬ DỤNG BIẾN ĐÃ ĐƯỢC LÀM SẠCH Ở ĐÂY
                    sv.NgaySinh = datengaysinh.Value;
                    sv.NgayVao = datengayvao.Value;
                    sv.MaPhong = cobmaphong.SelectedValue?.ToString();

                    string matKhauTuDong = txtmssv.Text.Substring(txtmssv.Text.Length - 3);

                    TaiKhoan tk = new TaiKhoan();
                    tk.TenTaiKhoan = txtmssv.Text;
                    // Phải gọi MaHoaHelper
                    tk.MatKhau = MaHoaHelper.HashPassword(matKhauTuDong);
                    tk.Quyen = "SinhVien";

                    context.SinhViens.Add(sv);
                    context.TaiKhoans.Add(tk);
                    context.SaveChanges();

                    MessageBox.Show($"Thêm sinh viên thành công! Tài khoản: {tk.TenTaiKhoan}\n", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    var sv = context.SinhViens.Find(currentMSSV);
                    if (sv != null)
                    {
                        sv.HoTen = txthoten.Text;
                        sv.Lop = txtlop.Text;
                        sv.SDT = txtsdt.Text;
                        sv.QueQuan = txtquequan.Text;
                        sv.GioiTinh = gtSafe; // SỬ DỤNG BIẾN ĐÃ ĐƯỢC LÀM SẠCH Ở ĐÂY
                        sv.NgaySinh = datengaysinh.Value;
                        sv.NgayVao = datengayvao.Value;
                        sv.MaPhong = cobmaphong.SelectedValue?.ToString();

                        context.SinhViens.Update(sv);
                        context.SaveChanges();
                        SystemLog.GhiNhatKy("Thêm sinh viên", $"Thêm mới sinh viên {txtmssv.Text} - {txthoten.Text}");
                        MessageBox.Show("Cập nhật thông tin thành công!");
                    }
                }

                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message);
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            ResetForm(); // [ĐÃ SỬA] Dùng hàm ResetForm
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void cobgioitinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            string gioiTinh = cobgioitinh.Text;

            // Gọi hàm load phòng để nó tự động lọc lại theo Nam/Nữ
            LoadComboboxPhong(gioiTinh);
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Xuất dữ liệu Sinh Viên ra Excel";
            saveFileDialog.Filter = "Tập tin Excel|*.xlsx"; // ClosedXML hỗ trợ tốt nhất .xlsx
            saveFileDialog.FileName = "DanhSachSinhVien_" + DateTime.Now.ToString("dd_MM_yyyy") + ".xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataTable table = new DataTable();
                    // Tạo các cột tương ứng với SinhVien
                    table.Columns.Add("MSSV", typeof(string));
                    table.Columns.Add("HoTen", typeof(string));
                    table.Columns.Add("Lop", typeof(string));
                    table.Columns.Add("QueQuan", typeof(string));
                    table.Columns.Add("SDT", typeof(string));
                    table.Columns.Add("NgaySinh", typeof(string));
                    table.Columns.Add("GioiTinh", typeof(string));
                    table.Columns.Add("NgayVao", typeof(string));
                    table.Columns.Add("MaPhong", typeof(string));

                    // Đổ dữ liệu từ DB vào DataTable
                    var danhSachSV = context.SinhViens.ToList();
                    foreach (var sv in danhSachSV)
                    {
                        table.Rows.Add(
                            sv.MSSV,
                            sv.HoTen,
                            sv.Lop,
                            sv.QueQuan,
                            sv.SDT,
                            sv.NgaySinh.ToString("dd/MM/yyyy"), // Format ngày tháng cho đẹp
                            sv.GioiTinh,
                            sv.NgayVao.ToString("dd/MM/yyyy"),
                            sv.MaPhong
                        );
                    }

                    // Dùng ClosedXML xuất ra file
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        var sheet = wb.Worksheets.Add(table, "SinhVien");
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

        private void btnNhap_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Nhập dữ liệu từ tập tin Excel";
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
                            string mssvExcel = r["MSSV"].ToString();

                            // 1. Kiểm tra xem MSSV này đã có trong CSDL chưa, nếu có thì bỏ qua dòng này
                            if (context.SinhViens.Any(s => s.MSSV == mssvExcel))
                                continue;

                            // 2. Map dữ liệu vào object SinhVien
                            SinhVien sv = new SinhVien();
                            sv.MSSV = mssvExcel;
                            sv.HoTen = r["HoTen"].ToString();
                            sv.Lop = r["Lop"].ToString();
                            sv.QueQuan = r["QueQuan"].ToString();
                            sv.SDT = r["SDT"].ToString();
                            sv.GioiTinh = r["GioiTinh"].ToString();
                            sv.MaPhong = r["MaPhong"].ToString();

                            // Xử lý chuyển đổi ngày tháng an toàn
                            if (DateTime.TryParseExact(r["NgaySinh"].ToString(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime ns))
                                sv.NgaySinh = ns;

                            if (DateTime.TryParseExact(r["NgayVao"].ToString(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime nv))
                                sv.NgayVao = nv;

                            // 3. Tự động tạo Tài khoản giống như khi Thêm bằng tay
                            // Lấy 3 số cuối của MSSV
                            string matKhauTuDong = sv.MSSV.Length >= 3 ? sv.MSSV.Substring(sv.MSSV.Length - 3) : sv.MSSV;

                            TaiKhoan tk = new TaiKhoan();
                            tk.TenTaiKhoan = sv.MSSV; // Dùng sv.MSSV
                            tk.MatKhau = MaHoaHelper.HashPassword(matKhauTuDong); // Đã băm an toàn
                            tk.Quyen = "SinhVien";

                            
                            context.SinhViens.Add(sv);
                            context.TaiKhoans.Add(tk);
                            countThanhCong++;
                        
                    }

                        context.SaveChanges();

                        SystemLog.GhiNhatKy("Nhập Excel", $"Đã nhập thêm {countThanhCong} phòng mới từ file Excel");
                        MessageBox.Show($"Đã nhập thành công {countThanhCong} sinh viên mới.\n(Các sinh viên đã tồn tại MSSV bị bỏ qua để tránh lỗi)", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Gọi hàm LoadData để cập nhật lại lưới DataGridView
                        LoadData();
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
    }
}