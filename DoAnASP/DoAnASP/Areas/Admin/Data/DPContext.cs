using DoAnASP.Areas.Admin.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnASP.Areas.Admin.Data
{
    public class DPContext:DbContext
    {

        public DPContext(DbContextOptions<DPContext> options) : base(options)
        { }

        public DbSet<ChiTietDatVeModel> chiTietDatVeModels { get; set; }

        public DbSet<DatVeModel> datVeModels { get; set; }

        public DbSet<LichChieuModel> lichChieuModels { get; set; }
        public DbSet<LoaiPhimModel> loaiPhimModels { get; set; }
        public DbSet<PhimModel> phimModels { get; set; }
        public DbSet<PhongModel> phongModels { get; set; }
        public DbSet<QuanHuyenModel> quanHuyenModels { get; set; }
        public DbSet<RapModel> rapModels { get; set; }
        public DbSet<ThanhPhoModel> thanhPhoModels { get; set; }
        public DbSet<UserModel> userModels { get; set; }

        public DbSet<LoaiGheModel> loaiGheModels { get; set; }
        public DbSet<GheModel> gheModels { get; set; }
        public DbSet<GiamGiaModel> giamGiaModels { get; set; }
    }
}
