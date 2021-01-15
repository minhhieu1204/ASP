using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnASP.Areas.Admin.Models
{
    public class DatVeModel
    {
        [Key]
        public int IdDatVe { get; set; }

        public int SoGhe { get; set; }

        public DateTime NgayDat { get; set; }

        public double TongGia { get; set; }

        public int MaLichChieu { get; set; }

        public bool TrangThaiThanhToan { get; set; }

        [ForeignKey("MaLichChieu")]

        public virtual LichChieuModel lichChieu { get; set; }
        public int MaKhachHang { get; set; }

        [ForeignKey("MaKhachHang")]

        public virtual UserModel khachHang { get; set; }

        public ICollection<ChiTietDatVeModel> lstChiTietDatVe { get; set; }
    }
}
