using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnASP.Areas.Admin.Models
{
    public class LoaiPhimModel
    {
        [Key]
        public int IdLoaiPhim { get; set; }
        [StringLength(maximumLength: 25, MinimumLength = 10, ErrorMessage = "Value from 10 to 25 character!")]
        [Required(ErrorMessage = "Please enter Name Film! ")]
        public string TenLoaiPhim { get; set; }

        public ICollection<PhimModel> lstPhim { get; set; }
    }
}
