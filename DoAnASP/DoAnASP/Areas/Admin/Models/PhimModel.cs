﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnASP.Areas.Admin.Models
{
    public class PhimModel
    {
        [Key]
        public int IdPhim { get; set; }

        [Required(ErrorMessage = "Tên phim không hợp lệ")]
        [StringLength(100)]
        public string TenPhim { get; set; }

        [Required]
        public TimeSpan ThoiLuong { get; set; }

        
        [StringLength(255)]
        
        public string HinhAnh { get; set; }
        public string Mota { get; set; }
        public string LinkPhim { get; set; }
        public int MaLoaiPhim { get; set; }
        [ForeignKey("MaLoaiPhim")]
        public virtual LoaiPhimModel loaiPhim { get; set; }

        public ICollection<LichChieuModel> lstLichChieu { get; set; }
    }
}
