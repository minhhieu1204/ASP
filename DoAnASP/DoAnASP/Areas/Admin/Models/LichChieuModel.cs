using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnASP.Areas.Admin.Models
{
    public class LichChieuModel
    {
        [Key]
        public int IdLichChieu { get; set; }

        [Required(ErrorMessage = "Please enter  value Ngày chiếu!")]
        public DateTime NgayChieu { get; set; }
        [Required(ErrorMessage = "Please enter  value Tiem start!")]
        public TimeSpan GioBatDau { get; set; }
        [Required(ErrorMessage = "Please enter  value Time End!")]
        public TimeSpan GioKetThuc { get; set; }
        [Required(ErrorMessage = "Please enter  value Time End!")]
        [StringLength(9)]
        public double GiaVe { get; set; }

        public int MaPhong { get; set; }

        [ForeignKey("MaPhong")]

        public int MaPhim { get; set; }

        [ForeignKey("MaPhim")]

        public int MaGiamGia { get; set; }

        [ForeignKey("MaGiamGia")]

        public virtual GiamGiaModel giamGia { get; set; }

        public virtual PhongModel phong { get; set; }

        public virtual PhimModel phim { get; set; }

        public ICollection<DatVeModel> lstDatVe { get; set; }
    }
}
