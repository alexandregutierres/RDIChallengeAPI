using RDIChallengeAPI.Models;
using RDIChallengeAPI.Services.Interfaces;
using System;
using System.Linq;
using System.Text;

namespace RDIChallengeAPI.Services
{
    public class TokenServices : ITokenServices
    {
        public TokenServices()
        {
        }

        /// <summary>
        /// Generate the Token 
        /// </summary>
        /// <param name="DataHora"></param>
        /// <param name="CardNumber"></param>
        /// <param name="CVV"></param>
        /// <returns></returns>
        public long GetToken(DateTime DataHora, long CardNumber, int CVV)
        {
            Util.Util.RigthRotate(CVV.ToString().ToArray(), CVV);

            var horario = Convert.ToInt32(String.Format("{0:HHmmss}", DataHora));

            byte[] time = BitConverter.GetBytes(horario);
            byte[] cardNumber = BitConverter.GetBytes(Convert.ToInt32(CardNumber.ToString().Substring(CardNumber.ToString().Length - 4, 4)));
            byte[] cvvNumber = BitConverter.GetBytes(CVV);

            var token = BitConverter.ToInt64(time.Concat(cardNumber).Concat(cvvNumber).ToArray(), 0);

            return Convert.ToInt64(token);
        }

        /// <summary>
        /// Verify if Token is Valid
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool IsValid(CustomerValidate model)
        {
            var dateWhen = ConvertTokenToDateTime((long)model.Token);
            if (dateWhen.AddMinutes(30) < DateTime.Now)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Convert token to DateTime
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public DateTime ConvertTokenToDateTime(long token)
        {
            byte[] data = BitConverter.GetBytes(token);

            DateTime when = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                                         Convert.ToInt32(BitConverter.ToInt32(data, 0).ToString().Substring(0, 2)),
                                         Convert.ToInt32(BitConverter.ToInt32(data, 0).ToString().Substring(2, 2)),
                                         Convert.ToInt32(BitConverter.ToInt32(data, 0).ToString().Substring(4, 2)));

            return when;
        }
    }
}
