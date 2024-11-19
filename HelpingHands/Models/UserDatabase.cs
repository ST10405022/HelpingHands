using HelpingHands.Controllers;
using System.Collections.Generic;

namespace HelpingHands.Models
{
    public static class UserDatabase
    {
        public static List<User> Users = new List<User>();

        public static void AddUser(User user)
        {
            Users.Add(user);
        }

        public static User GetUser(string username)
        {
            return Users.Find(u => u.Username == username);
        }

        public static List<BeneficiaryViewModel> Beneficiaries { get; set; } = new List<BeneficiaryViewModel>();
        public static List<VolunteerViewModel> Volunteers { get; set; } = new List<VolunteerViewModel>();
    }

}
