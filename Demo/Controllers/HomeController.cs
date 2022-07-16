using Demo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<SelectListItem> cities = new List<SelectListItem>()
            {  new SelectListItem { Value = "0", Text = "Country" },
                new SelectListItem { Value = "IR", Text = "Iran" },
                new SelectListItem { Value = "US", Text = "USA" },
                new SelectListItem { Value = "UK", Text = "UK" },
                new SelectListItem { Value = "GR", Text = "Germany" }
             };
            ViewBag.cities = cities;
            return View();
        }

        public IActionResult GetCities(string country)
        {
            List<CityItem> items = new List<CityItem>();

            switch (country)
            {
                case "IR":
                    items.Add(new CityItem() { Key = "TH", Value = "Tehran" });
                    items.Add(new CityItem() { Key = "MD", Value = "Mashad" });

                    break;
                case "US":
                    items.Add(new CityItem() { Key = "NY", Value = "Newyork" });
                    items.Add(new CityItem() { Key = "MN", Value = "Mishigan" });

                    break;
                
                case "UK":
                    items.Add(new CityItem() { Key = "LD", Value = "London" });
                    items.Add(new CityItem() { Key = "BG", Value = "Birmangam" });

                    break;
                case "GR":
                    items.Add(new CityItem() { Key = "BR", Value = "Berlin" });
                    items.Add(new CityItem() { Key = "MC", Value = "مونیخ" });

                    break;
                default:
                    break;
            }


            return Json(items);
        }


        public IActionResult SearchNames(string q)
        {
            if (string.IsNullOrEmpty(q))
            {
                q = "";
            }
            List<string> data = new List<string>() { "amir", "reza", "sina", "mina" };
            return Json(data.Where(a => a.Contains(q)).ToList());
        }

        public IActionResult GetContent()
        {
            return Content("hello jquery");
        }

        public IActionResult IncrementCounter(int value)
        {
            return Content((++value).ToString());
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

    public class CityItem
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
