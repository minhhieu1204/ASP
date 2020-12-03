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
        [StringLength(maximumLength: 50, MinimumLength = 5, ErrorMessage = "Value from 5 to 50 character!")]
        [Required(ErrorMessage = "Please enter Name Type Film! ")]
        public string TenLoaiPhim { get; set; }

        public ICollection<PhimModel> lstPhim { get; set; }
    }
}
