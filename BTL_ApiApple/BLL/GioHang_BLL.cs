using BLL.Interfaces;
using DTO;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class GioHang_BLL : IGioHang_BLL
    {
        private IGioHang_DAL _res;
        public GioHang_BLL(IGioHang_DAL res)
        {
            _res = res;
        }
        public List<GioHangModel> GetAll()
        {
            return _res.GetAll();
        }

        public List<GioHangModel> GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public bool Create(GioHangModel2 model)
        {
            return _res.Create(model);
        }

        public bool Update(GioHangModel model)
        {
            return _res.Update(model);
        }


        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
   
    }
}

