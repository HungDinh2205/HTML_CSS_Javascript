using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public partial interface ILoai_DAL
    {
        List<LoaiModel> GetAll();
        List<LoaiModel2> GetDatabyID(int id);
    }
}
