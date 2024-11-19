using HelpingHands.Models;
using Microsoft.AspNetCore.Mvc;

namespace HelpingHands.Controllers
{
    public class BeneficiaryController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            ViewData["BodyClass"] = "about-background";
            return View();
        }

        [HttpPost]
        public IActionResult Register(BeneficiaryViewModel model)
        {
            ViewData["BodyClass"] = "about-background";
            if (ModelState.IsValid)
            {
                // Simulate saving to the list
                UserDatabase.Beneficiaries.Add(model);
                UserSession.IsLoggedIn = true;
                UserSession.Role = "Beneficiary";  // Assuming the user is a Beneficiary
                UserSession.UserName = model.Name;  // Use the Name as the username

                return RedirectToAction("Dashboard", "Beneficiary"); // Redirect to the Dashboard
                //return RedirectToAction("Success", "Beneficiary");
            }
            return View(model);
        }

        public IActionResult Dashboard()
        {
            ViewData["BodyClass"] = "about-background";
            // Fetch the logged-in user’s data (assuming their name matches)
            var beneficiary = new BeneficiaryViewModel
            {
                Name = "Jane Smith",
                Email = "jane.smith@example.com",
                ContactNumber = "123-456-7890",
                ResourceNeeds = "Food and medical assistance"
            };

            if (beneficiary == null)
            {
                return RedirectToAction("Index", "Home");  // Redirect if user is not found
            }

            return View(beneficiary);
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
}
