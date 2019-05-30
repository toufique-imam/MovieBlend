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
using PusherServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Web;

namespace MovieBlend.Controllers
{
    //todo 
    //add delete button
    // add edit view
    // add comment 

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
            var datax = JsonConvert.DeserializeObject<string>(data);
            var arr = _movieDataService.Getdatabyid(datax);
            maindata = arr;
            if (arr.Id.ToString() == datax) return View(arr);
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
        [Authorize]
        public async Task<ActionResult> AddComment(Comment data)
        {
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
            var options = new PusherOptions();
            options.Cluster = "XXX_APP_CLUSTER";
            var pusher = new Pusher("APP_ID", "APP_KEY", "APP_SECRET", options);
            ITriggerResult result = await pusher.TriggerAsync("asp_channel", "asp_event", data);
            return Content("ok");
        }
    }
}