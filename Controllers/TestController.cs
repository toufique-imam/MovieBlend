using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MovieBlend.Models;
using System.IO;
using System.Drawing;
using MovieBlend.Services;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieBlend.Controllers
{
    public class TestController : Controller
    {
        public IImageDataService _imageDataservice;
        public TestController(IImageDataService imageDataservice)
        {
            _imageDataservice = imageDataservice;
        }
        [HttpGet]
        public async  Task<IActionResult> Index()
        {
            var arra=await _imageDataservice.GetIncompleteItemsAsync();
            List<Guid>list=new List<Guid>();
            for(int i=0;i<arra.Length;i++){
                list.Add(arra[i].Id);
            }
            return View(list);
        }

        [HttpPost]
        public IActionResult UploadImage(IList<IFormFile> files)
        {
            IFormFile uploadedImage = files.FirstOrDefault();
            if (uploadedImage == null || uploadedImage.ContentType.ToLower().StartsWith("image/"))
            {
                MemoryStream ms = new MemoryStream();
                uploadedImage.OpenReadStream().CopyTo(ms);

                System.Drawing.Image image = System.Drawing.Image.FromStream(ms);

                Models.Image imageEntity = new Models.Image()
                {
                    Id = Guid.NewGuid(),
                    Name = uploadedImage.Name,
                    Data = ms.ToArray(),
                    Width = image.Width,
                    Height = image.Height,
                    ContentType = uploadedImage.ContentType
                };
                _imageDataservice.AddImageDataAsync(imageEntity);

            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public FileStreamResult ViewImage(Guid id)
        {

            Models.Image image = _imageDataservice.Getdatabyid(id);

            MemoryStream ms = new MemoryStream(image.Data);

            return new FileStreamResult(ms, image.ContentType);
        }
    }
}
