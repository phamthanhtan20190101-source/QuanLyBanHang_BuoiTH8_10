using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLy_KyTucXa.Data
{
    public class QLKTXDbContext : DbContext
    {
        // 1. Khai báo các bảng dữ liệu (DbSet)
        public DbSet<ToaNha> ToaNhas { get; set; }
        public DbSet<Phong> Phongs { get; set; }
        public DbSet<QuanLy> QuanLys { get; set; }
        public DbSet<SinhVien> SinhViens { get; set; }
        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public DbSet<TaiKhoan> TaiKhoans { get; set; }

        public DbSet<LichSuDongTien> LichSuDongTiens { get; set; }

        // 2. Cấu hình chuỗi kết nối
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Lưu ý: "Data Source=.\\SQLEXPRESS" là tên máy chủ SQL của bạn (theo ảnh lỗi trước)
            optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=QuanLyKyTucXa;Integrated Security=True;TrustServerCertificate=True");
        }

        // 3. Cấu hình mối quan hệ (Fluent API) - KHẮC PHỤC LỖI CASCADE DELETE
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cấu hình: Khi xóa Sinh Viên -> KHÔNG tự động xóa Hóa Đơn (để tránh lỗi vòng lặp)
            modelBuilder.Entity<HoaDon>()
                .HasOne(h => h.SinhVien)
                .WithMany()
                .HasForeignKey(h => h.MSSV)
                .OnDelete(DeleteBehavior.Restrict); // Restrict: Chặn xóa SV nếu còn hóa đơn

            // Cấu hình: Khi xóa Quản Lý -> KHÔNG tự động xóa Hóa Đơn
            modelBuilder.Entity<HoaDon>()
                .HasOne(h => h.QuanLy)
                .WithMany()
                .HasForeignKey(h => h.MaQuanLy)
                .OnDelete(DeleteBehavior.Restrict); 
        }
    }
}