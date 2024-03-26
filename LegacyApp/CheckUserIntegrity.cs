namespace LegacyApp
{
    public class CheckUserIntegrity : User
    {
        public CheckUserIntegrity(string firstname, string lastname)
        {
            if (string.IsNullOrEmpty(firstname) || string.IsNullOrEmpty(lastname))
            {
                return;
            }
            FirstName = firstname;
            LastName = lastname;
        }
    }
}