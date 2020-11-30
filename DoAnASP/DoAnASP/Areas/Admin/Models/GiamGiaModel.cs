using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnASP.Areas.Admin.Models
{
    public class GiamGiaModel
    {
        [Key]
        public int IdMaGiamGia { get; set; }
        [Required(ErrorMessage = "Please enter value percent discount!")]
        public int PhanTram { get; set; }

        public ICollection<LichChieuModel> lstLichChieu { get; set; }
    }
}
