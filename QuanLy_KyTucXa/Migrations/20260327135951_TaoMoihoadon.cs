using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLy_KyTucXa.Migrations
{
    /// <inheritdoc />
    public partial class TaoMoihoadon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HoaDons",
                columns: table => new
                {
                    MaHoaDon = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MSSV = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    MaQuanLy = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Thang = table.Column<int>(type: "int", nullable: false),
                    Nam = table.Column<int>(type: "int", nullable: false),
                    TongTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDons", x => x.MaHoaDon);
                    table.ForeignKey(
                        name: "FK_HoaDons_QuanLys_MaQuanLy",
                        column: x => x.MaQuanLy,
                        principalTable: "QuanLys",
                        principalColumn: "MaQuanLy",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HoaDons_SinhViens_MSSV",
                        column: x => x.MSSV,
                        principalTable: "SinhViens",
                        principalColumn: "MSSV",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietHoaDons",
                columns: table => new
                {
                    MaChiTiet = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaHoaDon = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenDichVu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    DonViTinh = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DonGia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ThanhTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietHoaDons", x => x.MaChiTiet);
                    table.ForeignKey(
                        name: "FK_ChiTietHoaDons_HoaDons_MaHoaDon",
                        column: x => x.MaHoaDon,
                        principalTable: "HoaDons",
                        principalColumn: "MaHoaDon",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDons_MaHoaDon",
                table: "ChiTietHoaDons",
                column: "MaHoaDon");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_MaQuanLy",
                table: "HoaDons",
                column: "MaQuanLy");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_MSSV",
                table: "HoaDons",
                column: "MSSV");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietHoaDons");

            migrationBuilder.DropTable(
                name: "HoaDons");
        }
    }
}
