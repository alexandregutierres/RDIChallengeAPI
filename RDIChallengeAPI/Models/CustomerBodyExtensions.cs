namespace RDIChallengeAPI.Models
{
    public static class CustomerBodyExtensions
    {
        public static CustomerApi ToApi(this CustomerBody customer)
        {
            return new CustomerApi
            {
                RegistrationDate = customer.RegistrationDate,
                Token = customer.Token,
                CardId = customer.CardId
            };
        }
    }
}
