using CreditCardApi.Domain.Models;
using MediatR;
using System.Collections.Generic;

namespace CreditCardApi.Services.Queries
{
    public class GetInputsQuery : IRequest<List<Input>>
    {
    }

}
