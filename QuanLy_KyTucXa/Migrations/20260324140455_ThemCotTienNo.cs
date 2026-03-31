using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLy_KyTucXa.Migrations
{
    /// <inheritdoc />
    public partial class ThemCotTienNo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TienNo",
                table: "SinhViens",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TienNo",
                table: "SinhViens");
        }
    }
}
