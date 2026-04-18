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

        public static void XuatDonPDF(string loaiDon, SinhVien sv, string tenToaNha, string tenQuanLy)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = $"DonXin_{loaiDon.Replace(" ", "")}_{sv.MSSV}.pdf";
            sfd.Filter = "PDF File | *.pdf";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (FileStream fs = new FileStream(sfd.FileName, FileMode.Create))
                    {
                        iText.Kernel.Pdf.PdfWriter writer = new iText.Kernel.Pdf.PdfWriter(fs);
                        iText.Kernel.Pdf.PdfDocument pdf = new iText.Kernel.Pdf.PdfDocument(writer);
                        iText.Layout.Document document = new iText.Layout.Document(pdf);

                        // --- SỬA LỖI Ở ĐÂY: Dùng iText.Kernel.Font.PdfFontFactory thay vì IO ---
                        string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "Arial.ttf");
                        iText.Kernel.Font.PdfFont font = iText.Kernel.Font.PdfFontFactory.CreateFont(fontPath, iText.IO.Font.PdfEncodings.IDENTITY_H);

                        // Quốc hiệu, Tiêu ngữ
                        document.Add(new iText.Layout.Element.Paragraph("CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM")
                            .SetFont(font).SetFontSize(14).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));
                        document.Add(new iText.Layout.Element.Paragraph("Độc lập - Tự do - Hạnh phúc")
                            .SetFont(font).SetFontSize(13).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));
                        document.Add(new iText.Layout.Element.Paragraph("------------------------\n").SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));

                        // Tên đơn
                        document.Add(new iText.Layout.Element.Paragraph($"ĐƠN XIN {loaiDon.ToUpper()}")
                            .SetFont(font).SetFontSize(18).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));

                        document.Add(new iText.Layout.Element.Paragraph("\n"));

                        // Kính gửi
                        document.Add(new iText.Layout.Element.Paragraph($"Kính gửi: Ban Quản lý KTX - Người quản lý tòa nhà {tenToaNha}")
                            .SetFont(font).SetFontSize(12));

                        document.Add(new iText.Layout.Element.Paragraph("\n"));

                        // Thông tin sinh viên
                        document.Add(new iText.Layout.Element.Paragraph($"Tên tôi là: {sv.HoTen}").SetFont(font));
                        document.Add(new iText.Layout.Element.Paragraph($"Mã số sinh viên: {sv.MSSV}            Lớp: {sv.Lop}").SetFont(font));
                        document.Add(new iText.Layout.Element.Paragraph($"Số điện thoại: {sv.SDT}").SetFont(font));
                        document.Add(new iText.Layout.Element.Paragraph($"Hiện đang lưu trú tại phòng: {sv.MaPhong} (Tòa nhà {tenToaNha})").SetFont(font));

                        document.Add(new iText.Layout.Element.Paragraph("\n"));

                        // Lý do
                        document.Add(new iText.Layout.Element.Paragraph("Nay tôi làm đơn này để xin phép được " + loaiDon.ToLower() + " với lý do:").SetFont(font));
                        document.Add(new iText.Layout.Element.Paragraph("......................................................................................................................................").SetFont(font));
                        document.Add(new iText.Layout.Element.Paragraph("......................................................................................................................................").SetFont(font));
                        document.Add(new iText.Layout.Element.Paragraph("......................................................................................................................................").SetFont(font));

                        // Lời cam đoan
                        document.Add(new iText.Layout.Element.Paragraph("\nKính mong Ban Quản lý xem xét và giải quyết. Tôi xin chân thành cảm ơn!\n\n").SetFont(font));

                        // --- PHẦN MỚI: CHỮ KÝ VÀ TÊN HIỂN THỊ (Dùng Table 2 cột ẩn viền để canh giữa hoàn hảo) ---
                        iText.Layout.Element.Table tableChuKy = new iText.Layout.Element.Table(2).UseAllAvailableWidth();

                        // Cột trái: Quản lý
                        iText.Layout.Element.Cell cellQuanLy = new iText.Layout.Element.Cell()
                            .Add(new iText.Layout.Element.Paragraph("Người quản lý\n(Ký và ghi rõ họ tên)\n\n\n\n" + tenQuanLy)
                            .SetFont(font).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER))
                            .SetBorder(iText.Layout.Borders.Border.NO_BORDER);

                        // Cột phải: Sinh viên
                        iText.Layout.Element.Cell cellSinhVien = new iText.Layout.Element.Cell()
                            .Add(new iText.Layout.Element.Paragraph("Sinh viên ký tên\n(Ký và ghi rõ họ tên)\n\n\n\n" + sv.HoTen)
                            .SetFont(font).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER))
                            .SetBorder(iText.Layout.Borders.Border.NO_BORDER);

                        tableChuKy.AddCell(cellQuanLy);
                        tableChuKy.AddCell(cellSinhVien);

                        document.Add(tableChuKy);
                        // --------------------------------------------------------------------------------------

                        document.Close();
                    }
                    MessageBox.Show($"Đã lưu {loaiDon} thành công dưới dạng PDF!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xuất PDF: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}