using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLy_KyTucXa.Data
{
    public class NhatKyHeThong
    {
        [Key]
        public int MaNhatKy { get; set; }
        public string TenNguoiDung { get; set; }
        public DateTime ThoiGian { get; set; }
        public string HanhDong { get; set; }
        public string ChiTiet { get; set; }
    }
}
