using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnASP.Areas.Admin.Models
{
    public class ChiTietDatVeModel
    {
        [Key]
        public int IdChiTietDatVe { get; set; }
        [Required(ErrorMessage = "Please enter Number Chair!")]
        public int SoGhe { get; set; }
        public double GiaVe { get; set; }

        public int MaDatVe { get; set; }

        [ForeignKey("MaDatVe")]

        public virtual DatVeModel datVe { get; set; }
    }
}
