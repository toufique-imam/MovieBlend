using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MovieBlend.Controllers
{
    public class WatchListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}