using CreditCardApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCardApi.Repositories
{
    public class InputRepository : IInputRepository
    {
        private InputContext _context;

        public InputRepository(InputContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Selects record by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<Input> SelectById(Guid id)
        {
            var inputs = _context.InputList
                .SingleOrDefault(x => x.Id == id);
            return await Task.FromResult(inputs);
        }

        /// <summary>
        /// Selects all.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Input>> SelectAll()
        {
            var inputs = _context.InputList
                .ToList();

            return await Task.FromResult(inputs);
        }

        /// <summary>
        /// Inserts the specified record.
        /// </summary>
        /// <param name="record">The record.</param>
        /// <returns></returns>
        public async Task<Input> Insert(Input record)
        {
            _context.InputList.Add(record);
            await _context.SaveChangesAsync();

            return record;
        }

        //public async Task<bool> Update(CreditCard updateCard)
        //{
        //    var index = _cards.FindIndex(x => x.CardId == updateCard.CardId);
        //    if (index != -1)
        //    {
        //        _cards[index] = updateCard;
        //        return true;
        //    }
        //    return false;
        //}
    }
}
