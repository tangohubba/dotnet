using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mvc.Models;
using Newtonsoft.Json;
using Flurl;
using Flurl.Http;

public class Show
{
    public string seriesName;
}

namespace mvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {

            var apiRequest = GetDataFromUrl(Environment.GetEnvironmentVariable("API_URL"));
            apiRequest.Wait();

            ViewData["Message"] = "Data from API " + string.Join(",",apiRequest.Result) + " obtained from " + Environment.GetEnvironmentVariable("API_URL");
            return View();
        }

        public async Task<List<String>> GetDataFromUrl(string url)
        {
            var list = await url
            .WithHeader("Accept", "application/json")               
                .GetAsync()                
                .ReceiveJson<List<String>>();
            return list;
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
