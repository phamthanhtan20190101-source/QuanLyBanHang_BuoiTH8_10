using System.ComponentModel.DataAnnotations;

namespace QuanLy_KyTucXa.Data
{
    public class TaiKhoan
    {
        // 1. Tài Khoản (Tên đăng nhập) - Đóng vai trò là Khóa chính
        [Key]
        [StringLength(50)] // Giới hạn độ dài tên đăng nhập
        public string TenTaiKhoan { get; set; } = "";

        // 2. Mật Khẩu
        [Required]
        [StringLength(100)]
        // Lưu ý: Trong thực tế nên lưu mật khẩu đã mã hóa (Hash), không lưu text thường
        public string MatKhau { get; set; } = "";

        // 3. Quyền (Phân quyền)
        // Ví dụ: "Admin", "QuanLy", "SinhVien"
        [StringLength(20)]
        public string Quyen { get; set; } = "";

       
    }
}