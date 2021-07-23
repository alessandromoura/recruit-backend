using CreditCardApi.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CreditCardApi.Services
{
    public interface IInputService
    {
        Task<Input> AddNewInput(Input newInput);
        Task<IEnumerable<Input>> GetAllInputs();
        Task<Input> GetInputById(string inputId);

        Task<IEnumerable<CreditCard>> GetAllCreditCards();
    }
}