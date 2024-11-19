using Microsoft.AspNetCore.Mvc;

namespace HelpingHands.Controllers
{
    public class DonationController : Controller
    {
        [HttpGet]
        public IActionResult Submit()
        {
            ViewData["BodyClass"] = "about-background";
            return View();
        }

        [HttpPost]
        public IActionResult Submit(DonationViewModel model)
        {
            ViewData["BodyClass"] = "about-background";
            if (ModelState.IsValid)
            {
                // Save the donation details to the database (mock for now)
                return RedirectToAction("Success");
            }
            return View(model);
        }

        public IActionResult Success()
        {
            ViewData["BodyClass"] = "about-background";
            return View();
        }
    }

    public class DonationViewModel
    {
        public string DonorName { get; set; }
        public string DonationType { get; set; }
        public decimal Amount { get; set; }
        public string Comments { get; set; }
    }
}
