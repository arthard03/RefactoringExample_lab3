using System;
using System.Collections.Generic;

namespace LegacyApp
{
    public class UserService
    {
        private readonly List<CheckUser> _checkUsers;

        private ImportantClient _importantClient;
        private VeryImortantClient _veryImortantClient;

        public UserService()
        {
            _checkUsers = new List<CheckUser>()
            {
                new CredentialCheck(),
                new EmailCheck(),
                new AgeCheck(),
            };
        }

        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            foreach (var VARIABLE in _checkUsers)
            {
                if (!VARIABLE.check(this, firstName, lastName, email, dateOfBirth, clientId))
                    return false;
            }

            var clientRepository = new ClientRepository();
            var client = ClientRepository.GetById(clientId);

            var user = new User
            {
                Client = client,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                FirstName = firstName,
                LastName = lastName
            };

            if (client.Type == "VeryImportantClient")
            {
                new VeryImortantClient();
            }
            else if (client.Type == "ImportantClient")
            {
                using var userCreditService = new UserCreditService();
                new ImportantClient(userCreditService);
            }
            else
            {
                user.HasCreditLimit = true;
                using var userCreditService = new UserCreditService();
                int creditLimit = userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                user.CreditLimit = creditLimit;
            }

            if (user.HasCreditLimit && user.CreditLimit < 500)
            {
                return false;
            }

            UserDataAccess.AddUser(user);
            return true;
        }
    }
}