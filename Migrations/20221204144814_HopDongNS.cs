using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTLNHOM27.Migrations
{
    /// <inheritdoc />
    public partial class HopDongNS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NhanSu_ChucVu_IDChucVu",
                table: "NhanSu");

            migrationBuilder.DropForeignKey(
                name: "FK_NhanSu_GioiTinh_GioiTinhID",
                table: "NhanSu");

            migrationBuilder.AlterColumn<string>(
                name: "IDChucVu",
                table: "NhanSu",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "GioiTinhID",
                table: "NhanSu",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "NameGT",
                table: "GioiTinh",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "TenChucVu",
                table: "ChucVu",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.CreateTable(
                name: "HopDongNS",
                columns: table => new
                {
                    MaNhanVien = table.Column<string>(type: "TEXT", nullable: false),
                    PhongBan = table.Column<string>(type: "TEXT", nullable: true),
                    ViTri = table.Column<string>(type: "TEXT", nullable: true),
                    Luong = table.Column<string>(type: "TEXT", nullable: true),
                    TrangThai = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HopDongNS", x => x.MaNhanVien);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_NhanSu_ChucVu_IDChucVu",
                table: "NhanSu",
                column: "IDChucVu",
                principalTable: "ChucVu",
                principalColumn: "IDChucVu");

            migrationBuilder.AddForeignKey(
                name: "FK_NhanSu_GioiTinh_GioiTinhID",
                table: "NhanSu",
                column: "GioiTinhID",
                principalTable: "GioiTinh",
                principalColumn: "GioiTinhID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NhanSu_ChucVu_IDChucVu",
                table: "NhanSu");

            migrationBuilder.DropForeignKey(
                name: "FK_NhanSu_GioiTinh_GioiTinhID",
                table: "NhanSu");

            migrationBuilder.DropTable(
                name: "HopDongNS");

            migrationBuilder.AlterColumn<string>(
                name: "IDChucVu",
                table: "NhanSu",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GioiTinhID",
                table: "NhanSu",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NameGT",
                table: "GioiTinh",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TenChucVu",
                table: "ChucVu",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_NhanSu_ChucVu_IDChucVu",
                table: "NhanSu",
                column: "IDChucVu",
                principalTable: "ChucVu",
                principalColumn: "IDChucVu",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NhanSu_GioiTinh_GioiTinhID",
                table: "NhanSu",
                column: "GioiTinhID",
                principalTable: "GioiTinh",
                principalColumn: "GioiTinhID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
