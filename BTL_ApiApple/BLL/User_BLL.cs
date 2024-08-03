using BLL.Interfaces;
using DTO;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Sockets;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;

namespace BLL
{
    public class User_BLL : IUser_BLL
    {
        private IUser_DAL _res;
        private string secret;
        public User_BLL(IUser_DAL res)
        {
            _res = res;
        }
        public User_BLL(IUser_DAL res, IConfiguration configuration)
        {
            _res = res;
            secret = configuration["AppSettings:Secret"];
        }
        //public UserModel Login(UserModel model)
        //{
        //    return _res.Login(model);
        //}

        public UserModel3 GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }

        public bool Dangky(UserModel2 model)
        {
            return _res.Dangky(model);
        }

        //public UserModel Login(string Username, string Password)
        //{
        //    var user = _res.Login(Username, Password);
        //    if (user == null)
        //        return null;
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.ASCII.GetBytes(secret);
        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(new Claim[]
        //        {
        //            new Claim(ClaimTypes.Name, user.Username.ToString()),
        //            new Claim(ClaimTypes.Email, user.Password)
        //        }),
        //        Expires = DateTime.UtcNow.AddDays(7),
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.Aes128CbcHmacSha256)
        //    };
        //    var token = tokenHandler.CreateToken(tokenDescriptor);
        //    user.token = tokenHandler.WriteToken(token);
        //    return user;
        //}

        public UserModel Login(string Username, string Password)
        {
            var user = _res.Login(Username, Password);
            if (user == null)
                return null;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username.ToString()),
                    
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.Aes128CbcHmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.token = tokenHandler.WriteToken(token);
            return user;
        }
    }
}

