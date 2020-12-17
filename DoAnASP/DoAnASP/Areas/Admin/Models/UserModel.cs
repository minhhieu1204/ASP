using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnASP.Areas.Admin.Models
{
    public class UserModel
    {
        [Key]
        public int IdUser { get; set; }
        [StringLength(maximumLength: 25, MinimumLength = 10, ErrorMessage = "Value from 10 to 25 character!")]
        [Required(ErrorMessage = "Please enter  value Username!")]
        public string Username { get; set; }
        [StringLength(maximumLength: 100, MinimumLength = 6, ErrorMessage = "Value from 6 to 100 character!")]
        [Required(ErrorMessage = "Please enter  value Password!")]
        public string Password { get; set; }
        [StringLength(maximumLength: 50, MinimumLength = 10, ErrorMessage = "Value from 10 to 50 character!")]
        [Required(ErrorMessage = "Please enter  value Name!")]
        public string HoTen { get; set; }
        [Required(ErrorMessage = "Please enter  value Date of birtday!")]
        public DateTime NgaySinh { get; set; }
        public bool GioiTinh { get; set; }
        [StringLength(maximumLength: 100, MinimumLength = 4, ErrorMessage = "Value from 4 to 100 character!")]
        [Required(ErrorMessage = "Please enter  value Address!")]
        public string DiaChi { get; set; }
        [Phone(ErrorMessage = "Sai Format Phone Number!")]
        [Required(ErrorMessage = "Please enter  value Phone!")]
        public string SDT { get; set; }

        [DefaultValue(true)]
        public bool LoaiTaiKhoan { get; set; }
    }
}
