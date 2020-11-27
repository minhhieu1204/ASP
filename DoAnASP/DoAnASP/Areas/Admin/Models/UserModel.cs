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

        [Required(ErrorMessage = "Username không hợp lệ")]
        [StringLength(100, MinimumLength = 10)]
        public string Username { get; set; }

        [Required(ErrorMessage = "password không hợp lệ")]
        [StringLength(100)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Họ tên không hợp lệ")]
        [StringLength(100)]
        public string HoTen { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime NgaySinh { get; set; }

        [Required(ErrorMessage = "Chọn giới tính")]
        [DefaultValue(true)]
        public bool GioiTinh { get; set; }

        [Required(ErrorMessage = "Kiểm tra lại địa chỉ")]
        [StringLength(255)]
        public string DiaChi { get; set; }


        [StringLength(10)]
        [RegularExpression(@"^[0]-[0-9]{9}$")]
        [Required(ErrorMessage = "Số điện thoại không hợp lệ")]
        public string SDT { get; set; }

        [Required]
        [DefaultValue(true)]
        public bool LoaiTaiKhoan { get; set; }
    }
}
