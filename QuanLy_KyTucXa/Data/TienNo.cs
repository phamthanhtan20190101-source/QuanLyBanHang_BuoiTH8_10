using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLy_KyTucXa.Data
{
    public class TienNo
    {
        [Key]
        public string MaKhoanNo { get; set; } // Khóa chính (Ví dụ: MKN_001_10_2025)

        public string MSSV { get; set; }      // Mã sinh viên đang nợ

        public int Thang { get; set; }        // Nợ của tháng nào

        public int Nam { get; set; }          // Nợ của năm nào

        public decimal SoTienNo { get; set; } // Số tiền nợ là bao nhiêu

        public string TrangThai { get; set; } // Trạng thái: "Chưa thanh toán" hoặc "Đã thanh toán"

        public string GhiChu { get; set; }    // Ghi chú thêm (nếu có)
    }
}

