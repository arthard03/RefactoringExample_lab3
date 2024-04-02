
namespace LegacyApp
{
    public class CheckCreditLimit : CreditCheck
    {
 
        public void creditValidation(User user, int clientId)
        {
            var clientRepository = new ClientRepository();
            var client = ClientRepository.GetById(clientId);
            if (client.Type == "VeryImportantClient")
            {
                user.HasCreditLimit = false;
            }
            else if (client.Type == "ImportantClient")
            {
                using var userCreditService = new UserCreditService();
                int creditLimit = userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                creditLimit = creditLimit * 2;
                user.CreditLimit = creditLimit;
            }
            else
            {
                user.HasCreditLimit = true;
                using var userCreditService = new UserCreditService();
                int creditLimit = userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                user.CreditLimit = creditLimit;
            }

         
            
        }
    }
}
    
