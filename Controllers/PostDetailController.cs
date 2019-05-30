using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieBlend.Models;
using MovieBlend.Services;
using PusherServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using MovieBlend.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace MovieBlend.Controllers
{
    [Authorize]
    public class PostDetailController : Controller
    {
        
        private readonly ICommentDataService _commentdataServices;
        private readonly IMovieDataService _movieDataService;
        private readonly ITvDataService _tvDataService;
        private static MovieData maindata;
        private readonly UserManager<IdentityUser> _usermanger;
        public PostDetailController(IMovieDataService movieData, ITvDataService tvData, UserManager<IdentityUser> usermanager,ICommentDataService commentdataService)
        {
            _commentdataServices=commentdataService;
            _usermanger = usermanager;
            _movieDataService = movieData;
            _tvDataService = tvData;
        }
        
        public IActionResult Index(string data)
        {
            maindata = new MovieData();
            var datax = Newtonsoft.Json.JsonConvert.DeserializeObject<string>(data);
            var arr = _movieDataService.Getdatabyid(datax);
            maindata = arr;
            if (arr.Id.ToString() == datax) return View(maindata);
            else
            {
                maindata = arr;
                arr = _tvDataService.Getdatabyid(datax);
                return View(arr);
            }
        }
        public ActionResult Comments(Guid id)
        {
            
            var commets=_commentdataServices.GetIncompleteItemsAsync(id);
            return Json(commets);
            //get comments
        }
        [HttpPost]
        public async Task<ActionResult> AddComment(Comment data)
        {
            Secret ss=new Secret();
            var currentUser = await _usermanger.GetUserAsync(User);
            if(currentUser==null)Challenge();
            data.ID = Guid.NewGuid();
            data.BlogPostID = maindata.Id;
            data.Name =currentUser.UserName;
            data.posteddate=DateTimeOffset.Now;
            var res= await _commentdataServices.AddCommentDataAsync(data);
            if (!res)
            {
                return BadRequest("Couldnot Post Your Entry");
            }
            //->//add comment and save changes
            var options = new PusherOptions
            {
                Cluster = ss.cluster
            };
            var pusher = new Pusher(ss.app_id, ss.key, ss.secret, options);
            ITriggerResult result = await pusher.TriggerAsync("asp_channel", "asp_event", data);
            return Content("ok");
        }
    }
}