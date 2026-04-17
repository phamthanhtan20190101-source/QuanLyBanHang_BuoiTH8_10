using Microsoft.Reporting.WinForms;
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

namespace QuanLy_KyTucXa.Reports
{
    public partial class frmThongKeHoaDon : Form
    {
        QLKTXDbContext context = new QLKTXDbContext();

        QuanLyKTX.LichSuHoaDonDataTable dtHoaDon = new QuanLyKTX.LichSuHoaDonDataTable();


        string reportsFolder = Application.StartupPath.Replace("bin\\Debug\\net8.0-windows", "Reports");
        public frmThongKeHoaDon()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void frmThongKeHoaDon_Load(object sender, EventArgs e)
        {
            try
            {
                // 1. Truy vấn dữ liệu từ bảng Hóa Đơn (sắp xếp theo ngày tạo mới nhất)
                var danhSachHoaDon = context.HoaDons.OrderByDescending(hd => hd.NgayTao).Select(hd => new
                {
                    MaHoaDon = hd.MaHoaDon,
                    MSSV = hd.MSSV,
                    MaQuanLy = hd.MaQuanLy,
                    NgayTao = hd.NgayTao,
                    Thang = hd.Thang,
                    TongTien = hd.TongTien,
                    TrangThai = hd.TrangThai
                }).ToList();

                // 2. Đổ dữ liệu vào DataTable
                dtHoaDon.Clear();
                foreach (var row in danhSachHoaDon)
                {
                    // Tên hàm Add...Row này do Visual Studio tự sinh ra trong DataSet
                    dtHoaDon.AddLichSuHoaDonRow(
                        row.MaHoaDon,
                        row.MSSV,
                        row.MaQuanLy,
                        row.NgayTao,
                        row.Thang.ToString(), // Ép kiểu sang chuỗi để khớp với DataSet
                        row.TongTien,
                        row.TrangThai
                    );
                }

                // 3. Cấu hình Nguồn dữ liệu (ReportDataSource)
                ReportDataSource reportDataSource = new ReportDataSource();

               
                reportDataSource.Name = "DataSet1";
                reportDataSource.Value = dtHoaDon;

                // 4. Đưa dữ liệu lên ReportViewer
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(reportDataSource);

                // Trỏ tới file thiết kế báo cáo .rdlc bằng Path.Combine
                reportViewer1.LocalReport.ReportPath = Path.Combine(reportsFolder, "ThongKeHoaDon.rdlc");

                // 5. Cấu hình hiển thị (Chế độ in, zoom 100%) giống hệt form mẫu
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
        
        
    }
}
