using DTO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public partial interface IHoaDon_BLL
    {
        //public List<HoaDonModel> GetAll();
        public List<HoaDonmoreModel> GetHoaDonbyIDuser(string id);
        bool Create(HoaDonModel2 model);
        bool Update(HoaDonModel model);
        bool Delete(int mahd);
        public List<HoaDonmoreModel> GetHoaDonDetails();
    }
}
