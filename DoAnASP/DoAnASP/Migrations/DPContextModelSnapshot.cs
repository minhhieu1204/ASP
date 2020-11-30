﻿// <auto-generated />
using System;
using DoAnASP.Areas.Admin.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DoAnASP.Migrations
{
    [DbContext(typeof(DPContext))]
    partial class DPContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("DoAnASP.Areas.Admin.Models.ChiTietDatVeModel", b =>
                {
                    b.Property<int>("IdChiTietDatVe")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<double>("GiaVe")
                        .HasColumnType("float");

                    b.Property<int>("MaDatVe")
                        .HasColumnType("int");

                    b.Property<int>("SoGhe")
                        .HasColumnType("int");

                    b.HasKey("IdChiTietDatVe");

                    b.HasIndex("MaDatVe");

                    b.ToTable("chiTietDatVeModels");
                });

            modelBuilder.Entity("DoAnASP.Areas.Admin.Models.DatVeModel", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<bool>("GioiTinh")
                        .HasColumnType("bit");

                    b.Property<string>("HoTen")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<int?>("LichChieuModelIdLichChieu")
                        .HasColumnType("int");

                    b.Property<bool>("LoaiTaiKhoan")
                        .HasColumnType("bit");

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("SDT")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("IdUser");

                    b.HasIndex("LichChieuModelIdLichChieu");

                    b.ToTable("datVeModels");
                });

            modelBuilder.Entity("DoAnASP.Areas.Admin.Models.GheModel", b =>
                {
                    b.Property<int>("IdGhe")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("MaLoaiGhe")
                        .HasColumnType("int");

                    b.Property<int>("MaPhong")
                        .HasColumnType("int");

                    b.Property<string>("TenGhe")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.HasKey("IdGhe");

                    b.HasIndex("MaLoaiGhe");

                    b.HasIndex("MaPhong");

                    b.ToTable("gheModels");
                });

            modelBuilder.Entity("DoAnASP.Areas.Admin.Models.GiamGiaModel", b =>
                {
                    b.Property<int>("IdMaGiamGia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("PhanTram")
                        .HasColumnType("int");

                    b.HasKey("IdMaGiamGia");

                    b.ToTable("giamGiaModels");
                });

            modelBuilder.Entity("DoAnASP.Areas.Admin.Models.LichChieuModel", b =>
                {
                    b.Property<int>("IdLichChieu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<double>("GiaVe")
                        .HasMaxLength(9)
                        .HasColumnType("float");

                    b.Property<TimeSpan>("GioBatDau")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("GioKetThuc")
                        .HasColumnType("time");

                    b.Property<int>("MaGiamGia")
                        .HasColumnType("int");

                    b.Property<int>("MaPhim")
                        .HasColumnType("int");

                    b.Property<int>("MaPhong")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayChieu")
                        .HasColumnType("datetime2");

                    b.Property<int?>("phimIdPhim")
                        .HasColumnType("int");

                    b.Property<int?>("phongIdPhong")
                        .HasColumnType("int");

                    b.HasKey("IdLichChieu");

                    b.HasIndex("MaGiamGia");

                    b.HasIndex("phimIdPhim");

                    b.HasIndex("phongIdPhong");

                    b.ToTable("lichChieuModels");
                });

            modelBuilder.Entity("DoAnASP.Areas.Admin.Models.LoaiGheModel", b =>
                {
                    b.Property<int>("IdLoaiGhe")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<double>("GiaLoaiGhe")
                        .HasMaxLength(9)
                        .HasColumnType("float");

                    b.Property<string>("TenLoaiGhe")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("IdLoaiGhe");

                    b.ToTable("loaiGheModels");
                });

            modelBuilder.Entity("DoAnASP.Areas.Admin.Models.LoaiPhimModel", b =>
                {
                    b.Property<int>("IdLoaiPhim")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("TenLoaiPhim")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("IdLoaiPhim");

                    b.ToTable("loaiPhimModels");
                });

            modelBuilder.Entity("DoAnASP.Areas.Admin.Models.PhimModel", b =>
                {
                    b.Property<int>("IdPhim")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("HinhAnh")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("MaLoaiPhim")
                        .HasColumnType("int");

                    b.Property<string>("TenPhim")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<TimeSpan>("ThoiLuong")
                        .HasColumnType("time");

                    b.HasKey("IdPhim");

                    b.HasIndex("MaLoaiPhim");

                    b.ToTable("phimModels");
                });

            modelBuilder.Entity("DoAnASP.Areas.Admin.Models.PhongModel", b =>
                {
                    b.Property<int>("IdPhong")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("MaRap")
                        .HasColumnType("int");

                    b.Property<string>("TenPhong")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdPhong");

                    b.HasIndex("MaRap");

                    b.ToTable("phongModels");
                });

            modelBuilder.Entity("DoAnASP.Areas.Admin.Models.QuanHuyenModel", b =>
                {
                    b.Property<int>("IdQuanHuyen")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("MaThanhPho")
                        .HasColumnType("int");

                    b.Property<string>("TenQuanHuyen")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdQuanHuyen");

                    b.HasIndex("MaThanhPho");

                    b.ToTable("quanHuyenModels");
                });

            modelBuilder.Entity("DoAnASP.Areas.Admin.Models.RapModel", b =>
                {
                    b.Property<int>("IdRap")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("DiaChiRap")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("MaQuanHuyen")
                        .HasColumnType("int");

                    b.Property<string>("TenRap")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdRap");

                    b.HasIndex("MaQuanHuyen");

                    b.ToTable("rapModels");
                });

            modelBuilder.Entity("DoAnASP.Areas.Admin.Models.ThanhPhoModel", b =>
                {
                    b.Property<int>("IdThanhPho")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("TenThanhPho")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdThanhPho");

                    b.ToTable("thanhPhoModels");
                });

            modelBuilder.Entity("DoAnASP.Areas.Admin.Models.UserModel", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("GioiTinh")
                        .HasColumnType("bit");

                    b.Property<string>("HoTen")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("LoaiTaiKhoan")
                        .HasColumnType("bit");

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SDT")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdUser");

                    b.ToTable("userModels");
                });

            modelBuilder.Entity("DoAnASP.Areas.Admin.Models.ChiTietDatVeModel", b =>
                {
                    b.HasOne("DoAnASP.Areas.Admin.Models.DatVeModel", "datVe")
                        .WithMany()
                        .HasForeignKey("MaDatVe")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("datVe");
                });

            modelBuilder.Entity("DoAnASP.Areas.Admin.Models.DatVeModel", b =>
                {
                    b.HasOne("DoAnASP.Areas.Admin.Models.LichChieuModel", null)
                        .WithMany("lstDatVe")
                        .HasForeignKey("LichChieuModelIdLichChieu");
                });

            modelBuilder.Entity("DoAnASP.Areas.Admin.Models.GheModel", b =>
                {
                    b.HasOne("DoAnASP.Areas.Admin.Models.LoaiGheModel", "loaiGhe")
                        .WithMany("lstGhe")
                        .HasForeignKey("MaLoaiGhe")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoAnASP.Areas.Admin.Models.PhongModel", "phong")
                        .WithMany("lstGhe")
                        .HasForeignKey("MaPhong")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("loaiGhe");

                    b.Navigation("phong");
                });

            modelBuilder.Entity("DoAnASP.Areas.Admin.Models.LichChieuModel", b =>
                {
                    b.HasOne("DoAnASP.Areas.Admin.Models.GiamGiaModel", "giamGia")
                        .WithMany("lstLichChieu")
                        .HasForeignKey("MaGiamGia")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoAnASP.Areas.Admin.Models.PhimModel", "phim")
                        .WithMany("lstLichChieu")
                        .HasForeignKey("phimIdPhim");

                    b.HasOne("DoAnASP.Areas.Admin.Models.PhongModel", "phong")
                        .WithMany("lstLichChieu")
                        .HasForeignKey("phongIdPhong");

                    b.Navigation("giamGia");

                    b.Navigation("phim");

                    b.Navigation("phong");
                });

            modelBuilder.Entity("DoAnASP.Areas.Admin.Models.PhimModel", b =>
                {
                    b.HasOne("DoAnASP.Areas.Admin.Models.LoaiPhimModel", "loaiPhim")
                        .WithMany("lstPhim")
                        .HasForeignKey("MaLoaiPhim")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("loaiPhim");
                });

            modelBuilder.Entity("DoAnASP.Areas.Admin.Models.PhongModel", b =>
                {
                    b.HasOne("DoAnASP.Areas.Admin.Models.RapModel", "rap")
                        .WithMany("lstPhong")
                        .HasForeignKey("MaRap")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("rap");
                });

            modelBuilder.Entity("DoAnASP.Areas.Admin.Models.QuanHuyenModel", b =>
                {
                    b.HasOne("DoAnASP.Areas.Admin.Models.ThanhPhoModel", "thanhPho")
                        .WithMany("lstQuanHuyen")
                        .HasForeignKey("MaThanhPho")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("thanhPho");
                });

            modelBuilder.Entity("DoAnASP.Areas.Admin.Models.RapModel", b =>
                {
                    b.HasOne("DoAnASP.Areas.Admin.Models.QuanHuyenModel", "quanHuyen")
                        .WithMany("lstRap")
                        .HasForeignKey("MaQuanHuyen")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("quanHuyen");
                });

            modelBuilder.Entity("DoAnASP.Areas.Admin.Models.GiamGiaModel", b =>
                {
                    b.Navigation("lstLichChieu");
                });

            modelBuilder.Entity("DoAnASP.Areas.Admin.Models.LichChieuModel", b =>
                {
                    b.Navigation("lstDatVe");
                });

            modelBuilder.Entity("DoAnASP.Areas.Admin.Models.LoaiGheModel", b =>
                {
                    b.Navigation("lstGhe");
                });

            modelBuilder.Entity("DoAnASP.Areas.Admin.Models.LoaiPhimModel", b =>
                {
                    b.Navigation("lstPhim");
                });

            modelBuilder.Entity("DoAnASP.Areas.Admin.Models.PhimModel", b =>
                {
                    b.Navigation("lstLichChieu");
                });

            modelBuilder.Entity("DoAnASP.Areas.Admin.Models.PhongModel", b =>
                {
                    b.Navigation("lstGhe");

                    b.Navigation("lstLichChieu");
                });

            modelBuilder.Entity("DoAnASP.Areas.Admin.Models.QuanHuyenModel", b =>
                {
                    b.Navigation("lstRap");
                });

            modelBuilder.Entity("DoAnASP.Areas.Admin.Models.RapModel", b =>
                {
                    b.Navigation("lstPhong");
                });

            modelBuilder.Entity("DoAnASP.Areas.Admin.Models.ThanhPhoModel", b =>
                {
                    b.Navigation("lstQuanHuyen");
                });
#pragma warning restore 612, 618
        }
    }
}
