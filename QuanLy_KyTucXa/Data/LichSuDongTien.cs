using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLy_KyTucXa.Data
{
   
    
        public class LichSuDongTien
        {
            [Key]
            public string MaThanhToan { get; set; } // Với mã thanh toán là MTT_"Tháng Đóng"_"3 số cuối MSSV"

            public string MSSV { get; set; }

            public int ThangDongTien { get; set; }

            public int NamDongTien { get; set; }

            public decimal SoTien { get; set; }

            public DateTime NgayDong { get; set; }
        }
    }

