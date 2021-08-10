using CreditCardApi.Domain.Models;
using CreditCardApi.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CreditCardApi.Services
{
    public class InputService : IInputService
    {
        private readonly IInputRepository _inputRepository;
        private readonly ICreditCardRepository _creditCardRepository;

        public InputService(IInputRepository inputRepository, ICreditCardRepository creditCardRepository)
        {
            _inputRepository = inputRepository;
            _creditCardRepository = creditCardRepository;
        }

        /// <summary>
        /// Gets all inputs.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Input>> GetAllInputs()
        {
            var results = await _inputRepository.SelectAll();

            return results;
        }

        /// <summary>
        /// Gets the input by identifier.
        /// </summary>
        /// <param name="inputId">The input identifier.</param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException">id is invalid</exception>
        public async Task<Input> GetInputById(string inputId)
        {
            if (!Guid.TryParse(inputId, out var guidId) || guidId == Guid.Empty) 
                throw new KeyNotFoundException("id is invalid");

            var result = await _inputRepository.SelectById(guidId);

            return result;
        }

        /// <summary>
        /// Adds the new input.
        /// </summary>
        /// <param name="newInput">The new input.</param>
        /// <returns></returns>
        public async Task<Input> AddNewInput(Input newInput)
        {
            if (string.IsNullOrWhiteSpace(newInput?.CardNumber))
                throw new ArgumentNullException("newInput.CardNumber");

            var card = await _creditCardRepository.SelectByCardNumber(newInput.CardNumber);

            if (card == null)
                throw new KeyNotFoundException("credit card number not found");

            var result = await _inputRepository.Insert(newInput);

            return result;
        }

        /// <summary>
        /// Gets all credit cards.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<CreditCard>> GetAllCreditCards()
        {
            var results = await _creditCardRepository.SelectAll();

            return results;
        }
    }
}
