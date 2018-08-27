using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IF_Debaser.Models;
using System.Net.Http;

namespace IF_Debaser.Controllers
{
    public class HomeController : Controller
    {
        static HttpClient client = new HttpClient();
        static string path = "http://debaser.se/debaser/api/?method=getevents&venue=medis&from=20100101&to=20100201&format=json";

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public async Task<IActionResult> Debaser()
        {
            IEnumerable<DebaserModel> debaserEvents = null;

            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                debaserEvents = await response.Content.ReadAsAsync<IEnumerable<DebaserModel>>();
            }

            return View(debaserEvents);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
