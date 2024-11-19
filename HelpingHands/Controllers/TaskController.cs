using Microsoft.AspNetCore.Mvc;

namespace HelpingHands.Controllers
{
    public class TaskController : Controller
    {
        [HttpGet]
        public IActionResult List()
        {
            ViewData["BodyClass"] = "about-background";
            var tasks = new List<TaskViewModel>
            {
                new TaskViewModel { TaskName = "Food Distribution", Description = "Assist in distributing food packages.", Status = "Pending" },
                new TaskViewModel { TaskName = "Clothing Drive", Description = "Help in sorting donated clothes.", Status = "In Progress" }
            };

            return View(tasks);
        }

        [HttpGet]
        public IActionResult Assign()
        {
            ViewData["BodyClass"] = "about-background";
            return View();
        }

        [HttpPost]
        public IActionResult Assign(TaskAssignmentViewModel model)
        {
            ViewData["BodyClass"] = "about-background";
            if (ModelState.IsValid)
            {
                // Save assignment to the database (mock for now)
                return RedirectToAction("AssignConfirmation");
            }
            return View(model);
        }

        public IActionResult AssignConfirmation()
        {
            ViewData["BodyClass"] = "about-background";
            return View();
        }
    }

    public class TaskAssignmentViewModel
    {
        public string VolunteerName { get; set; }
        public string TaskDescription { get; set; }
        public string Deadline { get; set; }
    }

    public class TaskViewModel
    {
        public string TaskName { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
