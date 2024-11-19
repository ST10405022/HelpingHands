namespace HelpingHands.Models
{
    public class Volunteer : User
    {
        public void ViewTasks() { }
        public void UpdateTaskStatus() { }
        public List<Tasks> Tasks { get; set; }
    }
}
