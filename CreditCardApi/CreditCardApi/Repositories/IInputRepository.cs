using CreditCardApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CreditCardApi.Repositories
{
    public interface IInputRepository
    {
        Task<Input> Insert(Input record);
        Task<IEnumerable<Input>> SelectAll();
        Task<Input> SelectById(Guid id);
    }
}