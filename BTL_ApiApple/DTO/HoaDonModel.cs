using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
        public class HoaDonmoreModel
        {
            public string MaHoaDon { get; set; }
            public decimal TongGia { get; set; }
            public int SoLuong { get; set; }
            public string MaTaiKhoan { get; set; }  // Kiểm tra thuộc tính này
            public string Username { get; set; }
            public string MaSanPham { get; set; }
            public string TenSanPham { get; set; }
            public string Anh { get; set; }
            public string TenKhachHang { get; set; }
            public int SDT { get; set; }
            public string DiaChi { get; set; }
    }
        public class HoaDonModel
        {
            public string MaHoaDon { get; set; }
            public decimal TongGia { get; set; }
            public int SoLuong { get; set; }
            public string MaTaiKhoan { get; set; }  // Kiểm tra thuộc tính này
            public string MaSanPham { get; set; }
            
        }
        public class HoaDonModel2
        {
            //public string MaHoaDon { get; set; }
            public decimal TongGia { get; set; }
            public int SoLuong { get; set; }
            public string MaTaiKhoan { get; set; }
            //public string Username { get; set; }// Kiểm tra thuộc tính này
            public string MaSanPham { get; set; }
            //public string TenSanPham { get; set; }
            public string TenKhachHang { get; set; }
            public int SDT { get; set; }
            public string DiaChi { get; set; }

        }   

}
