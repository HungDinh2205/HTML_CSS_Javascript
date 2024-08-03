using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class GioHangModel
    {
        public string MaGioHang { get; set; }
        public int SoLuong { get; set; }
        public string TenSanPham { get; set; }
        public string MaSanPham { get; set; }
        public string MaTaiKhoan { get; set; }
        public decimal TongGia { get; set; }
        public string Anh {  get; set; }
      
        //public IFormFile AnhFile { get; set; }
        //public string Anh { get; set; }
    }
    public class GioHangModel2
    {
        //public int MaGioHang { get; set; }
        public int SoLuong { get; set; }
        public string TenSanPham { get; set; }
        public string MaSanPham { get; set; }
        public string MaTaiKhoan { get; set; }
        public decimal TongGia { get; set; }
        public string Anh { get; set; }

        //public IFormFile AnhFile { get; set; }
        //public string Anh { get; set; }
    }
}
