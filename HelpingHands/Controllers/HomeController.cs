using HelpingHands.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HelpingHands.Controllers
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
            ViewData["BodyClass"] = "home-background";
            return View();
        }

        public IActionResult FAQ()
        {
            ViewData["BodyClass"] = "about-background";
            return View();
        }

        public IActionResult About()
        {
            ViewData["BodyClass"] = "about-background";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
