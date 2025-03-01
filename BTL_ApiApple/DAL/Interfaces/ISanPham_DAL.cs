﻿using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public partial interface ISanPham_DAL
    {
        List<SanPhamModel> GetAll();

        SanPhamModel GetDatabyID(int id);
        bool Create(SanPhamModel2 model);

        bool Update(SanPhamModel model);
        //bool Delete(SanPhamModel model);
        bool Delete(string masp);

        List<SanPhamModel> Search( string tukhoa);
   
    }
}
