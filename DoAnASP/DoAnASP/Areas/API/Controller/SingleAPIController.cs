using DoAnASP.Areas.Admin.Data;
using DoAnASP.Areas.Admin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DoAnASP.Areas.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SingleAPIController : ControllerBase
    {
        private readonly DPContext _context;

        public SingleAPIController(DPContext context)
        {
            _context = context;
        }

        // GET api/<SingleAPIController>/5
        [HttpGet("DanhSachGheTrong")]
        public string Get(string id)
        {
            var dsghe = (from a in _context.lichChieuModels
                         join b in _context.phongModels on a.MaPhong equals b.IdPhong
                         join c in _context.gheModels on b.IdPhong equals c.MaPhong
                         join d in _context.giamGiaModels on a.MaGiamGia equals d.IdMaGiamGia
                         join e in _context.loaiGheModels on c.MaLoaiGhe equals e.IdLoaiGhe
                         where a.IdLichChieu == int.Parse(id)
                         select new
                         {
                             c.TenGhe,
                             d.PhanTram,
                             e.GiaLoaiGhe
                         }).OrderBy(x=>x.TenGhe);
            return JsonConvert.SerializeObject(dsghe);
        }

        // GET danh sachs ghe da chon
        [HttpGet("DanhSachGheDaChon")]
        public string Get1(string id)
        {
            var dsghe = (from a in _context.lichChieuModels
                         join d in _context.datVeModels on a.IdLichChieu equals d.MaLichChieu
                         join e in _context.chiTietDatVeModels on d.IdDatVe equals e.MaDatVe
                         where a.IdLichChieu == int.Parse(id)
                         select new
                         {
                             e.TenGhe
                         });

             dsghe.GroupBy(x => x.TenGhe);
            return JsonConvert.SerializeObject(dsghe);
        }

        // GET danh sachs ghe da chon
        [HttpGet("ThanhToan")]
        public string Get2(string dsGheChon, string tongGia, string idLichChieu)
        {
            if(dsGheChon!=null)
            {
                var ob = JsonConvert.DeserializeObject(dsGheChon);
                string a = ob.ToString();
                string[] b = a.Split("\"");
                string c = "";
                foreach (string item in b)
                {
                    if (Char.IsLetter(item[0]) == true)
                        c += item + ",";
                }
                string[] d = c.Split(",");
                JObject us = JObject.Parse(HttpContext.Session.GetString("UserThuong"));
                if (d.Length > 0)
                {
                    DatVeModel datVeModel = new DatVeModel();
                    datVeModel.SoGhe = d.Length - 1;
                    datVeModel.NgayDat = DateTime.Now;
                    datVeModel.TongGia = int.Parse(tongGia);
                    datVeModel.MaLichChieu = int.Parse(idLichChieu);
                    datVeModel.TrangThaiThanhToan = true;
                   

                    datVeModel.MaKhachHang = int.Parse( us.SelectToken("IdUser").ToString()); 
                    _context.Add(datVeModel);
                    _context.SaveChanges();
                }
                var datVeHienTai = from s in _context.datVeModels
                                   where s.MaLichChieu == int.Parse(idLichChieu) && s.TongGia == int.Parse(tongGia) &&
                                   s.MaKhachHang == int.Parse(us.SelectToken("IdUser").ToString()) && s.SoGhe == (d.Length - 1)
                                   select new
                                   {
                                       s.IdDatVe
                                   };

                for (int i = 0; i < d.Length - 1; i++)
                {
                    ChiTietDatVeModel chiTietDatVeModel = new ChiTietDatVeModel();
                    chiTietDatVeModel.TenGhe = d[i];
                    chiTietDatVeModel.GiaVe = 0;
                    chiTietDatVeModel.MaDatVe = datVeHienTai.FirstOrDefault().IdDatVe;

                    _context.Add(chiTietDatVeModel);
                    _context.SaveChanges();
                }

                return JsonConvert.SerializeObject("1");
            }
            else
            {
                return JsonConvert.SerializeObject("0");
            }
            
        }

    }
}
