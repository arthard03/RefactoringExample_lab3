using System;

namespace LegacyApp
{
    public interface CheckUser
    {
        bool check(UserService userService, string firstName, string lastName, string email, DateTime dateOfBirth,
            int clientId);
    }
}
