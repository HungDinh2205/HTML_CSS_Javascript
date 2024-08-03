using BLL;
using DAL;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUser_BLL _user_BLL;
        public UserController(IUser_BLL user_BLL)
        {
            _user_BLL = user_BLL;
        }
        [Route("DangKy")]
        [HttpPost]
        public UserModel2 Dangky([FromBody] UserModel2 model)
        {
            _user_BLL.Dangky(model);
            return model;
        }
        //[AllowAnonymous]
        [Route("login")]
        [HttpPost]
        public IActionResult Login([FromBody] AuthenticateModel model)
        {
            var user = _user_BLL.Login(model.Username, model.Password);
            if (user == null)
                return BadRequest(new { message = "Tài khoản hoặc mật khẩu không đúng!" });
            return Ok(new { username = user.Username, token = user.token });
        }
    }
}
