using RDIChallengeAPI.Models;
using RDIChallengeAPI.Repositories.Interfaces;
using RDIChallengeAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;


namespace RDIChallengeAPI.Repositories
{
    public class CustomerRepository: ICustomerRepository
    {
        private ITokenServices _tokenServices;

        public CustomerRepository(ITokenServices tokenServices)
        {
             _tokenServices = tokenServices;

            if (CustomerList.Customers == null)
            {
                CustomerList.Customers = new List<CustomerBody>();
            }
        }


        public void Add(CustomerBody customer)
        {
            var lastId = CustomerList.Customers.Max(i => i.CardId);
            if (lastId == null)
            {
                lastId = 1;
            }
            else
            {
                lastId+= 1;
            }
            customer.CardId = lastId;
            customer.RegistrationDate = DateTime.UtcNow;
            customer.Token = _tokenServices.GetToken(DateTime.Now, (long)customer.CardNumber, (int)customer.CVV);
            CustomerList.Customers.Add(customer);

        }

        public CustomerBody Find(int id)
        {
            return CustomerList.Customers.First(i => i.CustomerId == id);
        }

        public CustomerBody FindByCardId(int id)
        {
            return CustomerList.Customers.First(i => i.CardId == id);
        }
    }
}
