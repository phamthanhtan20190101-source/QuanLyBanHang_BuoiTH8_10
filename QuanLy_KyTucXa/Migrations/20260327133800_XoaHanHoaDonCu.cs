using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLy_KyTucXa.Migrations
{
    /// <inheritdoc />
    public partial class XoaHanHoaDonCu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietHoaDon_HoaDon_MaHoaDon",
                table: "ChiTietHoaDon");

            migrationBuilder.DropForeignKey(
                name: "FK_HoaDon_QuanLys_MaQuanLy",
                table: "HoaDon");

            migrationBuilder.DropForeignKey(
                name: "FK_HoaDon_SinhViens_MSSV",
                table: "HoaDon");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HoaDon",
                table: "HoaDon");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChiTietHoaDon",
                table: "ChiTietHoaDon");

            migrationBuilder.RenameTable(
                name: "HoaDon",
                newName: "HoaDons");

            migrationBuilder.RenameTable(
                name: "ChiTietHoaDon",
                newName: "ChiTietHoaDons");

            migrationBuilder.RenameIndex(
                name: "IX_HoaDon_MSSV",
                table: "HoaDons",
                newName: "IX_HoaDons_MSSV");

            migrationBuilder.RenameIndex(
                name: "IX_HoaDon_MaQuanLy",
                table: "HoaDons",
                newName: "IX_HoaDons_MaQuanLy");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTietHoaDon_MaHoaDon",
                table: "ChiTietHoaDons",
                newName: "IX_ChiTietHoaDons_MaHoaDon");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HoaDons",
                table: "HoaDons",
                column: "MaHoaDon");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChiTietHoaDons",
                table: "ChiTietHoaDons",
                column: "MaChiTiet");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietHoaDons_HoaDons_MaHoaDon",
                table: "ChiTietHoaDons",
                column: "MaHoaDon",
                principalTable: "HoaDons",
                principalColumn: "MaHoaDon",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDons_QuanLys_MaQuanLy",
                table: "HoaDons",
                column: "MaQuanLy",
                principalTable: "QuanLys",
                principalColumn: "MaQuanLy",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDons_SinhViens_MSSV",
                table: "HoaDons",
                column: "MSSV",
                principalTable: "SinhViens",
                principalColumn: "MSSV",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
