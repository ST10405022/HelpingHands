using HelpingHands.Models;
using HelpingHands.Services;
using Microsoft.AspNetCore.Mvc;

namespace HelpingHands.Controllers
{
    public class EventController : Controller
    {
        private readonly EventService _eventService;

        // Constructor with dependency injection
        public EventController(EventService eventService)
        {
            _eventService = eventService ?? throw new ArgumentNullException(nameof(eventService));
        }

        [HttpGet]
        public IActionResult Manage()
        {
            ViewData["BodyClass"] = "about-background";
            var events = _eventService.GetEvents();

            var eventViewModels = events.Select(e => new EventViewModel
            {
                EventName = e.EventName,
                Date = e.Date.ToString("yyyy-MM-dd"),
                Location = e.Location,
                Status = e.Status
            }).ToList();

            return View(eventViewModels);
        }

        // GET: Display the form for creating a new event
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["BodyClass"] = "about-background";
            // Optionally, you can provide preloaded data for dropdowns, etc.
            var programmes = _eventService.GetAvailableProgrammes(); // Example service method
            ViewBag.Programmes = programmes;

            return View();
        }

        // POST: Handle the event creation form submission
        [HttpPost]
        public IActionResult Create(Event newEvent)
        {
            ViewData["BodyClass"] = "about-background";
            if (!ModelState.IsValid)
            {
                // If validation fails, return to the view with error messages
                var programmes = _eventService.GetAvailableProgrammes();
                ViewBag.Programmes = programmes;

                return View(newEvent);
            }

            // Add the new event using the service
            try
            {
                _eventService.AddEvent(newEvent);
                TempData["SuccessMessage"] = "Event created successfully!";
                return RedirectToAction("Index", "Event"); // Redirect to the event list
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while creating the event.");
                Console.WriteLine($"Error: {ex.Message}");
                return View(newEvent);
            }
        }
    }

    public class EventViewModel
    {
        public string EventName { get; set; }
        public string Date { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
    }
}
