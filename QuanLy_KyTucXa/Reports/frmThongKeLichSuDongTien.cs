using Microsoft.Reporting.WinForms;
using QuanLy_KyTucXa.Data;
using System;
using System.Data;
using System.IO;
using System.Linq;
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
                var query = context.LichSuDongTiens.AsQueryable();

                if (thangLoc > 0)
                {
                    query = query.Where(ls => ls.ThangDongTien == thangLoc);
                }

                var danhSachLichSu = query.OrderByDescending(ls => ls.NgayDong).Select(ls => new
                {
                    ls.MaThanhToan,
                    ls.MSSV,
                    ls.ThangDongTien,
                    ls.NamDongTien,
                    ls.SoTien,
                    ls.NgayDong
                }).ToList();

                dtLichSu.Clear();
                foreach (var row in danhSachLichSu)
                {
                    dtLichSu.AddLichSuDongTienRow(
                        row.MaThanhToan,
                        row.MSSV,
                        row.ThangDongTien,
                        row.NamDongTien,
                        row.SoTien,
                        row.NgayDong
                    );
                }

                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "DanhSachLichSuDongTien";
                reportDataSource.Value = dtLichSu;

                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(reportDataSource);
                reportViewer1.LocalReport.ReportPath = Path.Combine(reportsFolder, "ThongKeLichSuDongTien.rdlc");

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