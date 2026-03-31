using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLy_KyTucXa.Data
{
    public class HoaDon
    {
        // Mã hóa đơn: Tự tăng (Identity), không cần nhập tay
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string MaHoaDon { get; set; }

        // --- THÔNG TIN ĐỐI TƯỢNG ---
        // Sinh viên
        [Required]
        public string MSSV { get; set; }
        [ForeignKey("MSSV")]
        public virtual SinhVien SinhVien { get; set; }

        // Người quản lý
        public string MaQuanLy { get; set; }
        [ForeignKey("MaQuanLy")]
        public virtual QuanLy QuanLy { get; set; }

        // --- THÔNG TIN THỜI GIAN ---
        public DateTime NgayTao { get; set; } = DateTime.Now;

        // Tháng/Năm của hóa đơn này 
        public int Thang { get; set; }
        public int Nam { get; set; }

        // --- TRẠNG THÁI THANH TOÁN ---
        // Tổng tiền phải trả (Tổng cộng từ các chi tiết)
        public decimal TongTien { get; set; }

        // Trạng thái: True = Đã đóng, False = Chưa đóng
        public string TrangThai { get; set; } 

        // Danh sách các mục chi tiết trong hóa đơn này
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();
    }
}