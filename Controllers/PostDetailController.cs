using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieBlend.Models;
using MovieBlend.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace MovieBlend.Controllers
{
    [Authorize]
   
    public class PostDetailController : Controller
    {

        
        //private readonly ICommentDataService _commentdataServices;
        private readonly IMovieDataService _movieDataService;
        private readonly ITvDataService _tvDataService;
        private static MovieData maindata;
        private readonly UserManager<IdentityUser> _usermanger;
        public PostDetailController(IMovieDataService movieData, ITvDataService tvData, UserManager<IdentityUser> usermanager)
        {
           // _commentdataServices=commentdataService;
            _usermanger = usermanager;
            _movieDataService = movieData;
            _tvDataService = tvData;
        }
       
        public IActionResult Index(string data)
        {
            maindata = new MovieData();
            var datax = Newtonsoft.Json.JsonConvert.DeserializeObject<string>(data);
            var arr = _movieDataService.Getdatabyid(datax);
            maindata = arr;
            if (arr.Id.ToString() == datax) return View(maindata);
            else
            {
                maindata = arr;
                arr = _tvDataService.Getdatabyid(datax);
                return View(arr);
            }
        }
    }
}