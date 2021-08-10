using RDIChallengeAPI.Models;
using RDIChallengeAPI.Repositories.Interfaces;
using RDIChallengeAPI.Services.Interfaces;
using System;

namespace RDIChallengeAPI.Services
{
    public class CustomerServices : ICustomerServices
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ITokenServices _tokenServices;

        public CustomerServices()
        {
        }

        public CustomerServices(ICustomerRepository customerRepository,
                                ITokenServices tokenServices)
        {
            _customerRepository = customerRepository;
            _tokenServices = tokenServices;
        }

        public void Add(CustomerBody customer)
        {
            _customerRepository.Add(customer);
        }

        public CustomerBody Find(int id)
        {
            return _customerRepository.Find(id);
        }
        public CustomerBody FindByCardId(int id)
        {
            return _customerRepository.FindByCardId(id);
        }

        public bool IsValid(CustomerValidate model)
        {

            if (!_tokenServices.IsValid(model))
            {
                return false;
            }

            var customer = _customerRepository.FindByCardId((int)model.CardId);
            if (customer.CustomerId != model.CustomerId)
            {
                return false;
            }

            Console.WriteLine("CardNumber: {0}", customer.CardNumber);

            var dateWhen = _tokenServices.ConvertTokenToDateTime((long)model.Token);
            var tokenCompare = _tokenServices.GetToken(dateWhen, (int)customer.CardNumber, (int)customer.CVV);
            if (tokenCompare != model.Token)
            {
                return false;
            }

            return true;

        }
    }
}
