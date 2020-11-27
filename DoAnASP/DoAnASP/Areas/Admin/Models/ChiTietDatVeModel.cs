using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnASP.Areas.Admin.Models
{
    public class ChiTietDatVeModel
    {
        [Key]
        public int IdChiTietDatVe { get; set; }


        public int SoGhe { get; set; }

        public double GiaVe { get; set; }

        public int MaDatVe { get; set; }

        [ForeignKey("MaDatVe")]

        public virtual DatVeModel datVe { get; set; }
    }
}
