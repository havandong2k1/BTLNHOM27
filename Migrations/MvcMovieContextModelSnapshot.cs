﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MvcMovie.Data;

#nullable disable

namespace BTLNHOM27.Migrations
{
    [DbContext(typeof(MvcMovieContext))]
    partial class MvcMovieContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("BTLNHOM27.Models.ChucVu", b =>
                {
                    b.Property<string>("IDChucVu")
                        .HasColumnType("TEXT");

                    b.Property<string>("TenChucVu")
                        .HasColumnType("TEXT");

                    b.HasKey("IDChucVu");

                    b.ToTable("ChucVu");
                });

            modelBuilder.Entity("BTLNHOM27.Models.GioiTinh", b =>
                {
                    b.Property<string>("GioiTinhID")
                        .HasColumnType("TEXT");

                    b.Property<string>("NameGT")
                        .HasColumnType("TEXT");

                    b.HasKey("GioiTinhID");

                    b.ToTable("GioiTinh");
                });

            modelBuilder.Entity("BTLNHOM27.Models.HopDongNS", b =>
                {
                    b.Property<string>("MaNhanVien")
                        .HasColumnType("TEXT");

                    b.Property<string>("Luong")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhongBan")
                        .HasColumnType("TEXT");

                    b.Property<string>("TrangThai")
                        .HasColumnType("TEXT");

                    b.Property<string>("ViTri")
                        .HasColumnType("TEXT");

                    b.HasKey("MaNhanVien");

                    b.ToTable("HopDongNS");
                });

            modelBuilder.Entity("BTLNHOM27.Models.NhanSu", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("GioiTinhID")
                        .HasColumnType("TEXT");

                    b.Property<string>("HoVaTen")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("IDChucVu")
                        .HasColumnType("TEXT");

                    b.Property<string>("SDT")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SoCanCuoc")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("GioiTinhID");

                    b.HasIndex("IDChucVu");

                    b.ToTable("NhanSu");
                });

            modelBuilder.Entity("BTLNHOM27.Models.NhanSu", b =>
                {
                    b.HasOne("BTLNHOM27.Models.GioiTinh", "GioiTinh")
                        .WithMany()
                        .HasForeignKey("GioiTinhID");

                    b.HasOne("BTLNHOM27.Models.ChucVu", "ChucVu")
                        .WithMany()
                        .HasForeignKey("IDChucVu");

                    b.Navigation("ChucVu");

                    b.Navigation("GioiTinh");
                });
#pragma warning restore 612, 618
        }
    }
}
