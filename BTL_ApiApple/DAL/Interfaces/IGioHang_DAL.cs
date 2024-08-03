using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public partial interface IGioHang_DAL
    {
        List<GioHangModel> GetAll();

        List<GioHangModel> GetDatabyID(string id);
        bool Create(GioHangModel2 model);

        bool Update(GioHangModel model);
        //bool Delete(SanPhamModel model);
        bool Delete(string id);

        //List<GioHangModel> Search(string tukhoa);
        
    }
}
