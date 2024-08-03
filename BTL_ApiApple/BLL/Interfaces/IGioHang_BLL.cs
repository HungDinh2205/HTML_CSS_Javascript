using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public partial interface IGioHang_BLL
    {
        List<GioHangModel> GetAll();
        List<GioHangModel> GetDatabyID(string id);
        bool Create(GioHangModel2 model);

        bool Update(GioHangModel model);
        //bool Delete(SanPhamModel model);

        //List<GioHangModel> Search(string tukhoa);
        bool Delete(string id);
    }
}
