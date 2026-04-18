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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLy_KyTucXa.Forms
{
    public partial class CapNhatDongTien : Form
    {
        QLKTXDbContext context = new QLKTXDbContext();
        public CapNhatDongTien()
        {
            InitializeComponent();
        }

        private void CapNhatDongTien_Load(object sender, EventArgs e)
        {
            txtmssv.ReadOnly = true;
            txthoten.ReadOnly = true;
            txtlop.ReadOnly = true;
            txtsdt.ReadOnly = true;
            txtTienNo.ReadOnly = true; // Tiền nợ thường do hệ thống tính, không nên nhập tay

            var listPhong = context.Phongs.Select(p => p.MaPhong).ToList();
            listPhong.Insert(0, "Tất cả các phòng");
            cobtimkiem.DataSource = listPhong;

           

            int thangHienTai = DateTime.Now.Month;
            bool coPhatSinhNo = false;

            // Lấy tất cả sinh viên đang ở trong ký túc xá (có mã phòng)
            var danhSachSV = context.SinhViens.Where(sv => !string.IsNullOrEmpty(sv.MaPhong)).ToList();

            foreach (var sv in danhSachSV)
            {
                // Kiểm tra: Nếu tháng này chưa cộng tiền nợ cho sinh viên này thì mới cộng
                if (sv.ThangDaCapNhatNo != thangHienTai)
                {
                    var phong = context.Phongs.Find(sv.MaPhong);
                    if (phong != null)
                    {
                        // TỰ ĐỘNG CỘNG THẲNG (Nợ mới = Nợ cũ + Giá phòng + Điện nước)
                        sv.TienNo = sv.TienNo + phong.Gia + phong.TienDienNuoc;

                        // Cập nhật trạng thái
                        sv.TrangThaiTienPhong = "Chưa đóng";

                        // Đánh dấu là tháng này đã cộng rồi để lần sau mở Form không cộng nữa
                        sv.ThangDaCapNhatNo = thangHienTai;

                        coPhatSinhNo = true;
                    }
                }
            }

            // Nếu có cộng nợ cho bất kỳ ai thì lưu lại và báo cho người dùng biết
            if (coPhatSinhNo)
            {
                context.SaveChanges();


                MessageBox.Show($"Hệ thống phát hiện đã bước sang tháng mới (Tháng {thangHienTai}).\nĐã tự động cộng thẳng tiền phòng và điện nước vào nợ của tất cả sinh viên!", "Tự động chốt sổ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            // Tải dữ liệu lên lưới
            LoadData();

        }
        private void LoadData()
        {
            try
            {
                // Ngăn DataGridView tự tạo thêm cột thừa
                dataGridView.AutoGenerateColumns = false;

                // Nối cột trên giao diện với cột trong Database (Thuộc tính DataPropertyName)
                dataGridView.Columns["MSSV"].DataPropertyName = "MSSV";
                dataGridView.Columns["HoTen"].DataPropertyName = "HoTen";
                dataGridView.Columns["Lop"].DataPropertyName = "Lop";
                dataGridView.Columns["SDT"].DataPropertyName = "SDT";
                dataGridView.Columns["NgayVao"].DataPropertyName = "NgayVao";
                dataGridView.Columns["MaPhong"].DataPropertyName = "MaPhong";
                if (dataGridView.Columns["TrangThaiTienPhong"] != null)
                {
                    dataGridView.Columns["TrangThaiTienPhong"].DataPropertyName = "TrangThaiTienPhong";
                }

                // Lấy danh sách sinh viên từ CSDL và sắp xếp theo tên
                var listSV = context.SinhViens.OrderBy(sv => sv.HoTen).ToList();

                // Đổ dữ liệu vào lưới
                dataGridView.DataSource = listSV;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            if (e.RowIndex < 0 || dataGridView.Rows[e.RowIndex].IsNewRow)
                return;

            DataGridViewRow row = dataGridView.Rows[e.RowIndex];

            // 1. Gán thông tin cơ bản
            txtmssv.Text = row.Cells["MSSV"].Value?.ToString();
            txthoten.Text = row.Cells["HoTen"].Value?.ToString();
            txtlop.Text = row.Cells["Lop"].Value?.ToString();
            txtsdt.Text = row.Cells["SDT"].Value?.ToString();


            // 2. Lấy Mã Phòng của sinh viên đang được click
            string maPhong = row.Cells["MaPhong"].Value?.ToString();

            // 3. Truy vấn tìm phòng và tính tiền nợ
            var sv = context.SinhViens.Find(txtmssv.Text);
            if (sv != null)
            {
                txtTienNo.Text = sv.TienNo.ToString("N0");
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txttimkiem.Text.Trim();
            bool timNguoiNo = checkSVno.Checked; // Lấy trạng thái của Checkbox mới
            if (string.IsNullOrEmpty(tuKhoa))
            {
                if (timNguoiNo)
                {
                    // Nếu TextBox trống NHƯNG có tick "Sinh viên nợ" -> Lấy sinh viên có trạng thái "Chưa đóng"
                    var listNo = context.SinhViens
                        .Where(sv => sv.TrangThaiTienPhong == "Chưa đóng")
                        .OrderBy(sv => sv.HoTen).ToList();
                    dataGridView.DataSource = listNo;
                }
                else
                {
                    // Nếu TextBox trống VÀ KHÔNG tick gì cả -> Hiện cảnh báo bắt buộc nhập
                    MessageBox.Show("Vui lòng nhập MSSV hoặc Tên sinh viên để tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txttimkiem.Focus();
                }
                return; // Dừng lại, không chạy code tìm kiếm bên dưới nữa
            }

            // 2. NẾU TEXTBOX CÓ CHỮ -> Tìm kiếm theo MSSV hoặc Tên
            var query = context.SinhViens.Where(sv => sv.MSSV.Contains(tuKhoa) || sv.HoTen.Contains(tuKhoa));

            // Nếu lúc này đang tick "Sinh viên nợ" thì kết hợp tìm "Những người tên đó MÀ Chưa đóng tiền"
            if (timNguoiNo)
            {
                query = query.Where(sv => sv.TrangThaiTienPhong == "Chưa đóng");
            }

            var ketQua = query.OrderBy(sv => sv.HoTen).ToList();
            dataGridView.DataSource = ketQua;

            // Nếu tìm không ra ai
            if (ketQua.Count == 0)
            {
                MessageBox.Show("Không tìm thấy sinh viên nào khớp với điều kiện!", "Kết quả tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cobtimkiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cobtimkiem.SelectedItem == null) return;

            string phongChon = cobtimkiem.Text;

            if (phongChon == "Tất cả các phòng")
            {
                LoadData(); // Nếu chọn "Tất cả" thì gọi lại hàm load toàn bộ
            }
            else
            {
                // Lọc ra sinh viên của phòng được chọn
                var listTheoPhong = context.SinhViens
                    .Where(sv => sv.MaPhong == phongChon)
                    .OrderBy(sv => sv.HoTen).ToList();
                dataGridView.DataSource = listTheoPhong;
            }


        }

        private void checkSVno_CheckedChanged(object sender, EventArgs e)
        {
            if (checkSVno.Checked)
            {
                // Rất gọn gàng: Chỉ lấy những sinh viên có trạng thái "Chưa đóng"
                var listNo = context.SinhViens
                    .Where(sv => sv.TrangThaiTienPhong == "Chưa đóng")
                    .OrderBy(sv => sv.HoTen).ToList();
                dataGridView.DataSource = listNo;
            }
            else
            {
                LoadData();
            }
        }

        private void btnXacnhan_Click(object sender, EventArgs e)
        {
            // 1. KIỂM TRA ĐẦU VÀO
            string mssv = txtmssv.Text;
            if (string.IsNullOrEmpty(mssv))
            {
                MessageBox.Show("Vui lòng chọn một sinh viên từ danh sách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (checkedList_DongTien.CheckedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một tháng để đóng tiền!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(textsotiennhan.Text, out decimal tongTienNhan) || tongTienNhan <= 0)
            {
                MessageBox.Show("Vui lòng nhập số tiền đã nhận hợp lệ (lớn hơn 0)!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textsotiennhan.Focus();
                return;
            }

            try
            {
                // 2. TẠO MÃ VÀ CHIA TIỀN
                // Lấy 3 số cuối của MSSV (Nếu MSSV ngắn hơn 3 thì lấy nguyên MSSV để chống lỗi)
                string baSoCuoi = mssv.Length >= 3 ? mssv.Substring(mssv.Length - 3) : mssv;
                int namHienTai = DateTime.Now.Year;

                // Chia đều số tiền nếu sinh viên chọn đóng nhiều tháng 1 lúc
                decimal tienMoiThang = tongTienNhan / checkedList_DongTien.CheckedItems.Count;

                // 3. DUYỆT QUA TỪNG THÁNG ĐƯỢC TICK ĐỂ LƯU
                foreach (var item in checkedList_DongTien.CheckedItems)
                {
                    // Xử lý chuỗi "Tháng 1" -> Lấy ra số 1
                    string chuoiThang = item.ToString().Replace("Tháng", "").Trim();
                    int thang = int.Parse(chuoiThang);

                    // ==========================================
                    // 3.1. TẠO LỊCH SỬ ĐÓNG TIỀN
                    // ==========================================
                    LichSuDongTien ls = new LichSuDongTien();
                    ls.MaThanhToan = $"MTT_{thang:D2}_{baSoCuoi}";
                    ls.MSSV = mssv;
                    ls.ThangDongTien = thang;
                    ls.NamDongTien = namHienTai;
                    ls.SoTien = tienMoiThang;
                    ls.NgayDong = DateTime.Now;

                    // Kiểm tra xem tháng này đã đóng chưa (tránh đóng trùng)
                    var checkTrung = context.LichSuDongTiens.Find(ls.MaThanhToan);
                    if (checkTrung != null)
                    {
                        MessageBox.Show($"Tháng {thang} sinh viên này đã đóng tiền rồi (Mã: {ls.MaThanhToan}).\nVui lòng bỏ tick tháng này!", "Đã thanh toán", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return; // Dừng lại không lưu
                    }
                    context.LichSuDongTiens.Add(ls);

                    // ==========================================
                    // 3.2. TẠO HÓA ĐƠN SONG SONG
                    // ==========================================
                    HoaDon hd = new HoaDon();
                    hd.MaHoaDon = $"HD_{baSoCuoi}_{thang:D2}"; // Định dạng: HD_3SốCuối_Tháng
                    hd.MSSV = mssv;
                    hd.MaQuanLy = frmMain.MaNguoiDungHienTai; // Hệ thống sẽ tự động lấy mã của người đang đăng nhập
                    hd.NgayTao = DateTime.Now;
                    hd.Thang = thang;
                    hd.Nam = namHienTai;
                    hd.TongTien = tienMoiThang;
                    hd.TrangThai = "Đã thanh toán";

                    // Kiểm tra tránh trùng lặp hóa đơn
                    var checkHD = context.HoaDons.Find(hd.MaHoaDon);
                    if (checkHD == null)
                    {
                        context.HoaDons.Add(hd);
                    }
                }

                // 4. TÍNH TOÁN VÀ CẬP NHẬT TRẠNG THÁI TIỀN NỢ
                var sv = context.SinhViens.Find(mssv);
                if (sv != null)
                {
                    // Nếu số tiền nhận LỚN HƠN HOẶC BẰNG số tiền nợ
                    if (tongTienNhan >= sv.TienNo)
                    {
                        sv.TienNo = 0;                      // Xóa nợ
                        sv.TrangThaiTienPhong = "Đã đóng";  // Đổi trạng thái
                    }
                    else // Nếu đóng KHÔNG ĐỦ
                    {
                        sv.TienNo = sv.TienNo - tongTienNhan; // Lấy nợ cũ trừ tiền đã đóng ra nợ mới
                        sv.TrangThaiTienPhong = "Chưa đóng";  // Vẫn treo trạng thái chưa đóng
                    }

                    context.SinhViens.Update(sv);
                }

                // 5. LƯU TẤT CẢ VÀO DATABASE
                context.SaveChanges();

                SystemLog.GhiNhatKy("Thu tiền", $"Đã thu {tongTienNhan:N0}đ của sinh viên {mssv}");
                MessageBox.Show("Xác nhận thanh toán và xuất hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (MessageBox.Show("Bạn có muốn in hóa đơn PDF không?", "In hóa đơn", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Lấy thông tin phòng để in
                    var phong = context.Phongs.Find(sv.MaPhong);
                    string tenP = (phong != null) ? phong.MaPhong : "N/A";

                    // Vì bạn có thể đóng nhiều tháng, code này sẽ lấy hóa đơn cuối cùng vừa tạo để in
                    // Hoặc bạn có thể sửa logic để in từng cái tùy ý
                    var hoaDonVuaTao = context.HoaDons
                                        .Where(h => h.MSSV == sv.MSSV)
                                        .OrderByDescending(h => h.NgayTao)
                                        .FirstOrDefault();

                    if (hoaDonVuaTao != null)
                    {
                        PdfHelper.XuatHoaDonPDF(hoaDonVuaTao, sv, tenP);
                    }
                }

                // 6. LÀM SẠCH GIAO DIỆN SAU KHI LƯU
                textsotiennhan.Clear();
                for (int i = 0; i < checkedList_DongTien.Items.Count; i++)
                {
                    checkedList_DongTien.SetItemChecked(i, false);
                }

                // THÊM DÒNG NÀY ĐỂ CẬP NHẬT LẠI TIỀN NỢ TRÊN MÀN HÌNH NGAY LẬP TỨC:
                txtTienNo.Text = sv.TienNo.ToString("N0");

                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
