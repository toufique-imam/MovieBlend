using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieBlend.Models;
using RestSharp;
using StmlParsing;
using Newtonsoft.Json;

namespace MovieBlend.Controllers
{

    public class HomeController : Controller
    {
        private static jsonapi jj=new jsonapi();
        public IActionResult Index()
        {
            //Console.WriteLine("Parse : "+StmlParser.Parse("[center][size = 7][color = red]Carrie[/ color][/ size][size = 4][color = red](2013)[/ color][/ size][img]http://ultraimg.com/images/2016/11/11/xWv5.jpg[/img]"));
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult SearchTV(SerachData sd)
        {
            if (sd.data.Length == 0)
                return RedirectToAction("Index", "Home");
            else
            {
                string urlx = jj.makequery_tv(sd.data);
                var client = new RestClient(urlx);
                var request = new RestRequest(Method.GET);
                request.AddParameter("undefined", "{}", ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                if (response.IsSuccessful)
                {
                    var temp = JsonConvert.DeserializeObject<JTDArray>(response.Content);
                    return View(temp);
                }else
                return RedirectToAction("Index", "Home");
            }
        }
        public IActionResult SearchMovie(SerachData sd)
        {
            if (sd.data.Length == 0)
                return RedirectToAction("Index", "Home");
            else
            {
                string urlx = jj.makequery_movie(sd.data);
                var client = new RestClient(urlx);
                var request = new RestRequest(Method.GET);
                request.AddParameter("undefined", "{}", ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                if (response.IsSuccessful)
                {
                    var temp = JsonConvert.DeserializeObject<JMDArray>(response.Content);
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
    }
}
