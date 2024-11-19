namespace HelpingHands.Models
{
    public class AdminDashboardViewModel
    {
        public int VolunteerCount { get; set; }
        public int ProgrammeCount { get; set; }
        public int ResourceCount { get; set; }
        public List<Event> UpcomingEvents { get; set; }
    }

}
