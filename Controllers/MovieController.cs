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
        private readonly IMovieDataService _moviedataService;
        public MovieController(IMovieDataService movieDataService) {
            _moviedataService=movieDataService;
        } 
        public async Task<IActionResult> Index()
        {
            var items=await _moviedataService.GetIncompleteItemsAsync();
            var model=new MovieDataViewModel(){
                Movies=items
            };
            
            return View(model);
        }
    }
}