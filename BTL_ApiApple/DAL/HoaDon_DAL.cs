using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DTO;

namespace DAL
{
    public class HoaDon_DAL: IHoaDon_DAL
    {
        private IDatabaseHelper _dbHelper;
        public HoaDon_DAL(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public List<HoaDonmoreModel >GetHoaDonbyIDuser(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "get_HoaDon_by_id_user", "@MaTaiKhoan", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<HoaDonmoreModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HoaDonModel> GetAll()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "HoaDon_get_all");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<HoaDonModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool Create(HoaDonModel2 model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "HoaDon_create",

                    "@TongGia", model.TongGia,
                    "@SoLuong", model.SoLuong,
                    "@MaTaiKhoan", model.MaTaiKhoan,
                    "@MaSanPham", model.MaSanPham,
                    "@TenKhachHang",model.TenKhachHang,
                    "SDT",model.SDT,
                    "DiaChi",model.DiaChi);
                    
                    
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(HoaDonModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "HoaDon_update",
                    "@MaHoaDon", model.MaHoaDon,
                    "@TongGia", model.TongGia,
                    "@SoLuong", model.SoLuong,
                    "@MaTaiKhoan", model.MaTaiKhoan,
                    "@MaSanPham", model.MaSanPham
                    );

                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete(int mahd)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "HoaDon_delete",
                    "@MaHoaDon", mahd);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public List<HoaDonmoreModel> GetHoaDonDetails()
        {
            string query = @"
        SELECT 
        hd.MaHoaDon,
        hd.TongGia,
        hd.SoLuong,
        hd.MaTaiKhoan,
        tk.Username,
        hd.MaSanPham,
		sp.TenSanPham,
		sp.Anh,
		hd.TenKhachHang,
		hd.SDT,
		hd.DiaChi
        
    FROM 
        HoaDons hd
    JOIN 
        TaiKhoans tk ON hd.MaTaiKhoan = tk.MaTaiKhoan
	JOIN 
		SanPhams sp on hd.MaSanPham = sp.MaSanPham;";

            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteQueryToDataTable(query, out msgError);
                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }

                return dt.ConvertTo<HoaDonmoreModel>().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while fetching the invoice details: " + ex.Message);
            }
        }
    }
}

