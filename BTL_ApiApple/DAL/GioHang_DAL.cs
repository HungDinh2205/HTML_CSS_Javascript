using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DTO;

namespace DAL
{
    public class GioHang_DAL : IGioHang_DAL
    {
        private IDatabaseHelper _dbHelper;

        public GioHang_DAL(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public List<GioHangModel> GetAll()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "GioHang_get_all");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<GioHangModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GioHangModel> GetDatabyID(string id)
        {
            string msgError = "";
            try
            {
                // Thực hiện thủ tục lưu trữ và trả về DataTable
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "Giohang_get_by_idUser",
                     "@MaTaiKhoan", id);

                // Kiểm tra lỗi
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);

                // Chuyển đổi DataTable thành danh sách các đối tượng GioHangModel và trả về
                return dt.ConvertTo<GioHangModel>().ToList();
            }
            catch (Exception ex)
            {
                // Ném lại ngoại lệ để xử lý bên ngoài nếu cần
                throw ex;
            }
        }

        public bool Create(GioHangModel2 model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "GioHang_create",
                "@SoLuong", model.SoLuong,
                "@MaSanPham", model.MaSanPham,
                "MaTaiKhoan", model.MaTaiKhoan,
                "@TongGia", model.TongGia
                );

                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                throw;
            }
        }

        public bool Update(GioHangModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "GioHang_update",
                "MaGioHang", model.MaGioHang,
                "@SoLuong", model.SoLuong,
                "@MaSanPham", model.MaSanPham,
                "@MaTaiKhoan", model.MaTaiKhoan,
                "@TongGia", model.TongGia
                //"Anh",model.Anh
                ); ;

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

        public bool Delete(string id)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "GioHang_delete",
                "@MaGioHang", id);

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

    }
}
