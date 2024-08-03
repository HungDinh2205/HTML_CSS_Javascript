using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DTO;

namespace DAL
{
    public class Loai_DAL : ILoai_DAL
    {
        private IDatabaseHelper _dbHelper;

        public Loai_DAL(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public List<LoaiModel2> GetDatabyID(int id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "Loai_get_by_id",
                     "@maloai", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<LoaiModel2>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<LoaiModel> GetAll()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "Loai_get_all");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<LoaiModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
