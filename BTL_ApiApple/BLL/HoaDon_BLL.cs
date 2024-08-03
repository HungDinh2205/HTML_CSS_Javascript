using BLL.Interfaces;
using DTO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;

namespace BLL
{
    public class HoaDon_BLL: IHoaDon_BLL
    {
        private IHoaDon_DAL _res;

        public HoaDon_BLL(IHoaDon_DAL res)
        {
            _res = res;
        }
        public List<HoaDonmoreModel> GetHoaDonbyIDuser(string id)
        {
            return _res.GetHoaDonbyIDuser(id);
        }
        public List<HoaDonModel> GetAll()
        {
            return _res.GetAll();
        }
       
        public bool Create(HoaDonModel2 model)
        {
            return _res.Create(model);
        }
        
        public bool Update(HoaDonModel model)
        {
            return _res.Update(model);
        }

        public bool Delete(int mahd)
        {
            return _res.Delete(mahd);
        }

        public List<HoaDonmoreModel> GetHoaDonDetails()
        {
            return _res.GetHoaDonDetails();
        }


    }
}
