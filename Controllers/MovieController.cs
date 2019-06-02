using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieBlend.Services;
using MovieBlend.Models;
namespace MovieBlend.Controllers
{
    public class MovieController : Controller
    {
        private readonly IPostDataService _moviedataService;
        public MovieController(IPostDataService movieDataService) {
            _moviedataService=movieDataService;
        } 
        public async Task<IActionResult> Index()
        {
            var items=await _moviedataService.GetIncompleteItemsAsync_Movie();
            var model=new MovieDataViewModel(){
                Movies=items
            };
            
            return View(model);
        }
    }
}