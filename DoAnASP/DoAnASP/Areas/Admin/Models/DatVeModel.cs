using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnASP.Areas.Admin.Models
{
    public class DatVeModel
    {
        [Key]
        public int IdDatVe { get; set; }
        public int SoGhe { get; set; }
        [Required(ErrorMessage ="Please Enter Date Booking Ticket!")]
        public DateTime NgayDat { get; set; }
        [Required(ErrorMessage = "Please Enter Date Booking Total Price!")]
        public double Tonggia { get; set; }
        [Required(ErrorMessage = "Please Enter Malich!")]
        public int Malichchieu { get; set; }
        [ForeignKey("Malichchieu")]
        public virtual LichChieuModel lichchieu { get; set; }
        [Required(ErrorMessage = "Please Enter Code guest!")]
        public int Makhachhang { get; set; }
        public virtual UserModel User { get; set; }
        public ICollection<ChiTietDatVeModel> lstChitietdatve { get; set; }

    }
}
