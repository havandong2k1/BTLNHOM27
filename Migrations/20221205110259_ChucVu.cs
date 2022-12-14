using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTLNHOM27.Migrations
{
    /// <inheritdoc />
    public partial class ChucVu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChucVu",
                columns: table => new
                {
                    IDChucVu = table.Column<string>(type: "TEXT", nullable: false),
                    TenChucVu = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChucVu", x => x.IDChucVu);
                });

            migrationBuilder.CreateTable(
                name: "GioiTinh",
                columns: table => new
                {
                    GioiTinhID = table.Column<string>(type: "TEXT", nullable: false),
                    NameGT = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GioiTinh", x => x.GioiTinhID);
                });

            migrationBuilder.CreateTable(
                name: "HopDongNS",
                columns: table => new
                {
                    MaNhanVien = table.Column<string>(type: "TEXT", nullable: false),
                    PhongBan = table.Column<string>(type: "TEXT", nullable: false),
                    ViTri = table.Column<string>(type: "TEXT", nullable: true),
                    Luong = table.Column<string>(type: "TEXT", nullable: false),
                    TrangThai = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HopDongNS", x => x.MaNhanVien);
                });

            migrationBuilder.CreateTable(
                name: "NhanSu",
                columns: table => new
                {
                    ID = table.Column<string>(type: "TEXT", nullable: false),
                    HoVaTen = table.Column<string>(type: "TEXT", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "TEXT", nullable: true),
                    GioiTinhID = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    SDT = table.Column<string>(type: "TEXT", nullable: false),
                    SoCanCuoc = table.Column<string>(type: "TEXT", nullable: false),
                    IDChucVu = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanSu", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NhanSu_ChucVu_IDChucVu",
                        column: x => x.IDChucVu,
                        principalTable: "ChucVu",
                        principalColumn: "IDChucVu");
                    table.ForeignKey(
                        name: "FK_NhanSu_GioiTinh_GioiTinhID",
                        column: x => x.GioiTinhID,
                        principalTable: "GioiTinh",
                        principalColumn: "GioiTinhID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_NhanSu_GioiTinhID",
                table: "NhanSu",
                column: "GioiTinhID");

            migrationBuilder.CreateIndex(
                name: "IX_NhanSu_IDChucVu",
                table: "NhanSu",
                column: "IDChucVu");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HopDongNS");

            migrationBuilder.DropTable(
                name: "NhanSu");

            migrationBuilder.DropTable(
                name: "ChucVu");

            migrationBuilder.DropTable(
                name: "GioiTinh");
        }
    }
}
