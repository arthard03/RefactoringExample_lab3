using System;

namespace LegacyApp
{
    public class AgeCheck : CheckUser
    {
        public bool check(UserService userService, string firstName, string lastName, string email, DateTime dateOfBirth,
            int clientId)
        {
            var now = DateTime.Now;
            int age = now.Year - dateOfBirth.Year;
            if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;

            return age >= 21;
        }
    }
}