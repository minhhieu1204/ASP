using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnASP.Areas.Admin.Models
{
    public class DatVeModel
    {
        [Key]
        public int IdUser { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public bool GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }

        [DefaultValue(true)]
        public bool LoaiTaiKhoan { get; set; }
    }
}
