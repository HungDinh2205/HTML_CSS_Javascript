using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.interfaces
{
    public partial interface ISanPham_DAL
    {
        List<SanPhamModel> GetAll();
        bool Create(SanPhamModel model);

    }
}
