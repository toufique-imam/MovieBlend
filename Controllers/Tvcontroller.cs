using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieBlend.Services;
using MovieBlend.Models;
namespace MovieBlend.Controllers
{
    public class TvController : Controller
    {
        private readonly ITvDataService _moviedataService;
        public TvController(ITvDataService movieDataService) {
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