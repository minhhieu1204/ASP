using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnASP.Areas.Admin.Models
{
    public class DatVeModel
    {
        [Key]
        public int IdUser { get; set; }
        [StringLength(maximumLength:10,MinimumLength =25,ErrorMessage ="Pleas enter into valid Username")]
        [Required(ErrorMessage = "Pleas enter into valid Username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Pleas enter into valid Username")]
        public string Password { get; set; }
        [StringLength(maximumLength: 10, MinimumLength = 25, ErrorMessage = "Pleas enter into valid Username")]
        [Required(ErrorMessage = "Pleas enter into valid Username")]
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public bool GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }

        [DefaultValue(true)]
        public bool LoaiTaiKhoan { get; set; }
    }
}
