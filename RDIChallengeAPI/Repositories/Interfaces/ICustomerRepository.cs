using RDIChallengeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RDIChallengeAPI.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        public void Add(CustomerBody customer);
        public CustomerBody Find(int id);
        public CustomerBody FindByCardId(int id);
    }
}

