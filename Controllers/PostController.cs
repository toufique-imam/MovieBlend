using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieBlend.Models;
using MovieBlend.Services;
using System.IO;
using System.Drawing;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;


namespace MovieBlend.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        private static Guid imageid;
        private static Models.Image ImageEntity=new Models.Image();
        static bool isMovie = false;
        private readonly IImageDataService _imageDataservice;
        private readonly IPostDataService _postdataService;
        private readonly UserManager<IdentityUser> _usermanger;
        public PostController(IImageDataService imageDataservice,IPostDataService movieDataService,UserManager<IdentityUser>userManager)
        {
            _imageDataservice=imageDataservice;
            _postdataService = movieDataService;
            _usermanger = userManager;

        }
        public IActionResult Cat_select()
        {
            return View("UploadPic");
        }
        [HttpPost]
        public async Task<IActionResult> UploadImage(IList<IFormFile> files)
        {
            IFormFile uploadedImage = files.FirstOrDefault();
            if (uploadedImage != null || uploadedImage.ContentType.ToLower().StartsWith("image/"))
            {
                MemoryStream ms = new MemoryStream();
                uploadedImage.OpenReadStream().CopyTo(ms);

                System.Drawing.Image image = System.Drawing.Image.FromStream(ms);
                ImageEntity.Id=Guid.NewGuid();
                ImageEntity.Name=uploadedImage.FileName;
                ImageEntity.Data=ms.ToArray();
                ImageEntity.Width=image.Width;
                ImageEntity.Height=image.Height;
                ImageEntity.ContentType=uploadedImage.ContentType;
                imageid=ImageEntity.Id;
                Console.WriteLine("WIAT WTAH" + imageid);
                await _imageDataservice.AddImageDataAsync(ImageEntity);
            }
            return View("post_entry");
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> AddPost(MovieData dummyData)
        {
            if (dummyData.Catagoryx == Catagory.Movie) isMovie = true;
            else isMovie = false;
            var currentUser = await _usermanger.GetUserAsync(User);
            if (currentUser == null) return Challenge();
            if (ImageEntity.Id != imageid)
            {
                Console.WriteLine("WAIT WHAT?" + imageid + " " + ImageEntity.Id);
            }
            MovieData newmovie = new MovieData()
            {
                Postedate = DateTimeOffset.Now,
                Id = Guid.NewGuid(),
                Title = dummyData.Title,
                Release = dummyData.Release,
                Genre = dummyData.Genre,
                Description = dummyData.Description,
                Language = dummyData.Language,
                PosterId = currentUser.Id,
                User_name = currentUser.UserName,
                Cover_pic_id = ImageEntity.Id,
                _Privacy = dummyData._Privacy
            };
            if (isMovie==true)
            {
                newmovie.Catagoryx = Catagory.Movie;
                if (!ModelState.IsValid)
                {
                    return RedirectToAction("Add_entry_movie");
                }
                var successful = await _postdataService.AddPostDataAsync(newmovie);
                if (!successful)
                {
                    return BadRequest("Couldnot Post Your Entry");
                }
                return RedirectToAction("Cat_select");
            }
            else
            {
                newmovie.Catagoryx = Catagory.Tv;
                if (!ModelState.IsValid)
                {
                    return RedirectToAction("Add_entry_TV");
                }
            
                var successful = await _postdataService.AddPostDataAsync(newmovie);
                if (!successful)
                {
                    return BadRequest("Couldnot Post Your Entry");
                }
                return RedirectToAction("Cat_select");
            }
        }
    }
}
