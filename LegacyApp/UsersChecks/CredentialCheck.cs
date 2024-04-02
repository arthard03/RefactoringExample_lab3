using System;

namespace LegacyApp
{
    public class CredentialCheck : CheckUser
    {
        public bool check(UserService userService, string firstName, string lastName, string email,
            DateTime dateOfBirth,
            int clientId)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
            {
                return false;
            }

            return true;
        }
    }
}