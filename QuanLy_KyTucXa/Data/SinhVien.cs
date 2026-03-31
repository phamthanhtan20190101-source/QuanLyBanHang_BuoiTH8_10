using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLy_KyTucXa.Data
{
    public class SinhVien
    {
        // 1. MSSV - Mã số sinh viên (Khóa chính)
        [Key]
        [StringLength(20)]
        public string MSSV { get; set; }

        // 2. Họ Tên
        [Required]
        [StringLength(100)]
        public string HoTen { get; set; }

        // 3. Lớp
        [StringLength(50)]
        public string Lop { get; set; }

        // 4. Số điện thoại (Nên dùng string để giữ số 0 ở đầu)
        [StringLength(15)]
        public string SDT { get; set; }

        // 5. Giới Tính (Lưu "Nam"/"Nữ" hoặc True/False )
        [StringLength(10)]
        public string GioiTinh { get; set; }

        // 6. Ngày Sinh
        public DateTime NgaySinh { get; set; }

        // 7. Ngày Vào (Ngày bắt đầu ở ký túc xá)
        public DateTime NgayVao { get; set; }

        // 8. Quê Quán
        [StringLength(200)]
        public string QueQuan { get; set; }

        [System.ComponentModel.DataAnnotations.StringLength(50)]
        public string TrangThaiTienPhong { get; set; } = "Chưa đóng";

        public decimal TienNo { get; set; } = 0;

        // Lưu lại tháng cuối cùng đã tự động cộng nợ để tránh cộng trùng
        public int ThangDaCapNhatNo { get; set; } = 0;
        // 9. Mã Phòng (Khóa ngoại)


        public string MaPhong { get; set; }

        // Thiết lập liên kết (Foreign Key)
        [ForeignKey("MaPhong")]
        public virtual Phong Phong { get; set; }
    }
}