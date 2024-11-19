using HelpingHands.Models;
using Microsoft.AspNetCore.Mvc;

namespace HelpingHands.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string userName, string password)
        {
            var user = UserDatabase.Users.FirstOrDefault(u => u.Username == userName && u.Password == password);

            if (user != null)
            {
                UserSession.IsLoggedIn = true;
                UserSession.UserName = user.Username;
                UserSession.Role = user.Role;

                // Debugging: Check session state
                Console.WriteLine($"User logged in: {user.Username}, Role: {user.Role}");

                // Redirect based on the role
                if (user.Role == "Admin")
                {
                    return RedirectToAction("Dashboard", "Admin");
                }
                if (user.Role == "Volunteer")
                {
                    return RedirectToAction("Dashboard", "Volunteer");
                }
                return RedirectToAction("Index", "Beneficiary");
            }

            TempData["Error"] = "Invalid username or password.";
            return RedirectToAction("Login");
        }

        [HttpPost]
        public IActionResult Register(string userName, string password, string role)
        {
            var existingUser = UserDatabase.Users.FirstOrDefault(u => u.Username == userName);

            if (existingUser != null)
            {
                TempData["Error"] = "Username already exists.";
                return RedirectToAction("Register");
            }

            var newUser = new User
            {
                Username = userName,
                Password = password,
                Role = role
            };

            UserDatabase.Users.Add(newUser);
            UserSession.IsLoggedIn = true;
            UserSession.UserName = newUser.Username;
            UserSession.Role = newUser.Role;
            //TempData["Success"] = "Registration successful.";

            // Admin handling
            

            return RedirectToAction("Login");
        }

        public IActionResult Logout()
        {
            UserSession.IsLoggedIn = false;
            UserSession.Role = null;
            UserSession.UserName = null;
            return RedirectToAction("Index", "Home");
        }
    }
}
