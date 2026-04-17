using iText.IO.Font;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using QuanLy_KyTucXa.Data;
using System;
using System.IO;
using System.Windows.Forms;

namespace QuanLy_KyTucXa
{
    public static class PdfHelper
    {
        public static void XuatHoaDonPDF(HoaDon hd, SinhVien sv, string tenPhong)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = hd.MaHoaDon + ".pdf";
            sfd.Filter = "PDF File | *.pdf";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (FileStream fs = new FileStream(sfd.FileName, FileMode.Create))
                    {
                        PdfWriter writer = new PdfWriter(fs);
                        PdfDocument pdf = new PdfDocument(writer);
                        Document document = new Document(pdf);

                        // 1. Cài đặt Font tiếng Việt
                        string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "Arial.ttf");
                        PdfFont font = PdfFontFactory.CreateFont(fontPath, PdfEncodings.IDENTITY_H);

                        // 2. Tiêu đề (Đã bỏ SetBold)
                        Paragraph header = new Paragraph("HÓA ĐƠN THANH TOÁN TIỀN KÝ TÚC XÁ")
                            .SetFont(font)
                            .SetFontSize(18)
                            .SetTextAlignment(TextAlignment.CENTER);
                        document.Add(header);

                        document.Add(new Paragraph("\n"));

                        // 3. Thông tin chung
                        document.Add(new Paragraph($"Mã hóa đơn: {hd.MaHoaDon}").SetFont(font));
                        document.Add(new Paragraph($"Ngày lập: {hd.NgayTao:dd/MM/yyyy HH:mm}").SetFont(font));
                        document.Add(new Paragraph($"Người lập: {hd.MaQuanLy}").SetFont(font));
                        document.Add(new Paragraph("--------------------------------------------------").SetFont(font));

                        // 4. Thông tin sinh viên
                        document.Add(new Paragraph($"Sinh viên: {sv.HoTen} ({sv.MSSV})").SetFont(font));
                        document.Add(new Paragraph($"Phòng: {tenPhong}").SetFont(font));
                        document.Add(new Paragraph($"Tháng thanh toán: {hd.Thang}/{hd.Nam}").SetFont(font));

                        document.Add(new Paragraph("\n"));

                        // 5. Bảng chi tiết tiền (Đã bỏ SetBold)
                        Table table = new Table(2).UseAllAvailableWidth();
                        table.AddHeaderCell(new Cell().Add(new Paragraph("Nội dung").SetFont(font)));
                        table.AddHeaderCell(new Cell().Add(new Paragraph("Số tiền (VNĐ)").SetFont(font)));

                        table.AddCell(new Cell().Add(new Paragraph("Tiền phòng & Điện nước tháng " + hd.Thang).SetFont(font)));
                        table.AddCell(new Cell().Add(new Paragraph(hd.TongTien.ToString("N0")).SetFont(font)));

                        document.Add(table);

                        // 6. Tổng cộng và chữ ký (Đã bỏ SetBold và SetItalic)
                        document.Add(new Paragraph("\n"));
                        document.Add(new Paragraph($"TỔNG CỘNG: {hd.TongTien.ToString("N0")} VNĐ")
                            .SetFont(font).SetFontSize(14).SetTextAlignment(TextAlignment.RIGHT));

                        document.Add(new Paragraph("\n\n"));
                        document.Add(new Paragraph("Người lập phiếu                               Sinh viên ký tên")
                            .SetFont(font).SetTextAlignment(TextAlignment.CENTER));

                        document.Close();
                    }
                    MessageBox.Show("Đã in hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi in PDF: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}