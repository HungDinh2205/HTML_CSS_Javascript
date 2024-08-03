using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public partial interface IUser_BLL
    {
        UserModel3 GetDatabyID(string id);
        UserModel Login(string Username, string Password);

        bool Dangky(UserModel2 model);
    }
}
