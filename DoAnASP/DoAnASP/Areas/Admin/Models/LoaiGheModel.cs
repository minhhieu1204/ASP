using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnASP.Areas.Admin.Models
{
    public class LoaiGheModel
    {
        [Key]
        public int IdLoaiGhe { get; set; }
        [StringLength(maximumLength: 25, MinimumLength = 5, ErrorMessage = "Value from 10 to 25 character!")]
        [Required(ErrorMessage = "Please enter  value Chair!")]
        public string TenLoaiGhe { get; set; }
        [Required(ErrorMessage = "Please enter  value Price Chair!")]
        public double GiaLoaiGhe { get; set; }

        public ICollection<GheModel> lstGhe { get; set; }
    }
}
