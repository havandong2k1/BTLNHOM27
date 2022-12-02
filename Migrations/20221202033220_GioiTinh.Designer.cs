﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MvcMovie.Data;

#nullable disable

namespace BTLNHOM27.Migrations
{
    [DbContext(typeof(MvcMovieContext))]
    [Migration("20221202033220_GioiTinh")]
    partial class GioiTinh
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("BTLNHOM27.Models.ChucVu", b =>
                {
                    b.Property<string>("IDChucVu")
                        .HasColumnType("TEXT");

                    b.Property<string>("TenChucVu")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("IDChucVu");

                    b.ToTable("ChucVu");
                });

            modelBuilder.Entity("BTLNHOM27.Models.GioiTinh", b =>
                {
                    b.Property<string>("GioiTinhID")
                        .HasColumnType("TEXT");

                    b.Property<string>("NameGT")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("GioiTinhID");

                    b.ToTable("GioiTinh");
                });

            modelBuilder.Entity("BTLNHOM27.Models.NhanSu", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("GioiTinhID")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("HoVaTen")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("IDChucVu")
                        .IsRequired()
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
                        .HasForeignKey("GioiTinhID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BTLNHOM27.Models.ChucVu", "ChucVu")
                        .WithMany()
                        .HasForeignKey("IDChucVu")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChucVu");

                    b.Navigation("GioiTinh");
                });
#pragma warning restore 612, 618
        }
    }
}
