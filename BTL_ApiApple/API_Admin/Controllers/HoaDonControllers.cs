using BLL.Interfaces;
using BLL;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DAL;

namespace API_Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoaDonController : ControllerBase
    {
        private IHoaDon_BLL _hoadon_BLL;


        public HoaDonController(IHoaDon_BLL hoadon_BLL)
        {
            _hoadon_BLL = hoadon_BLL;
        }

        [Route("get_HoaDon_by_id_user/{id}")]
        [HttpGet]
        public List<HoaDonmoreModel> GetHoaDonbyIDuser(string id)
        {
            return _hoadon_BLL.GetHoaDonbyIDuser(id);
        }

        [Route("get_HoaDon_Details")]
        [HttpGet]
        public List<HoaDonmoreModel> GetHoaDonDetails()
        {
            return _hoadon_BLL.GetHoaDonDetails();
        }

        [Route("create-hoadon")]
        [HttpPost]
        public HoaDonModel2 CreateHoaDon([FromBody] HoaDonModel2 model)
        {
            _hoadon_BLL.Create(model);
            return model;
        }

        [Route("update-HoaDon")]
        [HttpPost]
        public HoaDonModel UpdateItem([FromBody] HoaDonModel model)
        {
            _hoadon_BLL.Update(model);
            return model;
        }

        [Route("Delete")]
        [HttpDelete]
        public IActionResult DeleteItem(int mahd)
        {
            try
            {
                bool result = _hoadon_BLL.Delete(mahd);
                if (result)
                {
                    return Ok("Xóa thành công");
                }
                else
                {
                    return BadRequest("Không tìm thấy hoá đơn cần xoá");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
