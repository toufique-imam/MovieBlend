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
        private static jsonapi jj=new jsonapi();
        private readonly UserManager<IdentityUser> _Usermanger;
        private readonly IWatchListService _WatchListService;
        private static SearchData sx = new SearchData();
        public HomeController(IWatchListService watchListService, UserManager<IdentityUser> userManager)
        {
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
        public IActionResult Search(SearchData sd)
        {
            if (sd.Catagoryx == Catagory.Movie)
            {
                return RedirectToAction("SearchMovie", "Home", sd);
            }
            else
            {
                return RedirectToAction("SearchTV", "Home", sd);

            }
        }
        public async Task<IActionResult> SearchTV(SearchData sd)
        {
            if (sd.data.Length == 0)
                return RedirectToAction("Index", "Home");
            else
            {
                sx = sd;
                string urlx = jj.makequery_tv(sd.data);
                var client = new RestClient(urlx);
                var request = new RestRequest(Method.GET);
                request.AddParameter("undefined", "{}", ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                if (response.IsSuccessful)
                {
                    var temp = JsonConvert.DeserializeObject<JTDArray>(response.Content);
                    for(int i = 0; i < temp.results.Length; i++)
                    {
                        temp.results[i].poster_path = "https://image.tmdb.org/t/p/w200" + temp.results[i].poster_path;
                    }
                    var currentuser = await _Usermanger.GetUserAsync(User);
                    if (currentuser != null)
                    {
                        string userid = currentuser.Id;
                        string finalid;
                        for (int i = 0; i < temp.results.Length; i++)
                        {
                            finalid = userid + temp.results[i].id;
                            var res = await _WatchListService.HasData(finalid);
                            if (res)
                            {
                                temp.results[i].isAdded = true;
                            }
                            else
                            {
                                temp.results[i].isAdded = false;
                            }
                        }
                    }
                    return View(temp);
                }else
                return RedirectToAction("Index", "Home");
            }
        }
        public async Task<IActionResult> SearchMovie(SearchData sd)
        {
            if (sd==null || sd.data.Length == 0)
                return RedirectToAction("Index", "Home");
            if (sd.Catagoryx == Catagory.Tv) return await SearchTV(sd);
            
            else
            {
                sx = sd;
                string urlx = jj.makequery_movie(sd.data);
                var client = new RestClient(urlx);
                var request = new RestRequest(Method.GET);
                request.AddParameter("undefined", "{}", ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                if (response.IsSuccessful)
                {
                    var temp = JsonConvert.DeserializeObject<JMDArray>(response.Content);
                    for (int i = 0; i < temp.results.Length; i++)
                    {
                        temp.results[i].poster_path = "https://image.tmdb.org/t/p/w200" + temp.results[i].poster_path;
                    }

                    var currentuser = await _Usermanger.GetUserAsync(User);
                    if (currentuser != null)
                    {
                        string userid = currentuser.Id;
                        string finalid;
                        for(int i = 0; i < temp.results.Length; i++)
                        {
                            finalid = userid + temp.results[i].id;
                            var res = await _WatchListService.HasData(finalid);
                            if (res)
                            {
                                temp.results[i].isAdded = true;
                            }
                            else
                            {
                                temp.results[i].isAdded = false;
                            }
                        }
                    }
                    return View(temp);
                }else
                return RedirectToAction("Index", "Home");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public async Task<IActionResult> Add_to_WatchList(string data)
        {
            //var idx=Newtonsoft.Json.JsonConvert.DeserializeObject<int>(Movie_ID);
            var currentuser = await _Usermanger.GetUserAsync(User);
            if (currentuser == null) return Challenge();
            WatchListModel watchList = new WatchListModel()
            {
                Id = currentuser.Id.ToString() + data,
                userId = currentuser.Id.ToString(),
                movieId = data
            };
            
            if (!ModelState.IsValid)
            {
                return Search(sx);
            }
            var successful = await _WatchListService.AddWatchListDataAsync(watchList);
            return Search(sx);
        }
        public async Task<IActionResult> Delete_From_WatchList(string data)
        {
            //var idx= Newtonsoft.Json.JsonConvert.DeserializeObject<int>(Movie_ID);
            var currentuser = await _Usermanger.GetUserAsync(User);
            if (currentuser == null) return Challenge();
            WatchListModel watchList = new WatchListModel()
            {
                Id = currentuser.Id.ToString() + data,
                userId = currentuser.Id.ToString(),
                movieId = data
            };
            if (!ModelState.IsValid)
            {
                return Search(sx);
            }
            var successful = await _WatchListService.Delete(watchList);
            return Search(sx);
        }
    }
}
