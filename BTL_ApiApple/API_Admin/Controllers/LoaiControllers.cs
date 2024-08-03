using BLL;
using BLL.Interfaces;
using DTO;
using Microsoft.AspNetCore.Mvc;

namespace API_Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiControllers : ControllerBase
    {
        private ILoai_BLL _loai_BLL;

        public LoaiControllers(ILoai_BLL loaiBLL)
        {
            _loai_BLL = loaiBLL;
        }

        [Route("Loai_get_by_id/{id}")]
        [HttpGet]
        public List<LoaiModel2> GetDatabyID(int id)
        {
            return _loai_BLL.GetDatabyID(id);
        }
        [Route("get_all")]
        [HttpGet]
        public List<LoaiModel> GetAll()
        {
            return _loai_BLL.GetAll();

        }
    }
}
