using BLL;
using BLL.Interfaces;
using DTO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GioHangController : ControllerBase
    {
        //private readonly IWebHostEnvironment _webHostEnvironment;

        private IGioHang_BLL _giohang_BLL;

        public GioHangController(IGioHang_BLL giohang_BLL, IWebHostEnvironment webHostEnvironment)
        {
            _giohang_BLL = giohang_BLL;
            //_webHostEnvironment = webHostEnvironment;

        }

        //[HttpPost("UploadFile")]
        //public async Task<string> UploadFileAsync(IFormFile? file, string folder)
        //{
        //    string webRootPath = _webHostEnvironment.WebRootPath;
        //    string relativeFolderPath = folder;
        //    string uploadsFolder = Path.Combine(webRootPath, relativeFolderPath);

        //    if (!Directory.Exists(uploadsFolder))
        //    {
        //        Directory.CreateDirectory(uploadsFolder);
        //    }

        //    string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
        //    string filePath = Path.Combine(relativeFolderPath, uniqueFileName);

        //    using (var stream = new FileStream(Path.Combine(webRootPath, filePath), FileMode.Create))
        //    {
        //        await file.CopyToAsync(stream);
        //    }

        //    string absoluteFilePath = Path.Combine(webRootPath, folder, uniqueFileName);
        //    string relativeFilePath = Path.GetRelativePath(webRootPath, absoluteFilePath);

        //    return "/" + relativeFilePath.Replace("\\", "/");
        //}

        [Route("get_all")]
        [HttpGet]
        public List<GioHangModel> GetAll()
        {
            return _giohang_BLL.GetAll();

        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public List<GioHangModel> GetDatabyID(string id)
        {
            return _giohang_BLL.GetDatabyID(id);
        }

        [Route("Create")]
        [HttpPost]
        public async Task<GioHangModel2> CreateItem(GioHangModel2 model)
        {
            
            _giohang_BLL.Create(model);
            return model;
        }

        [Route("Update")]
        [HttpPost]
        public async Task<GioHangModel> UpdateItemAsync( GioHangModel model)
        {
            
            _giohang_BLL.Update(model);
            return model;
        }

        [Route("Delete/{id}")]
        [HttpDelete]
        public IActionResult DeleteItem(string id)
        {
            try
            {
                bool result = _giohang_BLL.Delete(id);
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

        
    }
}
