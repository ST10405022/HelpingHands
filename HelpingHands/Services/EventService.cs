using HelpingHands.Models;

namespace HelpingHands.Services
{
    public class EventService
    {
        private List<Event> _events;
        private readonly List<Programme> _programmes;

        public EventService(List<Event> events)
        {
            _events = events;
        }
        public EventService()
        {
            _events = new List<Event>
            {
                new Event { EventName = "Winter Clothing Drive", Date = DateTime.Parse("2024-12-01"), Location = "Community Hall", Status = "Scheduled" },
                new Event { EventName = "Food Distribution", Date = DateTime.Parse("2024-12-05"), Location = "Local Church", Status = "Completed" },
                new Event { EventName = "Toy Drive", Date = DateTime.Parse("2024-12-10"), Location = "Main Street", Status = "Scheduled" },
                new Event { EventName = "Blood Donation", Date = DateTime.Parse("2024-12-15"), Location = "City Hospital", Status = "Pending" },
                new Event { EventName = "Holiday Feast", Date = DateTime.Parse("2024-12-20"), Location = "Park Central", Status = "Scheduled" }
            };

            _programmes = new List<Programme>
            {
                new Programme { ProgrammeID = 1, ProgrammeName = "Winter Clothing Drive" },
                new Programme { ProgrammeID = 2, ProgrammeName = "Food Distribution" }
            };

        }

        public List<Programme> GetAvailableProgrammes()
        {
            return _programmes;
        }

        public List<Event> GetUpcomingEvents()
        {
            return _events.Where(e => e.Date > DateTime.Now).ToList();
        }

        public List<Event> GetEvents()
        {
            return _events;
        }

        public void AddEvent(Event newEvent)
        {
            _events.Add(newEvent);
        }

        public void UpdateEventStatus(int eventId, string status)
        {
            var eventToUpdate = _events.FirstOrDefault(e => e.EventID == eventId);
            if (eventToUpdate != null)
            {
                eventToUpdate.Status = status;
            }
        }

        public void AddSampleData()
        {
            if (!_events.Any())
            {
                _events.Add(new Event { EventID = 1, EventName = "Winter Clothing Drive", Date = DateTime.Now.AddMonths(1), Location = "City Center", Status = "Upcoming" });
                _events.Add(new Event { EventID = 2, EventName = "Food Distribution", Date = DateTime.Now.AddMonths(2), Location = "Community Hall", Status = "Upcoming" });
                _events.Add(new Event { EventID = 3, EventName = "Spring Garden Planting", Date = DateTime.Now.AddMonths(3), Location = "Greenhouse", Status = "Upcoming" });
                _events.Add(new Event { EventID = 4, EventName = "Back-to-School Supplies Drive", Date = DateTime.Now.AddMonths(4), Location = "Main Library", Status = "Upcoming" });
                _events.Add(new Event { EventID = 5, EventName = "Community Health Fair", Date = DateTime.Now.AddMonths(5), Location = "Park Plaza", Status = "Upcoming" });
            }
        }

    }

}
