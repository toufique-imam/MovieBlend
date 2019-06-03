using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieBlend.Models;

using StmlParsing;


namespace MovieBlend.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //Console.WriteLine("Parse : "+StmlParser.Parse("[center][size = 7][color = red]Carrie[/ color][/ size][size = 4][color = red](2013)[/ color][/ size][img]http://ultraimg.com/images/2016/11/11/xWv5.jpg[/img]"));
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public async Task<IActionResult> Search(string data)
        {

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
