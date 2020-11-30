using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnASP.Areas.Admin.Models
{
    public class RapModel
    {
        [Key]
        public int IdRap { get; set; }

        [Required(ErrorMessage = "Tên rạp không hợp lệ")]
        [StringLength(100)]
        public string TenRap { get; set; }

        [Required(ErrorMessage = "Địa chỉ rạp không hợp lệ")]
        [StringLength(255)]
        public string DiaChiRap { get; set; }

        public int MaQuanHuyen { get; set; }

        [ForeignKey("MaQuanHuyen")]

        public virtual QuanHuyenModel quanHuyen { get; set; }

        public ICollection<PhongModel> lstPhong { get; set; }
    }
}
