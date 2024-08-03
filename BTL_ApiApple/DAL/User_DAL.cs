using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class User_DAL: IUser_DAL
    {
        private IDatabaseHelper _dbHelper;
        public User_DAL(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public UserModel3 GetDatabyID(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "get_taiKhoan_by_id",
                     "@MaTaiKhoan", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<UserModel3>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public UserModel Login(string Username, string Password)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "pro_TaiKhoans",
                     "@Username", Username,
                     "@Password", Password
                     );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<UserModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Dangky(UserModel2 model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "DangKy_register",
                    "@Username", model.Username,
                    "@Password", model.Password,
                    "@Email", model.Email // Bao gồm nếu bạn đã cập nhật stored procedure
                );

                if (result != null && result.ToString() == "Username đã tồn tại.")
                {
                    throw new Exception("Username đã tồn tại.");
                }
                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }

                return true;
            }
            catch (Exception ex)
            {
                // Log hoặc xử lý ngoại lệ theo cách bạn muốn
                throw;
            }
        }

    }
}
