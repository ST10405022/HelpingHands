using Microsoft.AspNetCore.Mvc;
using HelpingHands.Models;
using System.Collections.Generic;
using System.ComponentModel.Design;
using HelpingHands.Services;

namespace HelpingHands.Controllers
{
    public class AdminController : Controller
    {
        private readonly VolunteerService _volunteerService;
        private readonly ProgrammeService _programmeService;
        private readonly ResourceService _resourceService;
        private readonly EventService _eventService;
        private readonly List<Donation> _donations;

        // Constructor with dependency injection
        public AdminController(
            VolunteerService volunteerService,
            ProgrammeService programmeService,
            ResourceService resourceService,
            EventService eventService)
        {
            _volunteerService = volunteerService ?? throw new ArgumentNullException(nameof(volunteerService));
            _programmeService = programmeService ?? throw new ArgumentNullException(nameof(programmeService));
            _resourceService = resourceService ?? throw new ArgumentNullException(nameof(resourceService));
            _eventService = eventService ?? throw new ArgumentNullException(nameof(eventService));
            _donations = new List<Donation>
        {
            new Donation { DonorName = "John Doe", Amount = 500, Date = DateTime.Now, ProgramFunded = "Winter Clothing Drive" },
            new Donation { DonorName = "Jane Smith", Amount = 300, Date = DateTime.Now, ProgramFunded = "Food Distribution" }
        };
        }
        public IActionResult Dashboard()
        {
            ViewData["BodyClass"] = "about-background";
            // Check if the user is logged in and is an admin using UserSession
            if (UserSession.IsLoggedIn && UserSession.Role == "Admin")
            {
                // Pre-populate data for admin with sample data
                var volunteerCount = _volunteerService.GetVolunteerCount();
                var programCount = _programmeService.GetProgramCount();
                var resourceCount = _resourceService.GetResourceCount();
                var upcomingEvents = _eventService.GetUpcomingEvents();

                // Add sample data if necessary (for demonstration purposes)
                if (volunteerCount == 0)
                {
                    _volunteerService.AddSampleData();
                }

                if (programCount == 0)
                {
                    _programmeService.AddSampleData();
                }

                if (resourceCount == 0)
                {
                    _resourceService.AddSampleData();
                }

                if (upcomingEvents.Count == 0)
                {
                    _eventService.AddSampleData();
                }

                // Prepare view model to be sent to the view
                var dashboardData = new AdminDashboardViewModel
                {
                    VolunteerCount = volunteerCount,
                    ProgrammeCount = programCount,
                    ResourceCount = resourceCount,
                    UpcomingEvents = upcomingEvents
                };

                return View(dashboardData);
            }

            // If not admin, redirect or show appropriate view
            return RedirectToAction("AccessDenied", "Account");
        }


        public IActionResult ManageProgrammes()
        {
            ViewData["BodyClass"] = "about-background";
            var programs = new List<Programme>
            {
                new Programme { ProgrammeID = 1, ProgrammeName = "Winter Clothing Drive", Description = "Provide winter clothing to those in need." },
                new Programme { ProgrammeID = 2, ProgrammeName = "Food Distribution", Description = "Distribute food to underserved communities." }
            };
            return View(programs);
        }

        public IActionResult ManageResources()
        {
            var resources = new List<Resource>
            {
                new Resource { ResourceID = 1, ResourceName = "Clothing", Quantity = 100 },
                new Resource { ResourceID = 2, ResourceName = "Canned Goods", Quantity = 500 }
            };
            return View(resources);
        }

        public IActionResult ManageVolunteers()
        {
            ViewData["BodyClass"] = "about-background";
            var volunteers = new List<Volunteer>
            {
                new Volunteer { UserId = 1, Name = "John Doe", Email = "john@example.com" },
                new Volunteer { UserId = 2, Name = "Jane Smith", Email = "jane@example.com" }
            };
            return View(volunteers);
        }

        public IActionResult ViewDonations()
        {
            ViewData["BodyClass"] = "about-background";
            // Return donations to the view
            return View(_donations);
        }

        public IActionResult GenerateReports()
        {
            ViewData["BodyClass"] = "about-background";
            // Calculate total donations for each program
            var reportData = _donations
                .GroupBy(d => d.ProgramFunded)
                .Select(g => new
                {
                    Program = g.Key,
                    TotalDonated = g.Sum(d => d.Amount),
                    DonationCount = g.Count(),
                    Donors = g.Select(d => d.DonorName).Distinct().ToList()
                }).ToList();

            return View(reportData);
        }
    }
}
