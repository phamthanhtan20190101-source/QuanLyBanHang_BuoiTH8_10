using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLy_KyTucXa.Migrations
{
    /// <inheritdoc />
    public partial class TaoBangMoi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LichSuDongTiens",
                columns: table => new
                {
                    MaThanhToan = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MSSV = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThangDongTien = table.Column<int>(type: "int", nullable: false),
                    NamDongTien = table.Column<int>(type: "int", nullable: false),
                    SoTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NgayDong = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LichSuDongTiens", x => x.MaThanhToan);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LichSuDongTiens");
        }
    }
}
