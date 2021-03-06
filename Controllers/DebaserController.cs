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
        static string basePath = "http://www.debaser.se/debaser/api/?version=2&";

        public async Task<IActionResult> Index(string venueName, string fromDate, string toDate)
        {
            if (fromDate == null && toDate == null)
            {
                fromDate = DateTime.Today.ToString("yyMMdd");
                toDate = DateTime.Today.AddYears(1).ToString("yyMMdd");
            }
            fromDate = removeDash(fromDate);
            toDate = removeDash(toDate);
            string queryString = CreateQueryString(venueName, fromDate, toDate);


            HttpResponseMessage response = await client.GetAsync(queryString);
            if (response.IsSuccessStatusCode)
            {
                IEnumerable<DebaserModel> debaserEvents = await response.Content.ReadAsAsync<IEnumerable<DebaserModel>>();
                debaserEvents.OrderBy(x => x.eventDate);
                return View(debaserEvents);
            }
            else
            {
                return StatusCode(503);
            }
        }

        private static string removeDash(string date)
        {
            date = date.Replace("-", String.Empty);
            return date;
        }

        private static string CreateQueryString(string venueName, string fromDate, string toDate)
        {
            return basePath + "method=getevents&venue=" + venueName + "&from=" + fromDate + "&to=" + toDate + "&format=json";
        }
    }
}