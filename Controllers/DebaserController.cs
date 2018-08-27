using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using IF_Debaser.Models;
using Microsoft.AspNetCore.Mvc;

namespace IF_Debaser.Controllers
{
    public class DebaserController : Controller
    {
        static HttpClient client = new HttpClient();
        static string path = "http://debaser.se/debaser/api/?method=getevents&venue=medis&from=20100101&to=20100201&format=json";

        public async Task<IActionResult> Index()
        {
            IEnumerable<DebaserModel> debaserEvents = null;

            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                debaserEvents = await response.Content.ReadAsAsync<IEnumerable<DebaserModel>>();
            }

            return View(debaserEvents);
        }

    }
}