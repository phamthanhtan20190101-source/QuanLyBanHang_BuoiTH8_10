using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLy_KyTucXa.Migrations
{
    /// <inheritdoc />
    public partial class ThemCotThangCapNhat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ThangDaCapNhatNo",
                table: "SinhViens",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ThangDaCapNhatNo",
                table: "SinhViens");
        }
    }
}
