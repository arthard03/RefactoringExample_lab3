namespace LegacyApp
{
    public class VeryImortantClient : CreditCheck
    {
        public void creditValidation(User user, int clientId)
        {
            user.HasCreditLimit = false;

        }
        
    }
}