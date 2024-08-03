using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public partial interface IHoaDon_DAL
    {
        public List<HoaDonModel> GetAll();
        public List<HoaDonmoreModel> GetHoaDonbyIDuser(string id);
        bool Create(HoaDonModel2 model);
        bool Update(HoaDonModel model);
        bool Delete(int mahd);
        public List<HoaDonmoreModel> GetHoaDonDetails();
    }
}
