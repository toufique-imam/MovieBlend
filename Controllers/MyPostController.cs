using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieBlend.Services;
using MovieBlend.Models;
using Microsoft.AspNetCore.Identity;

namespace MovieBlend.Controllers
{
    public class MyPostController : Controller
    {
        private readonly IPostDataService _myPostdataService;
        private readonly UserManager<IdentityUser> _usermanger;
        public MyPostController(IPostDataService movieDataService, UserManager<IdentityUser> userManager)
        {
            _usermanger = userManager;
            _myPostdataService = movieDataService;
        }
        public async Task<IActionResult> Index()
        {
            var currentUser = await _usermanger.GetUserAsync(User);
            if (currentUser == null) return Challenge();
            var items = await _myPostdataService.GetIncompleteItemsAsync_MyPost(currentUser.Id);
            var model = new MovieDataViewModel()
            {
                Movies = items
            };
            return View(model);
        }
    }
}