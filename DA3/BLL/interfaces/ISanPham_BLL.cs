using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public partial interface ISanPham_BLL
    {
        List<SanPhamModel> GetAll();
        //SanPhamModel GetDatabyID(string id);
        bool Create(SanPhamModel model);
    }
}
