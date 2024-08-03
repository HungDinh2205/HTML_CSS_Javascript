using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public partial interface ILoai_BLL
    {

        List<LoaiModel2> GetDatabyID(int id);
        List<LoaiModel> GetAll();

    }
}
