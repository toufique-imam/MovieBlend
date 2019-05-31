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
        private readonly IMovieDataService _moviedataService;
        private readonly ITvDataService _tvdataService;
        private readonly UserManager<IdentityUser> _usermanger;
        public PostController(IImageDataService imageDataservice,IMovieDataService movieDataService,ITvDataService tvDataService,UserManager<IdentityUser>userManager)
        {
            _imageDataservice=imageDataservice;
            _moviedataService = movieDataService;
            _tvdataService = tvDataService;
            _usermanger = userManager;

        }
        public IActionResult Cat_select()
        {
            return View("Cat_select");
        }
        public IActionResult Add_entry_movie()
        {
            isMovie = true;
            return View("UploadPic");
        }
        public IActionResult Add_entry_TV()
        {
            isMovie = false;
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
            
            //HttpFileCollection hfc = HttpContext.Current.Request.Files;
            var currentUser = await _usermanger.GetUserAsync(User);
            if (currentUser == null) return Challenge();
            // HttpPostedFileBase file = Request.Files["ImageData"];
            if (ImageEntity.Id != imageid)
            {
                Console.WriteLine("WAIT WHAT?" + imageid + " " + ImageEntity.Id);
            }
            MovieData newmovie = new MovieData()
            {
                Postedate=DateTimeOffset.Now,
                Id = Guid.NewGuid(),
                Title = dummyData.Title,
                Release = dummyData.Release,
                Genre = dummyData.Genre,
                Description = dummyData.Description,
                Language = dummyData.Language,
                PosterId = currentUser.Id,
                User_name = currentUser.UserName,
                Cover_pic_id=ImageEntity.Id
            };
            if (isMovie==true)
            {
                newmovie.Catagoryx = Catagory.Movie;
                if (!ModelState.IsValid)
                {
                    return RedirectToAction("Add_entry_movie");
                }
                var successful = await _moviedataService.AddMovieDataAsync(newmovie);
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
            
                var successful = await _tvdataService.AddTVDataAsync(newmovie);
                if (!successful)
                {
                    return BadRequest("Couldnot Post Your Entry");
                }
                return RedirectToAction("Cat_select");
            }
        }
    }
}
