using BLL.Interfaces;
using DTO;
//using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.interfaces;

namespace BLL
{
    public class SanPham_BLL : ISanPham_BLL
    {
        private ISanPham_DAL _res;
        public SanPham_BLL(ISanPham_DAL res)
        {
            _res = res;
        }

        public List<SanPhamModel> GetAll()
        {
            return _res.GetAll();
        }
        //public SanPhamModel GetDatabyID(string id)
        //{
        //    return _res.GetDatabyID(id);
        //}
        public bool Create(SanPhamModel model)
        {
            return _res.Create(model);
        }

    }
}

