using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DTO;

namespace DAL
{
    public class SanPham_DAL : ISanPham_DAL
    {
        private IDatabaseHelper _dbHelper;

        public SanPham_DAL(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public List<SanPhamModel> GetAll()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "Sp_get_all");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<SanPhamModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SanPhamModel GetDatabyID(int id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "get_SanPham_id",
                     "@MaSanPham", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<SanPhamModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Create(SanPhamModel2 model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "insert_San_Pham",
                
                "@TenSanPham", model.TenSanPham,
                "@Gia", model.Gia,
                "@SoLuong", model.SoLuong,
                "@maloai",model.maloai,
                "@Anh", model.Anh,
                "@Mota",model.Mota,
                "@mau",model.mau,
                "@kichco",model.kichco
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

        public bool Update(SanPhamModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "update_San_Pham",
                "MaSanPham", model.MaSanPham,
                "@TenSanPham", model.TenSanPham,
                "@Gia", model.Gia,
                "@SoLuong", model.SoLuong,
                "@maloai", model.maloai,
                "@Anh", model.Anh,
                "@Mota", model.Mota,
                "@mau", model.mau,
                "@kichco", model.kichco); ;

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

        public bool Delete(string masp)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "delete_San_Pham",
                "@MaSanPham", masp);

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

        //public bool Delete(SanPhamModel model)
        //{
        //    string msgError = "";
        //    try
        //    {
        //        var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "delete_San_Pham",
        //        "@MaSanPham", model.MaSanPham);

        //        if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
        //        {
        //            throw new Exception(Convert.ToString(result) + msgError);
        //        }
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public List<SanPhamModel> Search(string tukhoa)
        {
            string msgError = "";
            
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "search_san_pham",
                    "@tukhoa", tukhoa);
                if (!string.IsNullOrEmpty(msgError)) throw new Exception(msgError);
          
                return dt.ConvertTo<SanPhamModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
    }
}
