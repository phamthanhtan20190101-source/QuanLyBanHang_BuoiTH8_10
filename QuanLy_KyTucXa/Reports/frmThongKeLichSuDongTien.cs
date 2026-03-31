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
    public partial class frmThongKeLichSuDongTien : Form
    {
        QLKTXDbContext context = new QLKTXDbContext();


        QuanLyKTX.LichSuDongTienDataTable dtLichSu = new QuanLyKTX.LichSuDongTienDataTable();


        string reportsFolder = Application.StartupPath.Replace("bin\\Debug\\net8.0-windows", "Reports");
        public frmThongKeLichSuDongTien()
        {
            InitializeComponent();
        }

        private void frmThongKeLichSuDongTien_Load(object sender, EventArgs e)
        {
            try
            {
                // 4. Truy vấn dữ liệu từ bảng LichSuDongTien
                var danhSachLichSu = context.LichSuDongTiens.Select(ls => new
                {
                    MaThanhToan = ls.MaThanhToan,
                    MSSV = ls.MSSV,
                    ThangDongTien = ls.ThangDongTien,
                    NamDongTien = ls.NamDongTien,
                    SoTien = ls.SoTien,
                    NgayDong = ls.NgayDong
                }).ToList();

                // 5. Đổ dữ liệu vào DataTable
                dtLichSu.Clear();
                foreach (var row in danhSachLichSu)
                {
                    // Tên hàm Add...Row này do Visual Studio tự sinh ra trong DataSet
                    dtLichSu.AddLichSuDongTienRow(
                        row.MaThanhToan,
                        row.MSSV,
                        row.ThangDongTien,
                        row.NamDongTien,
                        row.SoTien,
                        row.NgayDong
                    );
                }

                // 6. Cấu hình Nguồn dữ liệu (ReportDataSource)
                ReportDataSource reportDataSource = new ReportDataSource();
                // Tên này phải TRÙNG KHỚP 100% với tên Dataset bạn cấu hình trong file thiết kế .rdlc
                reportDataSource.Name = "DanhSachLichSuDongTien";
                reportDataSource.Value = dtLichSu;

                // 7. Đưa dữ liệu lên ReportViewer
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(reportDataSource);

                // Trỏ tới file thiết kế báo cáo .rdlc
                reportViewer1.LocalReport.ReportPath = Path.Combine(reportsFolder, "ThongKeLichSuDongTien.rdlc");

                // 8. Cấu hình hiển thị (Chế độ in, zoom 100%)
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

