using CreditCardApi.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CreditCardApi.Repositories
{
    public interface ICreditCardRepository
    {
        Task<CreditCard> SelectByCardNumber(string cardNum);

        Task<IEnumerable<CreditCard>> SelectAll();

        Task<CreditCard> Insert(CreditCard card);
    }
}