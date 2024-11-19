namespace HelpingHands.Models
{
    public static class UserSession
    {
        public static bool IsLoggedIn { get; set; }
        public static string Role { get; set; }
        public static string UserName { get; set; }
    }

}
