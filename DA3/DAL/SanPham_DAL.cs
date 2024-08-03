using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.interfaces;
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


        public bool Create(SanPhamModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "insert_San_Pham",

                "@TenSanPham", model.TenSanPham,
                "@Gia", model.Gia,
                "@SoLuong", model.Soluongton,
                "@Anh", model.Anh
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
    }
}
