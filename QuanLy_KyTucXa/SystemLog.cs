using QuanLy_KyTucXa.Data;
using QuanLy_KyTucXa.Forms;
using System;
using System.Windows.Forms;

namespace QuanLy_KyTucXa
{
    public static class SystemLog
    {
        // Hàm GhiNhatKy dùng từ khóa 'static' để có thể gọi ở bất cứ đâu mà không cần dùng lệnh 'new'
        public static void GhiNhatKy(string hanhDong, string chiTiet = "")
        {
            try
            {
                using (var context = new QLKTXDbContext())
                {
                    // Tự động kiểm tra xem Form Main có đang mở không để lấy Mã người dùng
                    string nguoiDung = "Hệ thống";
                    if (Application.OpenForms["frmMain"] != null)
                    {
                        // Lấy biến static MaNguoiDungHienTai từ frmMain
                        nguoiDung = frmMain.MaNguoiDungHienTai ?? "Hệ thống";
                    }

                    // Khởi tạo một bản ghi nhật ký mới
                    var log = new NhatKyHeThong
                    {
                        TenNguoiDung = nguoiDung,
                        ThoiGian = DateTime.Now,
                        HanhDong = hanhDong,
                        ChiTiet = chiTiet
                    };

                    // Thêm vào database và lưu lại
                    context.NhatKyHeThongs.Add(log);
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                // Bắt lỗi rỗng (Try-Catch) để nếu quá trình ghi log gặp sự cố mạng/DB, 
                // phần mềm vẫn chạy tiếp bình thường chứ không bị văng lỗi ra màn hình.
            }
        }
    }
}