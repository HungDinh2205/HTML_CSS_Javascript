using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SanPhamModel
    {
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public double Gia { get; set; }
        public int SoLuong { get; set; }
        public string maloai { get; set; }
        public IFormFile AnhFile { get; set; }
        public string Anh {  get; set; }
        public string Mota { get; set; }
        public string mau { get; set; }
        public string kichco { get; set; }
    }

    public class SanPhamModel2
    {
        //public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public double Gia { get; set; }
        public int SoLuong { get; set; }
        public string maloai { get; set; }
        public IFormFile AnhFile { get; set; }
        public string Anh { get; set; }
        public string Mota { get; set; }
        public string mau { get; set; }
        public string kichco { get; set; }
    }
}
