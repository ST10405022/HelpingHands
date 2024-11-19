using HelpingHands.Models;

namespace HelpingHands.Services
{
    public class VolunteerService
    {
        private List<Volunteer> _volunteers;

        public VolunteerService(List<Volunteer> volunteers)
        {
            _volunteers = volunteers;
        }

        public List<Tasks> GetTasks(int volunteerId)
        {
            // Fetch tasks assigned to the volunteer from the list
            return _volunteers.FirstOrDefault(v => v.UserId == volunteerId)?.Tasks ?? new List<Tasks>();
        }

        public void UpdateTaskStatus(int volunteerId, int taskId, string newStatus)
        {
            var volunteer = _volunteers.FirstOrDefault(v => v.UserId == volunteerId);
            var task = volunteer?.Tasks.FirstOrDefault(t => t.TaskID == taskId);
            if (task != null)
            {
                task.Status = newStatus;
            }
        }

        public int GetVolunteerCount()
        {
            return _volunteers.Count;
        }

        public void AddSampleData()
        {
            // Insert sample volunteers into the list
            if (!_volunteers.Any())
            {
                _volunteers.Add(new Volunteer { UserId = 1, Name = "John Doe", Email = "john@example.com" });
                _volunteers.Add(new Volunteer { UserId = 2, Name = "Jane Smith", Email = "jane@example.com" });
            }
        }
    }

}
