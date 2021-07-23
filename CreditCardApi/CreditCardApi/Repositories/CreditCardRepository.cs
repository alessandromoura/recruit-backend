using CreditCardApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCardApi.Repositories
{
    public class CreditCardRepository : ICreditCardRepository
    {
        private InputContext _context;

        public CreditCardRepository(InputContext context)
        {
            _context = context;
            InitSampleRecords();
        }

        private void InitSampleRecords()
        {
            //just to create sample order records if order list is empty during init
            if (_context.CardList.Count() == 0)
            {
                _context.CardList.Add(new CreditCard { CardNumber = "1234" });
                _context.CardList.Add(new CreditCard { CardNumber = "1445" });
                _context.CardList.Add(new CreditCard { CardNumber = "3333" });
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Selects the by card number.
        /// </summary>
        /// <param name="cardNum">The card number.</param>
        /// <returns></returns>
        public async Task<CreditCard> SelectByCardNumber(string cardNum)
        {
            var card = _context.CardList.FirstOrDefault(x => string.Equals(x.CardNumber, cardNum, StringComparison.OrdinalIgnoreCase));
            return await Task.FromResult(card);
        }

        /// <summary>
        /// Selects all.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<CreditCard>> SelectAll()
        {
            var cards = _context.CardList.ToList();

            return await Task.FromResult(cards);
        }

        /// <summary>
        /// Inserts the specified card.
        /// </summary>
        /// <param name="card">The card.</param>
        /// <returns></returns>
        public async Task<CreditCard> Insert(CreditCard card)
        {
            _context.CardList.Add(card);
            await _context.SaveChangesAsync();

            return card;
        }

    }
}
