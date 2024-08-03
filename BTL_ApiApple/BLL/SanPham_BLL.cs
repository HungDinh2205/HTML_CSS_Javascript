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
    public class SanPham_BLL: ISanPham_BLL
    {
        private ISanPham_DAL _res;
        public SanPham_BLL(ISanPham_DAL res)
        {
            _res = res;
        }
        public SanPhamModel GetDatabyID(int id)
        {
            return _res.GetDatabyID(id);
        }
        public bool Create(SanPhamModel2 model)
        {
            return _res.Create(model);
        }

        public bool Update(SanPhamModel model)
        {
            return _res.Update(model);
        }
        

        public bool Delete(string masp)
        {
            return _res.Delete(masp);
        }

        public List<SanPhamModel> GetAll()
        {
            return _res.GetAll();
        }

        public List<SanPhamModel> Search(string tukhoa)
        {
            return _res.Search(tukhoa);
        }

        

        //public bool Delete(SanPhamModel model)
        //{
        //    return _res.Delete(model);
        //}
    }
}

