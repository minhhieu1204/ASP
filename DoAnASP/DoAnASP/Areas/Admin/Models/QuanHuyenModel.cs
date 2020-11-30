using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnASP.Areas.Admin.Models
{
    public class QuanHuyenModel
    {
        [Key]
        public int IdQuanHuyen { get; set; }

        [Required(ErrorMessage = "Tên quận (huyện) không hợp lệ")]
        [StringLength(100)]
        public string TenQuanHuyen { get; set; }


        public int MaThanhPho { get; set; }

        [ForeignKey("MaThanhPho")]

        public virtual ThanhPhoModel thanhPho { get; set; }

        public ICollection<RapModel> lstRap { get; set; }
    }
}
