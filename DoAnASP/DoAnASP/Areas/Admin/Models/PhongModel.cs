using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnASP.Areas.Admin.Models
{
    public class PhongModel
    {

        [Key]
        public int IdPhong { get; set; }

        [Required(ErrorMessage = "Tên phòng không hợp lệ")]
        [StringLength(100)]
        public string TenPhong { get; set; }

        public int MaRap { get; set; }

        [ForeignKey("MaRap")]

        public virtual RapModel rap { get; set; }

        public ICollection<LichChieuModel> lstLichChieu { get; set; }

        public ICollection<GheModel> lstGhe { get; set; }
    }
}
