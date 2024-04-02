using System;

namespace LegacyApp
{
    public class EmailCheck: CheckUser
    {
        public bool check(UserService userService, string firstName, string lastName, string email, DateTime dateOfBirth,
            int clientId)
        {
            return email.Contains("@") && email.Contains(".");
        }
    }
}