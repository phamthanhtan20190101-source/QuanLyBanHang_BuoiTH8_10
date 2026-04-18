using Microsoft.Reporting.WinForms;
using QuanLy_KyTucXa.Data;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace QuanLy_KyTucXa.Reports
{
    public partial class frmThongKeNhatKy : Form
    {
        QLKTXDbContext context = new QLKTXDbContext();

        // Khai báo biến trỏ tới cái bảng bạn vừa tạo trong DataSet ở Bước 1
        QuanLyKTX.NhatKyHeThongDataTable dtNhatKy = new QuanLyKTX.NhatKyHeThongDataTable();

        string reportsFolder = Application.StartupPath.Replace("bin\\Debug\\net8.0-windows", "Reports");

        public frmThongKeNhatKy()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void frmThongKeNhatKy_Load(object sender, EventArgs e)
        {
            if (!cobLocTheoThang.Items.Contains("Tất cả"))
            {
                cobLocTheoThang.Items.Insert(0, "Tất cả");
            }
            cobLocTheoThang.SelectedIndex = 0;
        }

        private void LoadBaoCao(int thangLoc)
        {
            try
            {
                var query = context.NhatKyHeThongs.AsQueryable();

                // Lọc theo tháng của năm hiện tại
                if (thangLoc > 0)
                {
                    query = query.Where(nk => nk.ThoiGian.Month == thangLoc && nk.ThoiGian.Year == DateTime.Now.Year);
                }

                var danhSachNhatKy = query.OrderByDescending(nk => nk.ThoiGian).Select(nk => new
                {
                    nk.MaNhatKy,
                    nk.TenNguoiDung,
                    nk.ThoiGian,
                    nk.HanhDong,
                    nk.ChiTiet
                }).ToList();

                dtNhatKy.Clear();
                foreach (var row in danhSachNhatKy)
                {
                    // Truyền dữ liệu vào DataTable (Ép kiểu ngày tháng sang chuỗi cho đẹp)
                    dtNhatKy.AddNhatKyHeThongRow(
                        row.MaNhatKy,
                        row.TenNguoiDung,
                        row.ThoiGian,
                        row.HanhDong,
                        row.ChiTiet
                    );
                }

                ReportDataSource reportDataSource = new ReportDataSource();
                // Tên này phải trùng khớp CHÍNH XÁC với tên Data source bạn đã đặt ở Bước 2.4
                reportDataSource.Name = "DataSet1";
                reportDataSource.Value = dtNhatKy;

                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(reportDataSource);
                reportViewer1.LocalReport.ReportPath = Path.Combine(reportsFolder, "ThongKeNhatKy.rdlc");

                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải báo cáo: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cobLocTheoThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cobLocTheoThang.SelectedIndex == 0 || cobLocTheoThang.Text == "Tất cả")
            {
                LoadBaoCao(0);
            }
            else
            {
                string chuoiThang = cobLocTheoThang.Text.Replace("Tháng", "").Trim();
                if (int.TryParse(chuoiThang, out int thang))
                {
                    LoadBaoCao(thang);
                }
            }
        }
    }
}