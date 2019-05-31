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
        static bool isMovie = false;
        private readonly IMovieDataService _moviedataService;
        private readonly ITvDataService _tvdataService;
        private readonly UserManager<IdentityUser> _usermanger;
        public PostController(IMovieDataService movieDataService,ITvDataService tvDataService,UserManager<IdentityUser>userManager)
        {
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
            return View("post_entry");
        }
        public IActionResult Add_entry_TV()
        {
            isMovie = false;
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
