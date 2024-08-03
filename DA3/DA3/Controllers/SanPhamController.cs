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

        [Route("get_all")]
        [HttpGet]
        public List<SanPhamModel> GetAll()
        {
            return _sanpham_BLL.GetAll();

        }



        //[Route("get-by-id/{id}")]
        //[HttpGet]
        //public SanPhamModel GetDatabyID(string id)
        //{
        //    return _sanpham_BLL.GetDatabyID(id);
        //}

        [Route("Create")]
        [HttpPost]
        public async Task<SanPhamModel> CreateItem([FromForm] SanPhamModel model)
        {
            if (model.AnhFile != null)
                model.Anh = await UploadFileAsync(model.AnhFile, "SanPham");
            _sanpham_BLL.Create(model);
            return model;

        }

        
    }
}
