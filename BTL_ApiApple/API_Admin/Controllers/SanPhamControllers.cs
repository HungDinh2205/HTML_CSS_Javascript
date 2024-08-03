using BLL.Interfaces;
using DTO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        private ISanPham_BLL _sanpham_BLL;

        public SanPhamController(ISanPham_BLL sanpham_BLL, IWebHostEnvironment webHostEnvironment)
        {
            _sanpham_BLL = sanpham_BLL;
            _webHostEnvironment = webHostEnvironment;

        }


        [HttpPost("UploadFile")]
        public async Task<string> UploadFileAsync(IFormFile? file, string folder)
        {
            string webRootPath = _webHostEnvironment.WebRootPath;
            string relativeFolderPath = folder;
            string uploadsFolder = Path.Combine(webRootPath, relativeFolderPath);

            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            string filePath = Path.Combine(relativeFolderPath, uniqueFileName);

            using (var stream = new FileStream(Path.Combine(webRootPath, filePath), FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            string absoluteFilePath = Path.Combine(webRootPath, folder, uniqueFileName);
            string relativeFilePath = Path.GetRelativePath(webRootPath, absoluteFilePath);

            return "/" + relativeFilePath.Replace("\\", "/");
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
            return _sanpham_BLL.GetAll();

        }


        [Route("Create")]
        [HttpPost]
        public async Task<SanPhamModel2> CreateItem([FromForm]SanPhamModel2 model)
        {
            if (model.AnhFile != null)
                model.Anh = await UploadFileAsync(model.AnhFile, "SanPhams");
            _sanpham_BLL.Create(model);
            return model;

        }

        [Route("Update")]
        [HttpPost]
        public async Task<SanPhamModel> UpdateItemAsync([FromForm]SanPhamModel model)
        {
            if (model.AnhFile?.Length > 0)
            {
                model.Anh = await UploadFileAsync(model.AnhFile, "SanPhams");
            }
            _sanpham_BLL.Update(model);
            return model;
        }

        [Route("Delete")]
        [HttpDelete]
        public IActionResult DeleteItem(string masp)
        {
            try
            {
                bool result = _sanpham_BLL.Delete(masp);
                if (result)
                {
                    return Ok("Xóa thành công");
                }
                else
                {
                    return BadRequest("Không tìm thấy sản phẩm hàng hoặc xóa không thành công");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        

        [Route("search")]
        [HttpPost]
        public IActionResult Search([FromBody] string tukhoa)
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
