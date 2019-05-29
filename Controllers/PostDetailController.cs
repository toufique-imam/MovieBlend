using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MovieBlend.Models;
using Newtonsoft.Json;
using MovieBlend.Services;
using System.IO;
using System.Drawing;
namespace MovieBlend.Controllers
{
    //todo 
    //add delete button
    // add edit view
    // add comment 

    public class PostDetailController : Controller
    {
       
        private readonly IMovieDataService _movieDataService;
        private readonly ITvDataService _tvDataService;
        
        public PostDetailController(IMovieDataService movieData,ITvDataService tvData)
        {
            _movieDataService = movieData;
            _tvDataService = tvData;
        }
        public IActionResult Index(string data)
        {
            var datax = JsonConvert.DeserializeObject<string>(data);
            var arr = _movieDataService.Getdatabyid(datax);
            if (arr.Id.ToString() == datax) return View(arr);
            else
            {
                arr = _tvDataService.Getdatabyid(datax);
                return View(arr);
            }
        }
    }
}