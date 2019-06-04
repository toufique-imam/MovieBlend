using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MovieBlend.Models;
using System.IO;
using System.Drawing;
using MovieBlend.Services;
using Microsoft.AspNetCore.Authorization;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieBlend.Controllers
{
    [Authorize]
    public class EditDataController : Controller
    {
        private IPostDataService _postDataService;
        private static MovieData maindata=new MovieData();
        public EditDataController(IPostDataService postDataService)
        {
            _postDataService = postDataService;
        }
        
        public async Task<IActionResult> Index(string data)
        {
            maindata = new MovieData();
            var datax = Newtonsoft.Json.JsonConvert.DeserializeObject<string>(data);
            var arr = await _postDataService.Getdatabyid(datax);
            maindata = arr;
            return View(arr);
        }
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(MovieData newdata)
        {
            newdata.Id = maindata.Id;
            newdata.Postedate = maindata.Postedate;
            newdata.User_name = maindata.User_name;
            newdata.PosterId = maindata.PosterId;
            newdata.Cover_pic_id = maindata.Cover_pic_id;
            await _postDataService.UpdateData(newdata);
            return RedirectToAction("Index","Home");
        }
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(MovieData newdata)
        {
       
            newdata.Id = maindata.Id;
            newdata.Postedate = maindata.Postedate;
            newdata.User_name = maindata.User_name;
            newdata.PosterId = maindata.PosterId;
            newdata.Cover_pic_id = maindata.Cover_pic_id;
            await _postDataService.DeleteData(newdata);
            return RedirectToAction("Index","Home");
        }

    }
}
