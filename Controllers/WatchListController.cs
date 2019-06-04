using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieBlend.Services;
using MovieBlend.Models;
using Newtonsoft.Json;

namespace MovieBlend.Controllers
{
    [Authorize]
    public class WatchListController : Controller
    {
        private readonly UserManager<IdentityUser> _Usermanger;
        private readonly IWatchListService _WatchListService;
        private readonly IApiDataService _ApiDataService;
        private static List<ApiCommonData> viewdata=new List<ApiCommonData>();
        public WatchListController(IWatchListService WatchList,IApiDataService ApiData,UserManager<IdentityUser> usermanger){
            _WatchListService=WatchList;
            _ApiDataService=ApiData;
            _Usermanger=usermanger;
        }
        public async Task<IActionResult> Index()
        {
            viewdata.Clear();
            var currentuser=await _Usermanger.GetUserAsync(User);
            var xx=await _WatchListService.GetIncompleteItemsAsync(currentuser.Id);
            for(int i=0;i<xx.Length;i++){
                var xy=await _ApiDataService.GetApidatabyid(xx[i].movieId);
                viewdata.Add(xy);
            }
            return View(viewdata);
        }
   
        public async Task<IActionResult> DeleteWatch(string data)
        {
            var currentuser = await _Usermanger.GetUserAsync(User);
            if (currentuser == null) return Challenge();
           
            WatchListModel watchList = new WatchListModel()
            {
                Id = currentuser.Id.ToString() + data,
                userId = currentuser.Id.ToString(),
                movieId = data,
            };
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "WatchList");
            }
            var successful = await _WatchListService.Delete(watchList);

            return RedirectToAction("Index", "WatchList");
        }
    }
}