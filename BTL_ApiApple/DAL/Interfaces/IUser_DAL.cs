using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public partial interface IUser_DAL
    {
        UserModel3 GetDatabyID(string id);
        UserModel Login(string Username, string Password);
        bool Dangky(UserModel2 model);
        //UserModel Login(UserModel model);
    }
}
