using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLy_KyTucXa.Data
{
    public class ChiTietHoaDon
    {
        // Mã chi tiết (Tự tăng)
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaChiTiet { get; set; }

        // Liên kết về Hóa Đơn cha
        public string MaHoaDon { get; set; }
        [ForeignKey("MaHoaDon")]
        public virtual HoaDon HoaDon { get; set; }

        // Tên dịch vụ (Ví dụ: "Tiền Phòng", "Tiền Điện", "Tiền Nước", "Vệ sinh")
        [StringLength(100)]
        public string TenDichVu { get; set; }
        //Tiền điện nước
        
        public int SoLuong { get; set; }

        // Đơn vị tính (Ví dụ: "kwh", "khối", "tháng")
        [StringLength(20)]
        public string DonViTinh { get; set; }

        // Đơn giá
        public decimal DonGia { get; set; }

        // Thành tiền (Thường = SoLuong * DonGia)
        public decimal ThanhTien { get; set; }
    }
}