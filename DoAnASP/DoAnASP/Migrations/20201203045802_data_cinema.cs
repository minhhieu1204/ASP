using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DoAnASP.Migrations
{
    public partial class data_cinema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "giamGiaModels",
                columns: table => new
                {
                    IdMaGiamGia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhanTram = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_giamGiaModels", x => x.IdMaGiamGia);
                });

            migrationBuilder.CreateTable(
                name: "loaiGheModels",
                columns: table => new
                {
                    IdLoaiGhe = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoaiGhe = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    GiaLoaiGhe = table.Column<double>(type: "float", maxLength: 9, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loaiGheModels", x => x.IdLoaiGhe);
                });

            migrationBuilder.CreateTable(
                name: "loaiPhimModels",
                columns: table => new
                {
                    IdLoaiPhim = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoaiPhim = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loaiPhimModels", x => x.IdLoaiPhim);
                });

            migrationBuilder.CreateTable(
                name: "thanhPhoModels",
                columns: table => new
                {
                    IdThanhPho = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenThanhPho = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_thanhPhoModels", x => x.IdThanhPho);
                });

            migrationBuilder.CreateTable(
                name: "userModels",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GioiTinh = table.Column<bool>(type: "bit", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    LoaiTaiKhoan = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userModels", x => x.IdUser);
                });

            migrationBuilder.CreateTable(
                name: "phimModels",
                columns: table => new
                {
                    IdPhim = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenPhim = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ThoiLuong = table.Column<TimeSpan>(type: "time", nullable: false),
                    HinhAnh = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Mota = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaLoaiPhim = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phimModels", x => x.IdPhim);
                    table.ForeignKey(
                        name: "FK_phimModels_loaiPhimModels_MaLoaiPhim",
                        column: x => x.MaLoaiPhim,
                        principalTable: "loaiPhimModels",
                        principalColumn: "IdLoaiPhim",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "quanHuyenModels",
                columns: table => new
                {
                    IdQuanHuyen = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenQuanHuyen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaThanhPho = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quanHuyenModels", x => x.IdQuanHuyen);
                    table.ForeignKey(
                        name: "FK_quanHuyenModels_thanhPhoModels_MaThanhPho",
                        column: x => x.MaThanhPho,
                        principalTable: "thanhPhoModels",
                        principalColumn: "IdThanhPho",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "rapModels",
                columns: table => new
                {
                    IdRap = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenRap = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DiaChiRap = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    MaQuanHuyen = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rapModels", x => x.IdRap);
                    table.ForeignKey(
                        name: "FK_rapModels_quanHuyenModels_MaQuanHuyen",
                        column: x => x.MaQuanHuyen,
                        principalTable: "quanHuyenModels",
                        principalColumn: "IdQuanHuyen",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "phongModels",
                columns: table => new
                {
                    IdPhong = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenPhong = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaRap = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phongModels", x => x.IdPhong);
                    table.ForeignKey(
                        name: "FK_phongModels_rapModels_MaRap",
                        column: x => x.MaRap,
                        principalTable: "rapModels",
                        principalColumn: "IdRap",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "gheModels",
                columns: table => new
                {
                    IdGhe = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenGhe = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false),
                    MaLoaiGhe = table.Column<int>(type: "int", nullable: false),
                    MaPhong = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gheModels", x => x.IdGhe);
                    table.ForeignKey(
                        name: "FK_gheModels_loaiGheModels_MaLoaiGhe",
                        column: x => x.MaLoaiGhe,
                        principalTable: "loaiGheModels",
                        principalColumn: "IdLoaiGhe",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_gheModels_phongModels_MaPhong",
                        column: x => x.MaPhong,
                        principalTable: "phongModels",
                        principalColumn: "IdPhong",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "lichChieuModels",
                columns: table => new
                {
                    IdLichChieu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayChieu = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GioBatDau = table.Column<TimeSpan>(type: "time", nullable: false),
                    GioKetThuc = table.Column<TimeSpan>(type: "time", nullable: false),
                    GiaVe = table.Column<double>(type: "float", maxLength: 9, nullable: false),
                    MaPhong = table.Column<int>(type: "int", nullable: false),
                    MaPhim = table.Column<int>(type: "int", nullable: false),
                    MaGiamGia = table.Column<int>(type: "int", nullable: false),
                    phongIdPhong = table.Column<int>(type: "int", nullable: true),
                    phimIdPhim = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lichChieuModels", x => x.IdLichChieu);
                    table.ForeignKey(
                        name: "FK_lichChieuModels_giamGiaModels_MaGiamGia",
                        column: x => x.MaGiamGia,
                        principalTable: "giamGiaModels",
                        principalColumn: "IdMaGiamGia",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_lichChieuModels_phimModels_phimIdPhim",
                        column: x => x.phimIdPhim,
                        principalTable: "phimModels",
                        principalColumn: "IdPhim",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_lichChieuModels_phongModels_phongIdPhong",
                        column: x => x.phongIdPhong,
                        principalTable: "phongModels",
                        principalColumn: "IdPhong",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "datVeModels",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GioiTinh = table.Column<bool>(type: "bit", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoaiTaiKhoan = table.Column<bool>(type: "bit", nullable: false),
                    LichChieuModelIdLichChieu = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_datVeModels", x => x.IdUser);
                    table.ForeignKey(
                        name: "FK_datVeModels_lichChieuModels_LichChieuModelIdLichChieu",
                        column: x => x.LichChieuModelIdLichChieu,
                        principalTable: "lichChieuModels",
                        principalColumn: "IdLichChieu",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "chiTietDatVeModels",
                columns: table => new
                {
                    IdChiTietDatVe = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoGhe = table.Column<int>(type: "int", nullable: false),
                    GiaVe = table.Column<double>(type: "float", nullable: false),
                    MaDatVe = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chiTietDatVeModels", x => x.IdChiTietDatVe);
                    table.ForeignKey(
                        name: "FK_chiTietDatVeModels_datVeModels_MaDatVe",
                        column: x => x.MaDatVe,
                        principalTable: "datVeModels",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_chiTietDatVeModels_MaDatVe",
                table: "chiTietDatVeModels",
                column: "MaDatVe");

            migrationBuilder.CreateIndex(
                name: "IX_datVeModels_LichChieuModelIdLichChieu",
                table: "datVeModels",
                column: "LichChieuModelIdLichChieu");

            migrationBuilder.CreateIndex(
                name: "IX_gheModels_MaLoaiGhe",
                table: "gheModels",
                column: "MaLoaiGhe");

            migrationBuilder.CreateIndex(
                name: "IX_gheModels_MaPhong",
                table: "gheModels",
                column: "MaPhong");

            migrationBuilder.CreateIndex(
                name: "IX_lichChieuModels_MaGiamGia",
                table: "lichChieuModels",
                column: "MaGiamGia");

            migrationBuilder.CreateIndex(
                name: "IX_lichChieuModels_phimIdPhim",
                table: "lichChieuModels",
                column: "phimIdPhim");

            migrationBuilder.CreateIndex(
                name: "IX_lichChieuModels_phongIdPhong",
                table: "lichChieuModels",
                column: "phongIdPhong");

            migrationBuilder.CreateIndex(
                name: "IX_phimModels_MaLoaiPhim",
                table: "phimModels",
                column: "MaLoaiPhim");

            migrationBuilder.CreateIndex(
                name: "IX_phongModels_MaRap",
                table: "phongModels",
                column: "MaRap");

            migrationBuilder.CreateIndex(
                name: "IX_quanHuyenModels_MaThanhPho",
                table: "quanHuyenModels",
                column: "MaThanhPho");

            migrationBuilder.CreateIndex(
                name: "IX_rapModels_MaQuanHuyen",
                table: "rapModels",
                column: "MaQuanHuyen");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "chiTietDatVeModels");

            migrationBuilder.DropTable(
                name: "gheModels");

            migrationBuilder.DropTable(
                name: "userModels");

            migrationBuilder.DropTable(
                name: "datVeModels");

            migrationBuilder.DropTable(
                name: "loaiGheModels");

            migrationBuilder.DropTable(
                name: "lichChieuModels");

            migrationBuilder.DropTable(
                name: "giamGiaModels");

            migrationBuilder.DropTable(
                name: "phimModels");

            migrationBuilder.DropTable(
                name: "phongModels");

            migrationBuilder.DropTable(
                name: "loaiPhimModels");

            migrationBuilder.DropTable(
                name: "rapModels");

            migrationBuilder.DropTable(
                name: "quanHuyenModels");

            migrationBuilder.DropTable(
                name: "thanhPhoModels");
        }
    }
}
