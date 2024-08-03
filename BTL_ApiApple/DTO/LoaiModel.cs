using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LoaiModel
    {
        public string maloai { get; set; }
        public string tenloai { get; set; }
       
    }
    public class LoaiModel2
    {
        public string MaSanPham { get; set; }
        public string maloai { get; set; }
        public string tenloai { get; set; }
        public string TenSanPham { get; set; }
        public double Gia { get; set; }
        public IFormFile AnhFile { get; set; }
        public string Anh { get; set; }
    }
}
