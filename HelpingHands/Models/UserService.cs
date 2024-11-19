namespace HelpingHands.Models
{
    public class UserService
    {
        public bool Register(string username, string password, string role)
        {
            // Check if the username already exists
            if (UserDatabase.Users.Any(u => u.Username == username))
            {
                return false; // Username already taken
            }

            // Add new user to the list
            UserDatabase.Users.Add(new User { Username = username, Password = password, Role = role });
            return true;
        }
    }

}
