using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnASP.Areas.Admin.Models
{
    public class GheModel
    {
        [Key]
        public int IdGhe { get; set; }
        [StringLength(maximumLength: 25, MinimumLength = 10, ErrorMessage = "Value from 10 to 25 character!")]
        [Required(ErrorMessage = "Please enter  value Chair!")]
        public string TenGhe { get; set; }

        public bool TrangThai { get; set; }

        public int MaLoaiGhe { get; set; }
        [ForeignKey("MaLoaiGhe")]

        public virtual LoaiGheModel loaiGhe { get; set; }

        public int MaPhong { get; set; }

        [ForeignKey("MaPhong")]

        public virtual PhongModel phong { get; set; }
    }
}
