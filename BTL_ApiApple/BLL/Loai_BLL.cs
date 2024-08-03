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
    public class Loai_BLL : ILoai_BLL
    {
        private ILoai_DAL _res;
        public Loai_BLL(ILoai_DAL res)
        {
            _res = res;
        }
        public List<LoaiModel2> GetDatabyID(int id)
        {
            return _res.GetDatabyID(id);
        }

        public List<LoaiModel> GetAll()
        {
            return _res.GetAll();
        }

    }
}

