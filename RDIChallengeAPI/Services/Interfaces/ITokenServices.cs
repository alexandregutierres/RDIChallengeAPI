using RDIChallengeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RDIChallengeAPI.Services.Interfaces
{
    public interface ITokenServices
    {
        public long GetToken(DateTime DataHora, long CardNumber, int CVV);

        public bool IsValid(CustomerValidate model);

        public DateTime ConvertTokenToDateTime(long token);
    }
}
