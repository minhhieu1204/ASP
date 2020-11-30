using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnASP.Areas.Admin.Models
{
    public class ThanhPhoModel
    {
        [Key]
        public int IdThanhPho { get; set; }

        [Required(ErrorMessage = "Tên thành phố không hợp lệ")]
        [StringLength(100)]
        public string TenThanhPho { get; set; }

        public ICollection<QuanHuyenModel> lstQuanHuyen { get; set; }
    }
}
