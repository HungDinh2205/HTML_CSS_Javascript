using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SanPhamModel
    {
        public string TenSanPham { get; set; }
        public string MoTa { get; set; }
        public string Gia { get; set; }
        public double Soluongton { get; set; }
        public IFormFile AnhFile { get; set; }
        public string Anh { get; set; }
        public int Maloai { get; set; }
    }
}
