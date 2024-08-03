using BLL.Interfaces;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace API_NguoiDung.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoaDonControllers : ControllerBase
    {
        private IHoaDon_BLL _hoadon_BLL;

        public HoaDonControllers(IHoaDon_BLL hoadonBLL)
        {
            _hoadon_BLL = hoadonBLL;
        }

        [Route("get_HoaDon_by_id_user/{id}")]
        [HttpGet]
        public List<HoaDonmoreModel> GetHoaDonbyIDuser(string id)
        {
            return _hoadon_BLL.GetHoaDonbyIDuser(id);
        }

    }
}
