using BLL.Interfaces;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace API_NguoiDung.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamControllers : ControllerBase
    {
        private ISanPham_BLL _sanpham_BLL;

        public SanPhamControllers(ISanPham_BLL sanphamBLL)
        {
            _sanpham_BLL = sanphamBLL;
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public SanPhamModel GetDatabyID(int id)
        {
            return _sanpham_BLL.GetDatabyID(id);
        }

        [Route("get_all")]
        [HttpGet]
        public List<SanPhamModel> GetAll()
        {
            //var SanPham = _sanpham_BLL.GetAll();
            return _sanpham_BLL.GetAll();

        }

        [Route("search")]
        [HttpPost]
        public IActionResult Search([FromBody] string tukhoa )
        {
            try
            {
                var data = _sanpham_BLL.Search(tukhoa);
                return Ok(
                    new
                    {
                        Data = data
                    }
                    );
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
