using HelpingHands.Models;
using HelpingHands.Services;
using Microsoft.AspNetCore.Mvc;

namespace HelpingHands.Controllers
{
    public class VolunteerController : Controller
    {
        private readonly VolunteerService _volunteerService;

        public VolunteerController(VolunteerService volunteerService)
        {
            _volunteerService = volunteerService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            ViewData["BodyClass"] = "about-background";
            return View();
        }

        public IActionResult Success()
        {
            ViewData["BodyClass"] = "about-background";
            return View();
        }

        [HttpPost]
        public IActionResult Register(VolunteerViewModel model)
        {
            ViewData["BodyClass"] = "about-background";
            if (ModelState.IsValid)
            {
                // Simulate saving to the list
                UserDatabase.Volunteers.Add(model);
                UserSession.IsLoggedIn = true;
                UserSession.Role = "Volunteer";  // Assuming the user is a Volunteer
                UserSession.UserName = model.Name;  // Use the Name as the username

                return RedirectToAction("Dashboard", "Volunteer"); // Redirect to the Dashboard
                //return RedirectToAction("Success", "Volunteer");
            }
            return View(model);
        }

        public IActionResult Dashboard()
        {
            ViewData["BodyClass"] = "about-background";
            var tasks = new List<string>
            {
                "Distribute food packages",
                "Assist in fundraising events",
                "Organize donation drives"
            };
            var viewModel = new VolunteerTaskViewModel
            {
                VolunteerName = "John Doe",
                Tasks = tasks
            };
            return View(tasks);
        }

        public IActionResult Logout()
        {
            ViewData["BodyClass"] = "about-background";
            UserSession.IsLoggedIn = false;
            UserSession.Role = null;
            UserSession.UserName = null;
            return RedirectToAction("Index", "Home");
        }
    }

    public class VolunteerViewModel
    {
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public string Skills { get; set; }
        public string Availability { get; set; }
    }
}
