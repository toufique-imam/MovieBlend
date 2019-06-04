using System;
using System.Diagnostics;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieBlend.Models;
using RestSharp;

using Newtonsoft.Json;
using Microsoft.AspNetCore.Identity;
using MovieBlend.Services;

namespace MovieBlend.Controllers
{

    public class HomeController : Controller
    {
        private static jsonapi jj = new jsonapi();
        private readonly UserManager<IdentityUser> _Usermanger;
        private readonly IWatchListService _WatchListService;
        private readonly IApiDataService _ApiDataService;
        private static SearchData sx = new SearchData();
        private static ACDarray CDarray = new ACDarray();
        public HomeController(IApiDataService apiTVDataService, IWatchListService watchListService, UserManager<IdentityUser> userManager)
        {
            _ApiDataService = apiTVDataService;
            _WatchListService = watchListService;
            _Usermanger = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        private async Task<IAsyncResult> Check_WatchList()
        {
            var currentuser = await _Usermanger.GetUserAsync(User);
            if (currentuser != null)
            {
                string userid = currentuser.Id;
                string finalid;
                for (int i = 0; i < CDarray.results.Length; i++)
                {
                    finalid = userid + CDarray.results[i].id;
                    var res = await _WatchListService.HasData(finalid);
                    if (res)
                    {
                        CDarray.results[i].isAdded = true;
                    }
                    else
                    {
                        CDarray.results[i].isAdded = false;
                    }
                }
            }
            return null;
        }
        public async Task<IActionResult> Search(SearchData sd)
        {
            if (sd == null || sd.data.Length == 0) return RedirectToAction("Index", "Home");
            if (sx == sd)
            {
                await Check_WatchList();
                return View(CDarray);
            }
            sx = sd;
            string urlx;
            if (sd.Catagoryx == Catagory.Movie)
                urlx = jj.makequery_movie(sd.data);
            else
                urlx = jj.makequery_tv(sd.data);
            var client = new RestClient(urlx);
            var request = new RestRequest(Method.GET);
            request.AddParameter("undefined", "{}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            if (response.IsSuccessful)
            {
                var temp = JsonConvert.DeserializeObject<ACDarray>(response.Content);
                for (int i = 0; i < temp.results.Length; i++)
                {
                    temp.results[i].poster_path = "https://image.tmdb.org/t/p/w200" + temp.results[i].poster_path;
                    temp.results[i].isMovie = (sd.Catagoryx == Catagory.Movie);
                    await _ApiDataService.AddApiDataAsync(temp.results[i]);
                }
                CDarray = temp;
                //check for added to watchlist or what
                await Check_WatchList();
                return View(CDarray);
            }
            else return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> AddWatch(string data)
        {
            var currentuser = await _Usermanger.GetUserAsync(User);
            if (currentuser == null) return Challenge();
            //var midd=JsonConvert.DeserializeObject<int>(data);
            WatchListModel watchList = new WatchListModel()
            {
                Id = currentuser.Id.ToString() + data,
                userId = currentuser.Id.ToString(),
                movieId = data,
                isMovie = (sx.Catagoryx == Catagory.Movie)
            };

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Search", "Home", sx);
            }
            var successful = await _WatchListService.AddWatchListDataAsync(watchList);
            return RedirectToAction("Search", "Home", sx);
        }
        public async Task<IActionResult> DeleteWatch(string data)
        {
            var currentuser = await _Usermanger.GetUserAsync(User);
            if (currentuser == null) return Challenge();
            //var midd=JsonConvert.DeserializeObject<int>(data);
            WatchListModel watchList = new WatchListModel()
            {
                Id = currentuser.Id.ToString() + data,
                userId = currentuser.Id.ToString(),
                movieId = data,
                isMovie = (sx.Catagoryx == Catagory.Movie)
            };
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Search", "Home", sx);
            }
            var successful = await _WatchListService.Delete(watchList);

            return RedirectToAction("Search", "Home", sx);
        }
    }
}
