namespace LegacyApp
{
    public class ImportantClient : CreditCheck
    {
        private readonly UserCreditService _userCreditService;

        public ImportantClient(UserCreditService userCreditService)
        {
            _userCreditService = userCreditService;
        }

        public void creditValidation(User user, int clientId)
        {
            using var userCreditService = new UserCreditService();
            int creditLimit = userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
            creditLimit = creditLimit * 2;
            user.CreditLimit = creditLimit;
        }
    }
}