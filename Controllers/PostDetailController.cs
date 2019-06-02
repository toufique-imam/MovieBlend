using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieBlend.Models;
using MovieBlend.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.IO;

namespace MovieBlend.Controllers
{
    [Authorize]
   
    public class PostDetailController : Controller
    {

        
        //private readonly ICommentDataService _commentdataServices;
        private readonly IPostDataService _postDataService;
        private readonly IImageDataService _imageDataservice;
        private static MovieData maindata;
        private readonly UserManager<IdentityUser> _usermanger;
        public PostDetailController(IImageDataService imageDataservice,IPostDataService postData, UserManager<IdentityUser> usermanager)
        {
            _imageDataservice=imageDataservice;
           // _commentdataServices=commentdataService;
            _usermanger = usermanager;
            _postDataService = postData;
        }
       
        public IActionResult Index(string data)
        {
            maindata = new MovieData();
            var datax = Newtonsoft.Json.JsonConvert.DeserializeObject<string>(data);
            var arr = _postDataService.Getdatabyid(datax);
            return View(arr);
        }
        [HttpGet]
        public async Task<FileStreamResult> ViewImage(Guid id)
        {

            Models.Image image = await _imageDataservice.GetDataByIdAsync(id);

            MemoryStream ms = new MemoryStream(image.Data);

            return new FileStreamResult(ms, image.ContentType);
        }
    }
}